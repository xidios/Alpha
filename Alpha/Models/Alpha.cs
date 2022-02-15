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
        private AlphaContaiment SupperAlphaContaiment { get; set; } = null;
        private List<AlphaContaiment> SubordinateAlphaConteinments { get; set; } = new List<AlphaContaiment>();
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
        public AlphaContaiment GetSupperAlphaContainment() => SupperAlphaContaiment;
        public List<AlphaContaiment> GetSubordinateAlphaConteinments() => SubordinateAlphaConteinments;
        public void AddState(State state)
        {
            States.Add(state);
        }
        public void SortListOfStatesByOrder()
        {
            States.Sort((x,y)=>x.Order.CompareTo(y.Order));
        }
        public void SetSupperAlphaContainment(AlphaContaiment alphaContaiment)
        {
            SupperAlphaContaiment = alphaContaiment;
        }
        public void AddSubordinateAlphaContainment(AlphaContaiment alphaContaiment)
        {
            SubordinateAlphaConteinments.Add(alphaContaiment);
        }
        public void DeleteSupperAlphaContainment()
        {
            SupperAlphaContaiment = null;
        }
        public void DeleteSubordinateAlphaContainment(AlphaContaiment alphaContaiment)
        {
            SubordinateAlphaConteinments.Remove(alphaContaiment);
        }
        public void SetWorkProductManifest(WorkProductManifest workProductManifest)
        {
            this.WorkProductManifest = workProductManifest;
        }
        public void DeleteWorkProductManifest()
        {
            WorkProductManifest = null;
        }
    }
}
