namespace Tvl.VisualStudio.Text.Commenter.Interfaces
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Text;

    /// <summary>
    /// This interface defines a component which provides an <see cref="ICommenter"/>
    /// implementation for a <see cref="ITextBuffer"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Extensions which implement support for custom languages can export an instance of this interface to provide
    /// support for the Comment and Uncomment commands. Several examples for the use of this interface are given in the
    /// documentation for the <see href="01698620-4fc8-4cb0-bb42-5b3a84b8dd66.htm">Commenter Service</see>.
    /// </para>
    /// </remarks>
    [ContractClass(typeof(Contracts.ICommenterProviderContracts))]
    public interface ICommenterProvider
    {
        /// <summary>
        /// Gets the <see cref="ICommenter"/> implementation for the specified <see cref="ITextBuffer"/>.
        /// </summary>
        /// <param name="textBuffer">The text buffer.</param>
        /// <returns>
        /// <para>An instance of <see cref="ICommenter"/>.</para>
        /// <para>-or-</para>
        /// <para><see langword="null"/> if this provider cannot provide a commenter for the specified text
        /// buffer.</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="textBuffer"/> is <see langword="null"/>.</exception>
        ICommenter TryCreateCommenter(ITextBuffer textBuffer);
    }
}
