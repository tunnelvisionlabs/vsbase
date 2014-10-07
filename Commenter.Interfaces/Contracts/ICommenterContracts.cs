namespace Tvl.VisualStudio.Text.Commenter.Interfaces.Contracts
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text;

    /// <summary>
    /// This is the Code Contracts class for the <see cref="ICommenter"/> interface.
    /// </summary>
    [ContractClassFor(typeof(ICommenter))]
    public abstract class ICommenterContracts : ICommenter
    {
        #region ICommenter Members

        /// <inheritdoc/>
        public ReadOnlyCollection<VirtualSnapshotSpan> CommentSpans(ReadOnlyCollection<VirtualSnapshotSpan> spans)
        {
            Contract.Requires<ArgumentNullException>(spans != null, "spans");
            Contract.Ensures(Contract.Result<ReadOnlyCollection<VirtualSnapshotSpan>>() != null);

            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ReadOnlyCollection<VirtualSnapshotSpan> UncommentSpans(ReadOnlyCollection<VirtualSnapshotSpan> spans)
        {
            Contract.Requires<ArgumentNullException>(spans != null, "spans");
            Contract.Ensures(Contract.Result<ReadOnlyCollection<VirtualSnapshotSpan>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}
