using Alpha.Interfaces;
using Alpha.Models;
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
        public string SpecialId { get; set; } = null;
        public Guid DetailId { get; set; }
        private List<DegreeOfEvidence> DegreeOfEvidences { get; set; } = new List<DegreeOfEvidence>();
        public Checkpoint()
        {

        }
        public Checkpoint(string name,string description,int order, IDetailing detail,string specialId)
        {
            Name = name;
            Description = description;
            Order = order;
            DetailId = detail.GetId();
            SpecialId = specialId;
        }
        public Guid GetId() => Id;
        public string GetSpecialId() => SpecialId;
        public Guid GetDetailId() => DetailId;
        public string GetName() => Name;
        public string GetDescription() => Description;
        public List<DegreeOfEvidence> GetDegreeOfEvidences() => DegreeOfEvidences;
        public void AddDegreeOfEvidence(DegreeOfEvidence degreeOfEvidence)
        {
            DegreeOfEvidences.Add(degreeOfEvidence);
        }
        public void RemoveDegreeOfEvidence(DegreeOfEvidence degreeOfEvidence)
        {
            DegreeOfEvidences.Remove(degreeOfEvidence);
        }
        public void SetSpecialId(string specialId)
        {
            SpecialId = specialId;
        }
    }
}
