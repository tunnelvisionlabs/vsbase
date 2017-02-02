namespace Tvl.VisualStudio.OutputWindow.Implementation
{
    using System;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Tvl.VisualStudio.OutputWindow.Interfaces;
    using Application = System.Windows.Application;
    using DispatcherPriority = System.Windows.Threading.DispatcherPriority;
    using Thread = System.Threading.Thread;

    internal sealed class VsOutputWindowPaneAdapter : IOutputWindowPane
    {
        private readonly IVsOutputWindowPane _pane;

        public VsOutputWindowPaneAdapter(IVsOutputWindowPane pane)
        {
            if (pane == null)
                throw new ArgumentNullException(nameof(pane));

            this._pane = pane;
        }

        public string Name
        {
            get
            {
                if (Application.Current.Dispatcher.Thread == Thread.CurrentThread)
                    return GetName();

                return (string)Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Func<string>)GetName);
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} cannot be empty", nameof(value));

                if (Application.Current.Dispatcher.Thread == Thread.CurrentThread)
                {
                    SetName(value);
                    return;
                }

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action<string>)SetName, value);
            }
        }

        public void Activate()
        {
            ErrorHandler.ThrowOnFailure(this._pane.Activate());
        }

        public void Hide()
        {
            ErrorHandler.ThrowOnFailure(this._pane.Hide());
        }

        public void Write(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            ErrorHandler.ThrowOnFailure(this._pane.OutputStringThreadSafe(text));
        }

        public void WriteLine(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (!text.EndsWith(Environment.NewLine))
                text += Environment.NewLine;

            Write(text);
        }

        private string GetName()
        {
            string name = null;
            ErrorHandler.ThrowOnFailure(_pane.GetName(ref name));
            return name;
        }

        private void SetName(string value)
        {
            ErrorHandler.ThrowOnFailure(this._pane.SetName(value));
        }
    }
}
