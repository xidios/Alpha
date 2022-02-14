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
        public WorkProduct()
        {

        }
        public WorkProduct(string name, string description) 
        {
            Name = name;
            Description = description;
        }
        public string GetWorkProductName()
        {
            return Name;
        }
        public string GetWorkProductDescription()
        {
            return Description;
        }
        public Guid GetWorkProductId()
        {
            return Id;
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetDescription(string description)
        {
            this.Description = description;
        }
    }
}
