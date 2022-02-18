using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models
{
    public class WorkProductCriterion
    {
        public string Type { get; set; }
        public string Partial { get; set; }
        public string Minimal { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        private LevelOfDetail LevelOfDetail { get; set; } = null;
        public Guid LevelOfDetailId { get; set; }
        private Activity Activity { get; set; } = null;
        public Guid ActivityId { get; set; }
       
        public Activity GetActivity() => Activity;
        public string GetTypeParameter() => Type;
        public string GetPartial() => Partial;
        public string GetMinimal() => Minimal;
        public Guid GetActivityId() => ActivityId;
        public Guid GetLevelOfDetailId() => LevelOfDetailId;
        public LevelOfDetail GetLevelOfDetail() => LevelOfDetail;
        public WorkProductCriterion()
        {

        }
        public WorkProductCriterion(string type,string partial, string minimal, Activity activity)
        {
            Type = type;
            Partial = partial;
            Minimal = minimal;
            Activity = activity;
            ActivityId = activity.GetId();
        }
        public void SetActivity(Activity activity)
        {
            Activity = activity;
            ActivityId = activity.GetId();
            activity.AddWorkProductCriterion(this);
        }
        public void SetLevelOfDetail(LevelOfDetail levelOfDetail)
        {
            LevelOfDetail = levelOfDetail;
            LevelOfDetailId = levelOfDetail.GetId();
            levelOfDetail.SetWorkProductCriterion(this);
        }

    }
}
