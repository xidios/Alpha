using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    public class AlphaContaiment
    {
        public decimal UpperBound { get; set; }
        public decimal LowerBound { get; set; }      
        public Guid AlphaId { get; set; }
        private Alpha SupAlpha { get; set; } = null;
        public Guid SubAlphaId { get; set; }
        private Alpha SubAlpha { get; set; } = null;

        public AlphaContaiment()
        {

        }

        public AlphaContaiment(decimal upper, decimal lower, Alpha supAlpha, Alpha subAlpha)
        {
            UpperBound = upper;
            LowerBound = lower;
            SupAlpha = supAlpha;
            AlphaId = supAlpha.GetAlphaId();
            SubAlpha = subAlpha;
            SubAlphaId = subAlpha.GetAlphaId();
        }
        public Guid GetSupAlphaId() => AlphaId;
        public Guid GetSubAlphaId() => SubAlphaId;
        public Alpha GetSubAlpha() => SubAlpha;
        public decimal GetUpperBound() => UpperBound;
        public decimal GetLowerBound() => LowerBound;
        public void SetSupAlpha(Alpha alpha)
        {
            SupAlpha = alpha;
            AlphaId = alpha.GetAlphaId();
        }
        public void SetSubAlpha(Alpha alpha)
        {
            SubAlpha = alpha;
            SubAlphaId = alpha.GetAlphaId();
        }
    }
}
