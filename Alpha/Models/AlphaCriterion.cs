using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models
{
    public class AlphaCriterion
    {

        public string Type { get; set; }
        public string Partial { get; set; }
        public int Minimal { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        private State State { get; set; } = null;
        public Guid StateId { get; set; }
        private Activity Activity { get; set; } = null;
        public Guid ActivityId { get; set; }

        public Activity GetActivity() => Activity;
        public string GetTypeParameter() => Type;
        public string GetPartial() => Partial;
        public int GetMinimal() => Minimal;
        public Guid GetActivityId() => ActivityId;
        public Guid GetStateId() => StateId;
        public State GetState() => State;
        public AlphaCriterion()
        {

        }
        public AlphaCriterion(string type, string partial, int minimal, Activity activity)
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
            activity.AddAlphaCriterion(this);
        }
        public void SetState(State state)
        {
            State = state;
            StateId = state.GetId();
            state.SetAlphaContaiment(this);
        }

    }
}



