using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alpha
{
    public class Checkpoint : ICheckable
    {       
        public string Name { get; set; }   
        public string Description { get; set; }
        public int Order { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StateId { get; set; }

        public Checkpoint()
        {

        }
        public Checkpoint(string name,string description,int order, State state)
        {
            Name = name;
            Description = description;
            Order = order;
            StateId = state.GetStateId();
        }
        public Guid GetCheckpointId()
        {
            return Id;
        }
    }
}
