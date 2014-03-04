namespace Tvl.VisualStudio.Text.Commenter.Interfaces
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text.Editor;

    /// <summary>
    /// This interface defines a component which provides an <see cref="ICommenter"/>
    /// implementation for a <see cref="ITextView"/>.
    /// </summary>
    [ContractClass(typeof(Contracts.ICommenterProviderContracts))]
    public interface ICommenterProvider
    {
        /// <summary>
        /// Gets the <see cref="ICommenter"/> implementation for the specified <see cref="ITextView"/>.
        /// </summary>
        /// <param name="textView">The text view.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="textView"/> is <see langword="null"/>.</exception>
        /// <returns>An instance of <see cref="ICommenter"/>, or <see langword="null"/> if this provider cannot provide a commenter for the specified text view.</returns>
        ICommenter GetCommenter(ITextView textView);
    }
}
