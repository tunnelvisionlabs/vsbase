namespace Tvl.VisualStudio.OutputWindow.Interfaces
{
    /// <summary>
    /// This class allows MEF extensions to declare custom output window panes.
    /// </summary>
    /// <remarks>
    /// This class may be used as-is, or may be extended to implement the
    /// <see cref="DisplayName"/> property to provide localized display names
    /// for output window panes.
    /// </remarks>
    /// <example>
    /// The following example shows how to export a custom output window pane
    /// named <strong>Custom</strong>.
    ///
    /// <code language="cs">
    /// [Export]
    /// [Name("Custom")]
    /// private static readonly OutputWindowDefinition CustomOutputWindowDefinition;
    /// </code>
    ///
    /// <para>
    /// The following example shows how to export a custom output window pane
    /// with the canonical name <strong>Custom</strong> and a localized display
    /// name defined in an <c>SR</c> resources class.
    /// </para>
    ///
    /// <code language="cs">
    /// [Export]
    /// [Name("Custom")]
    /// private static readonly OutputWindowDefinition _customOutputWindowDefinition =
    ///     new CustomOutputWindowDefinition();
    ///
    /// private sealed class CustomOutputWindowDefinition : OutputWindowDefinition
    /// {
    ///   public override string DisplayName
    ///   {
    ///     get
    ///     {
    ///       return SR.CustomOutputWindowName;
    ///     }
    ///   }
    /// }
    /// </code>
    /// </example>
    public class OutputWindowDefinition
    {
        /// <summary>
        /// Gets the display name of the output window pane.
        /// </summary>
        /// <value>
        /// The display name of the output window pane, or <see langword="null"/> if
        /// the canonical name of the pane should be used as the display name.
        /// </value>
        public virtual string DisplayName
        {
            get
            {
                return null;
            }
        }
    }
}
