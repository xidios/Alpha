using Alpha.Interfaces;
using Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    public class State : IDetailing, ICheckable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SpecialId { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        private Alpha Alpha { get; set; }
        public Guid AlphaId { get; set; }
        public int Order { get; set; }
        private List<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();
        private AlphaCriterion AlphaCriterion { get; set; } = null;

        public State()
        {

        }
        public State (string name, string desctiption,int order, Alpha alpha)
        {
            Name = name;
            Description = desctiption;
            Order = order;
            AlphaId = alpha.Id;
            Alpha = alpha;
        }
        public Guid GetId() => Id;
        public string GetSpecialId() => SpecialId;
        public string GetName() => Name;
        public List<Checkpoint> GetCheckpoints() => Checkpoints;
        public AlphaCriterion GetAlphaCriterion() => AlphaCriterion;
        public IBaseObject GetBaseObject() => Alpha;
        public void AddCheckpoint(Checkpoint checkpoint)
        {
            Checkpoints.Add(checkpoint);
        }
        public void SortListOfCheckpointsByOrder()
        {
            Checkpoints.Sort((x, y) => x.Order.CompareTo(y.Order));
        }
        public void SetAlphaContaiment(AlphaCriterion alphaCriterion)
        {
            AlphaCriterion = alphaCriterion;
        }
        public void DeleteAlphaCriterion()
        {
            AlphaCriterion = null;
        }
        public void SetAlpha(Alpha alpha)
        {
            Alpha = alpha;
        }
    }
}
