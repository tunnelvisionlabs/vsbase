namespace Tvl.VisualStudio.Text.Commenter.Interfaces
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text;

    /// <summary>
    /// This interface provides methods for commenting and uncommenting spans of text within
    /// a text editor.
    /// </summary>
    /// <preliminary/>
    [ContractClass(typeof(Contracts.ICommenterContracts))]
    public interface ICommenter
    {
        /// <summary>
        /// Comments out spans of code.
        /// </summary>
        /// <param name="spans">The collection of spans to comment out.</param>
        /// <returns>A collection of spans encompassing the resulting comments.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="spans"/> is <see langword="null"/>.</exception>
        ReadOnlyCollection<VirtualSnapshotSpan> CommentSpans(ReadOnlyCollection<VirtualSnapshotSpan> spans);

        /// <summary>
        /// Uncomments spans of code.
        /// </summary>
        /// <param name="spans">The collection of spans to uncomment.</param>
        /// <returns>A collection of spans encompassing the resulting uncommented code.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="spans"/> is <see langword="null"/>.</exception>
        ReadOnlyCollection<VirtualSnapshotSpan> UncommentSpans(ReadOnlyCollection<VirtualSnapshotSpan> spans);
    }
}
