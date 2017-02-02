namespace Tvl.VisualStudio.OutputWindow.Implementation
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;
    using Tvl.VisualStudio.OutputWindow.Interfaces;
    using Tvl.VisualStudio.Shell;
    using DispatcherPriority = System.Windows.Threading.DispatcherPriority;
    using ErrorHandler = Microsoft.VisualStudio.ErrorHandler;
    using IVsOutputWindowPane = Microsoft.VisualStudio.Shell.Interop.IVsOutputWindowPane;
    using SVsGeneralOutputWindowPane = Microsoft.VisualStudio.Shell.Interop.SVsGeneralOutputWindowPane;
    using SVsServiceProvider = Microsoft.VisualStudio.Shell.SVsServiceProvider;
    using Thread = System.Threading.Thread;
    using VSConstants = Microsoft.VisualStudio.VSConstants;

    [Export(typeof(IOutputWindowService))]
    internal sealed class OutputWindowService : IOutputWindowService
    {
        public OutputWindowService()
        {
        }

        [Import]
        private SVsServiceProvider GlobalServiceProvider
        {
            get;
            set;
        }

        [ImportMany]
        private List<Lazy<OutputWindowDefinition, IOutputWindowDefinitionMetadata>> OutputWindowDefinitions
        {
            get;
            set;
        }

        private readonly ConcurrentDictionary<string, Guid?> _outputWindows =
            new ConcurrentDictionary<string, Guid?>(
                new KeyValuePair<string, Guid?>[]
                {
                    new KeyValuePair<string, Guid?>(PredefinedOutputWindowPanes.Build, VSConstants.OutputWindowPaneGuid.BuildOutputPane_guid),
                    new KeyValuePair<string, Guid?>(PredefinedOutputWindowPanes.Debug, VSConstants.OutputWindowPaneGuid.DebugPane_guid),
                    new KeyValuePair<string, Guid?>(PredefinedOutputWindowPanes.General, VSConstants.OutputWindowPaneGuid.GeneralPane_guid),
                });

        public IOutputWindowPane TryGetPane(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(name)} cannot be empty", nameof(name));

            if (PredefinedOutputWindowPanes.General.Equals(name))
            {
                IVsOutputWindowPane generalPane = GlobalServiceProvider.GetService<SVsGeneralOutputWindowPane, IVsOutputWindowPane>();
                if (generalPane != null)
                    return new VsOutputWindowPaneAdapter(generalPane);
            }

            var outputWindow = GlobalServiceProvider.GetOutputWindow();
            if (outputWindow == null)
                return null;

            Guid? guid = _outputWindows.GetOrAdd(name, CreateWindowPaneOnMainThread);
            if (!guid.HasValue)
                return null;

            Guid guidValue = guid.Value;
            IVsOutputWindowPane vspane = null;
            if (ErrorHandler.Failed(ErrorHandler.CallWithCOMConvention(() => outputWindow.GetPane(ref guidValue, out vspane))))
                return null;

            IOutputWindowPane pane = new VsOutputWindowPaneAdapter(vspane);
            return pane;
        }

        private Guid? CreateWindowPaneOnMainThread(string name)
        {
            if (Application.Current.Dispatcher.Thread == Thread.CurrentThread)
                return CreateWindowPane(name);

            return (Guid?)Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Func<string, Guid?>)CreateWindowPane, name);
        }

        private Guid? CreateWindowPane(string name)
        {
            var outputWindow = GlobalServiceProvider.GetOutputWindow();
            if (outputWindow == null)
                return null;

            var definition = OutputWindowDefinitions.FirstOrDefault(lazy => lazy.Metadata.Name.Equals(name));
            if (definition == null)
                return null;

            Guid guid = Guid.NewGuid();
            // this controls whether the pane is listed in the output panes drop-down list, *not* whether the pane is initially selected
            bool visible = true;
            bool clearWithSolution = false;

            string displayName = definition.Metadata.Name;
            if (definition.Value != null && !string.IsNullOrEmpty(definition.Value.DisplayName))
                displayName = definition.Value.DisplayName;

            if (ErrorHandler.Failed(ErrorHandler.CallWithCOMConvention(() => outputWindow.CreatePane(ref guid, displayName, Convert.ToInt32(visible), Convert.ToInt32(clearWithSolution)))))
                return null;

            return guid;
        }
    }
}
