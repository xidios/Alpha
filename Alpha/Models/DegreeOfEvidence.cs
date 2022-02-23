using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha.Enums;

namespace Alpha.Models
{
    public class DegreeOfEvidence
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ICheckableSpecialId { get; set; } = null;

        public Guid ICheckableId { get; set; }
        public bool TypeOfEvidence { get; set; } = false;
        //public string ICheckableName { get; set; }
        private ICheckable ICheckableObject { get; set; }
        private Checkpoint Checkpoint { get; set; }
        public Guid CheckpointId { get; set; }
        public DegreeOfEvidenceEnum DegreeOfEvidenceEnumValue { get; set; }

        public DegreeOfEvidenceEnum GetDegreeOfEvidenceEnumValue() => DegreeOfEvidenceEnumValue;
        public bool GetTypeOfEvidence() => TypeOfEvidence;
        public Guid GetICheckableId() => ICheckableId;
        public Guid GetId() => Id;
        public ICheckable GetICheckable() => ICheckableObject;
        public string GetICheckableSpecialId() => ICheckableSpecialId;
        public Guid GetCheckpointId() => CheckpointId;

        public DegreeOfEvidence()
        {

        }
        public DegreeOfEvidence(Checkpoint checkpoint,ICheckable icheckable, string icheckableName,bool typeOfEvidence, DegreeOfEvidenceEnum degreeOfEvidenceEnum) 
        {
            Checkpoint = checkpoint;
            CheckpointId = checkpoint.GetId();
            ICheckableObject = icheckable;
            ICheckableId = icheckable.GetId();
            //ICheckableName = icheckableName;
            TypeOfEvidence = typeOfEvidence;
            DegreeOfEvidenceEnumValue = degreeOfEvidenceEnum;
            ICheckableSpecialId = icheckable.GetSpecialId();
        }
        public void SetICheckable(ICheckable icheckable)
        {
            ICheckableObject = icheckable;
        }

    }
}
