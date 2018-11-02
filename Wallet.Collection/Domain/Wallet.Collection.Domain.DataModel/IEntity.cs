using System;

namespace Wallet.Collection.Domain.DataModel
{
    public interface IEntity<TEntity, TId>
    {
        TId Id { get; set; }

        DateTime CreatedOn { get; set; }

        long CreatedBy { get; set; }
    }
}
