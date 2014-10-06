namespace Tvl.VisualStudio.Text.Commenter.Interfaces
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text;

    /// <summary>
    /// This interface defines a component which provides an <see cref="ICommenter"/>
    /// implementation for a <see cref="ITextBuffer"/>.
    /// </summary>
    /// <preliminary/>
    [ContractClass(typeof(Contracts.ICommenterProviderContracts))]
    public interface ICommenterProvider
    {
        /// <summary>
        /// Gets the <see cref="ICommenter"/> implementation for the specified <see cref="ITextBuffer"/>.
        /// </summary>
        /// <param name="textBuffer">The text buffer.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="textBuffer"/> is <see langword="null"/>.</exception>
        /// <returns>
        /// <para>An instance of <see cref="ICommenter"/>.</para>
        /// <para>-or-</para>
        /// <para><see langword="null"/> if this provider cannot provide a commenter for the specified text
        /// buffer.</para>
        /// </returns>
        ICommenter TryCreateCommenter(ITextBuffer textBuffer);
    }
}
