namespace Tvl.VisualStudio.OutputWindow.Implementation
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Utilities;
    using Tvl.VisualStudio.OutputWindow.Interfaces;

    /// <summary>
    /// This interface defines the required metadata associated with an MEF-exported
    /// <see cref="OutputWindowDefinition"/>.
    /// </summary>
    /// <preliminary/>
    public interface IOutputWindowDefinitionMetadata
    {
        /// <summary>
        /// Gets the canonical name of the output window. This value should be provided
        /// by using <see cref="NameAttribute"/> in addition to the <see cref="ExportAttribute"/>.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
