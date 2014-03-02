namespace Tvl.VisualStudio.OutputWindow.Interfaces.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// This is the Code Contracts class for the <see cref="IOutputWindowPane"/> interface.
    /// </summary>
    [ContractClassFor(typeof(IOutputWindowPane))]
    public abstract class IOutputWindowPaneContracts : IOutputWindowPane
    {
        /// <inheritdoc/>
        public string Name
        {
            get
            {
                return string.Empty;
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(value));
            }
        }

        /// <inheritdoc/>
        public void Activate()
        {
        }

        /// <inheritdoc/>
        public void Hide()
        {
        }

        /// <inheritdoc/>
        public void Write(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null);
        }

        /// <inheritdoc/>
        public void WriteLine(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null);
        }
    }
}
