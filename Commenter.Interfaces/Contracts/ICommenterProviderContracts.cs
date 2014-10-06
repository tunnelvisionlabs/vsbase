namespace Tvl.VisualStudio.Text.Commenter.Interfaces.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text;

    /// <summary>
    /// This is the Code Contracts class for the <see cref="ICommenterProvider"/> interface.
    /// </summary>
    [ContractClassFor(typeof(ICommenterProvider))]
    public abstract class ICommenterProviderContracts : ICommenterProvider
    {
        /// <inheritdoc/>
        public ICommenter GetCommenter(ITextBuffer textBuffer)
        {
            Contract.Requires<ArgumentNullException>(textBuffer != null, "textBuffer");

            throw new NotImplementedException();
        }
    }
}
