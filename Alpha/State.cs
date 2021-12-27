using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    public class State : ICheckable
    {
        private Guid Id = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AlphaId { get; set; }

        public State (string name, string desctiption, Alpha alpha)
        {
            Name = name;
            Description = desctiption;
            AlphaId = alpha.Id;
        }
    }
}
