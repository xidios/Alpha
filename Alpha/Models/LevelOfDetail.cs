using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models
{
    public class LevelOfDetail : ICheckable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid WorkProductId { get; set; }
        public int Order { get; set; }

        public Guid GetId() => Id;
        public string GetName() => Name;
        public string GetDescription() => Description;
        public int GetOrder() => Order;
        public Guid GetWorkProductId() => WorkProductId;
        public LevelOfDetail()
        {

        }
        public LevelOfDetail(string name, string description, int order, WorkProduct workProduct)
        {
            Name = name;
            Description = description;
            Order = order;
            WorkProductId = workProduct.Id;
        }
    }
}
