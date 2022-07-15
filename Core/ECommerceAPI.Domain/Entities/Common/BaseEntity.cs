using ECommerceAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities.Common
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Status Status { get; set; } = Status.Active;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}
