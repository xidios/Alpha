using Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    public class Alpha
    {
        // TODO Parent contains only ID
        public Alpha Parent { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        private List<State> States { get; set; } = new List<State>();
        private AlphaContaiment AlphaContaiment { get; set; } = null;
        private WorkProductManifest WorkProductManifest { get; set; } = null;
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
        public string GetName() => Name;
        public List<State> GetStates() => States;
        public Guid GetAlphaId() => Id;
        public WorkProductManifest GetWorkProductManifest() => WorkProductManifest;
        public AlphaContaiment GetAlphaContainment() => AlphaContaiment;
        public void AddState(State state)
        {
            States.Add(state);
        }
        public void SortListOfStatesByOrder()
        {
            States.Sort((x,y)=>x.Order.CompareTo(y.Order));
        }
        public void SetAlphaContainment(AlphaContaiment alphaContaiment)
        {
            AlphaContaiment = alphaContaiment;
        }
        public void DeleteAlphaConteinment()
        {
            AlphaContaiment = null;
        }
        public void SetWorkProductManifest(WorkProductManifest workProductManifest)
        {
            this.WorkProductManifest = workProductManifest;
        }
    }
}
