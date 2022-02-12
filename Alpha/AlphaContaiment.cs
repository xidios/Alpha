using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    public class AlphaContaiment
    {
        public decimal LowerBound;
        public decimal UpperBound;
        public Guid AlphaId;
        private Alpha SupAlpha;
        public Guid SubAlphaId;
        private Alpha SubAlpha;

        public Guid GetSupAlphaId()
        {
            return AlphaId;
        }

        public Guid GetSubAlphaId()
        {
            return SubAlphaId;
        }
        public void SetSupAlpha(Alpha alpha)
        {
            SupAlpha = alpha;
        }
        public void SetSubAlpha(Alpha alpha)
        {
            SubAlpha = alpha;
        }
    }
}
