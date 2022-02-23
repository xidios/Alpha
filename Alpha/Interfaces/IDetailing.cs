using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Interfaces
{
    public interface IDetailing
    {
        string GetName();
        List<Checkpoint> GetCheckpoints();
        void AddCheckpoint(Checkpoint checkpoint);
        Guid GetId();
        void SortListOfCheckpointsByOrder();
        IBaseObject GetBaseObject();
    }
}
