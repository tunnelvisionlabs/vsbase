namespace Tvl.VisualStudio.Text.Commenter.Interfaces.Contracts
{
    using System;
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
        public NormalizedSnapshotSpanCollection CommentSpans(NormalizedSnapshotSpanCollection spans)
        {
            Contract.Requires<ArgumentNullException>(spans != null, "spans");
            Contract.Ensures(Contract.Result<NormalizedSnapshotSpanCollection>() != null);

            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public NormalizedSnapshotSpanCollection UncommentSpans(NormalizedSnapshotSpanCollection spans)
        {
            Contract.Requires<ArgumentNullException>(spans != null, "spans");
            Contract.Ensures(Contract.Result<NormalizedSnapshotSpanCollection>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}
