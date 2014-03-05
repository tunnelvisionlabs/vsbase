namespace Tvl.VisualStudio.OutputWindow.Interfaces
{
    using System;
    using System.Diagnostics.Contracts;
    using IVsOutputWindowPane = Microsoft.VisualStudio.Shell.Interop.IVsOutputWindowPane;

    /// <summary>
    /// Represents a single pane in the <strong>Output</strong> window.
    /// </summary>
    /// <threadsafety>
    /// The Output Window Service extension implements the <see cref="Write"/> and <see cref="WriteLine"/>
    /// methods using a single call to <see cref="IVsOutputWindowPane.OutputStringThreadSafe"/>. No
    /// other assurances are made regarding the thread safety of methods in this interface.
    /// </threadsafety>
    /// <preliminary/>
    [ContractClass(typeof(Contracts.IOutputWindowPaneContracts))]
    public interface IOutputWindowPane
    {
        /// <summary>
        /// Gets or sets the display name of the window pane.
        /// </summary>
        /// <value>The display name of the output window pane.</value>
        /// <exception cref="ArgumentNullException">If <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="value"/> is empty.</exception>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Shows and activates the output window pane.
        /// </summary>
        /// <remarks>
        /// Calling this method on an output window pane will not force the <strong>Output</strong>
        /// window itself to become visible if it is not visible already. If this output window pane
        /// was originally created as a hidden pane, calling this method makes it the selected and
        /// visible pane inside the <strong>Output</strong> window.
        /// </remarks>
        /// <example>
        /// The following example shows how to show the standard <strong>Build</strong> window pane.
        /// <code language="cs"><![CDATA[
        /// IOutputWindowPane pane = OutputWindowService.TryGetPane(PredefinedOutputWindowPanes.Build);
        /// if (pane != null)
        ///   pane.Activate();
        /// ]]></code>
        /// </example>
        void Activate();

        /// <summary>
        /// Hides the output window pane.
        /// </summary>
        /// <remarks>
        /// This method makes the output window pane inaccessible.
        /// </remarks>
        /// <example>
        /// The following example shows how use this method to hide a window pane named <strong>Custom</strong>.
        /// <code language="cs"><![CDATA[
        /// IOutputWindowPane pane = OutputWindowService.TryGetPane("Custom");
        /// if (pane != null)
        ///   pane.Hide();
        /// ]]></code>
        /// </example>
        void Hide();

        /// <summary>
        /// Writes text to the output window.
        /// </summary>
        /// <param name="text">The text to write to the output window.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="text"/> is <see langword="null"/>.</exception>
        /// <example>
        /// This method works similarly to <see cref="WriteLine"/>, except it never appends a newline
        /// to the input <paramref name="text"/>. For an example of how to use the <see cref="WriteLine"/>
        /// method, see the documentation for <see cref="IOutputWindowService"/>.
        /// </example>
        void Write(string text);

        /// <summary>
        /// Writes a line of text to the output window.
        /// </summary>
        /// <remarks>
        /// If the specified <paramref name="text"/> already ends with a <see cref="Environment.NewLine"/>,
        /// no additional newline character is appended before writing the text to the output pane.
        /// </remarks>
        /// <param name="text">The line text to write to the output window.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="text"/> is <see langword="null"/>.</exception>
        /// <example>
        /// For an example of how to use this method, see the documentation for <see cref="IOutputWindowService"/>.
        /// </example>
        void WriteLine(string text);
    }
}
