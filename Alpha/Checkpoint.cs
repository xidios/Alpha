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

        public Guid GetCheckpointId()
        {
            return Id;
        }
    }
}
