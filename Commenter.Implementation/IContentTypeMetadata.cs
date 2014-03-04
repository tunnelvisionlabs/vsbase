namespace Tvl.VisualStudio.Text.Commenter.Implementation
{
    using System.Collections.Generic;
    using ContentTypeAttribute = Microsoft.VisualStudio.Utilities.ContentTypeAttribute;

    /// <summary>
    /// This interface provides access to content type metadata associated with an MEF-exported
    /// component.
    /// </summary>
    /// <seealso cref="ContentTypeAttribute"/>
    public interface IContentTypeMetadata
    {
        /// <summary>
        /// Gets the content types which the exported component should be associated with.
        /// </summary>
        IEnumerable<string> ContentTypes
        {
            get;
        }
    }
}
