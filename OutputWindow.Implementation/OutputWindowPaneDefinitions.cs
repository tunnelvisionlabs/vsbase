#pragma warning disable 169 // The field 'fieldname' is never used

namespace Tvl.VisualStudio.OutputWindow
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Utilities;
    using Tvl.VisualStudio.OutputWindow.Interfaces;

    /// <summary>
    /// Provides definitions for Tunnel Vision Labs' predefined standard output windows.
    /// These window panes are not actually created within the IDE until an extension
    /// requests access to it using <see cref="IOutputWindowService.TryGetPane"/>.
    /// </summary>
    public static class OutputWindowPaneDefinitions
    {
        /// <summary>
        /// This field is used to export the <strong>TVL IntelliSense Engine</strong>
        /// output window pane definition.
        /// </summary>
        [Export]
        [Name(PredefinedOutputWindowPanes.TvlIntellisense)]
        private static readonly OutputWindowDefinition TvlIntellisenseOutputWindowDefinition;

        /// <summary>
        /// This field is used to export the <strong>TVL Diagnostics</strong>
        /// output window pane definition.
        /// </summary>
        [Export]
        [Name(PredefinedOutputWindowPanes.TvlDiagnostics)]
        private static readonly OutputWindowDefinition TvlDiagnosticsOutputWindowDefinition;
    }
}
