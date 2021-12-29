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
        public int Order { get; set; }

        public State()
        {

        }
        public State (string name, string desctiption,int order, Alpha alpha)
        {
            Name = name;
            Description = desctiption;
            Order = order;
            AlphaId = alpha.Id;
        }
        public Guid GetStateId()
        {
            return Id;
        }
    }
}
