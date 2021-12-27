using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    public class Alpha
    {
        public Alpha Parent { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        private List<State> States { get; set; } = new List<State>();
        public Alpha()
        {

        }
        public Alpha(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Alpha(string name, string description, Alpha parent)
        {
            Name = name;
            Description = description;
            Parent = parent;
        }
        public List<State> GetStates()
        {
            return States;
        }
        public void AddState(State state)
        {
            States.Add(state);
        }
    }
}
