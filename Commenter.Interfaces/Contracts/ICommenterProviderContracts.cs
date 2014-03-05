namespace Tvl.VisualStudio.Text.Commenter.Interfaces.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text.Editor;

    /// <summary>
    /// This is the Code Contracts class for the <see cref="ICommenterProvider"/> interface.
    /// </summary>
    [ContractClassFor(typeof(ICommenterProvider))]
    public abstract class ICommenterProviderContracts : ICommenterProvider
    {
        /// <inheritdoc/>
        public ICommenter GetCommenter(ITextView textView)
        {
            Contract.Requires<ArgumentNullException>(textView != null, "textView");

            throw new NotImplementedException();
        }
    }
}
