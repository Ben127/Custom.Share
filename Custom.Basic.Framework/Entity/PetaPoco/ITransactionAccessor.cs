using System.Data;

namespace Custom.Basic.Framework.Entity.PetaPoco
{
    public interface ITransactionAccessor
    {
        /// <summary>
        ///     Gets the current transaction instance.
        /// </summary>
        /// <returns>
        ///     The current transaction instance; else, <c>null</c> if not transaction is in progress.
        /// </returns>
        IDbTransaction Transaction { get; }
    }
}
