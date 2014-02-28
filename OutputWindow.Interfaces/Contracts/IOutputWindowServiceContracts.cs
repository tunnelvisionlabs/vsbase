namespace Tvl.VisualStudio.OutputWindow.Interfaces.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// This is the Code Contracts class for the <see cref="IOutputWindowService"/> interface.
    /// </summary>
    [ContractClassFor(typeof(IOutputWindowService))]
    public abstract class IOutputWindowServiceContracts : IOutputWindowService
    {
        /// <inheritdoc/>
        IOutputWindowPane IOutputWindowService.TryGetPane(string name)
        {
            Contract.Requires<ArgumentNullException>(name != null, "name");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(name));

            throw new NotImplementedException();
        }
    }
}
