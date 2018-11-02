using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Collection.Domain.DataModel
{
    public class Entity<TEntity, TId> : EntityBase, IEntity<TEntity, TId>
    {
        public Entity()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TId Id { get; set; }
    }
}
