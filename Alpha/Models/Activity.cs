using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models
{
    public class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string GetName() => Name;
        public string GetDescription() => Description;
        public Guid GetId() => Id;

        public Activity()
        {

        }
        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void SetName(string name)
        {
            Name =name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
