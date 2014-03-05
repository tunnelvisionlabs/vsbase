namespace Tvl.VisualStudio.OutputWindow.Interfaces
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// This interface provides access to named panes in the <strong>Output</strong> window.
    /// </summary>
    /// <remarks>
    /// This is a MEF component, and should be imported with the following attribute.
    /// <code>
    /// [Import]
    /// </code>
    /// </remarks>
    /// <example>
    /// The following example shows how to import and use this service.
    /// <list type="number">
    /// <item>
    /// Import an <see cref="IOutputWindowService"/>, which is used to access named panes in the output window.
    /// <code language="cs"><![CDATA[
    /// [Import]
    /// internal IOutputWindowService OutputWindowService { get; set; }
    /// ]]></code>
    /// </item>
    /// <item>
    /// Use the <see cref="IOutputWindowService.TryGetPane"/> method to obtain the desired <see cref="IOutputWindowPane"/>,
    /// and then write to the pane using the <see cref="IOutputWindowPane.Write"/> or <see cref="IOutputWindowPane.WriteLine"/>
    /// method. This example writes a line of text to the <see cref="PredefinedOutputWindowPanes.General"/> pane,
    /// one of the standard panes provided by Visual Studio.
    /// <code language="cs"><![CDATA[
    /// IOutputWindowPane pane = OutputWindowService.TryGetPane(PredefinedOutputWindowPanes.General);
    /// if (pane != null)
    /// {
    ///   pane.WriteLine("This text appears in the General pane of the Output Window.");
    /// }
    /// ]]></code>
    /// </item>
    /// </list>
    /// </example>
    /// <threadsafety>
    /// The service implementing this interface ensures the <see cref="TryGetPane"/> method
    /// is safe for use in multi-threaded extension code. However, calls to this method from
    /// non-UI threads may block while the main thread processes the request.
    /// </threadsafety>
    /// <preliminary/>
    [ContractClass(typeof(Contracts.IOutputWindowServiceContracts))]
    public interface IOutputWindowService
    {
        /// <summary>
        /// Gets the output window pane with the specified name.
        /// </summary>
        /// <param name="name">The canonical name of the output window pane.</param>
        /// <returns>
        /// The <see cref="IOutputWindowPane"/> instance providing access to the
        /// window pane, or <see langword="null"/> if no pane exists with the
        /// specified name.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="name"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="name"/> is empty.</exception>
        /// <example>
        /// For an example of how to use this method, see the documentation for <see cref="IOutputWindowService"/>.
        /// </example>
        IOutputWindowPane TryGetPane(string name);
    }
}
