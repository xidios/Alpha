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
        private List<WorkProductManifest> WorkProductManifests { get; set; } = new List<WorkProductManifest>();
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
        public List<WorkProductManifest> GetWorkProductManifests() => WorkProductManifests;

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetDescription(string description)
        {
            this.Description = description;
        }
        public void AddWorkProductManifest(WorkProductManifest workProductManifest)
        {
            WorkProductManifests.Add(workProductManifest);
        }
        public void DeleteWorkProductManifest(WorkProductManifest workProductManifest)
        {
            WorkProductManifests.Remove(workProductManifest);
        }
    }
}
