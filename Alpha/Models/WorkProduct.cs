using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models
{
    public class WorkProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        private WorkProductManifest WorkProductManifest { get; set; } = null;
        public WorkProduct()
        {

        }
        public WorkProduct(string name, string description) 
        {
            Name = name;
            Description = description;
        }
        public string GetWorkProductName() => Name;

        public string GetWorkProductDescription() => Description;

        public Guid GetWorkProductId() => Id;

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetDescription(string description)
        {
            this.Description = description;
        }
        public void SetWorkProductManifest(WorkProductManifest workProductManifest)
        {
            this.WorkProductManifest = workProductManifest;
        }
    }
}
