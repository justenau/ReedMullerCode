using Reed_Muller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reed_Muller.Utils
{
    public static class VectorUtils
    {
        /// <summary>
        /// Change all 0s in vector to -1 value
        /// </summary>
        /// <returns>Transformed vector</returns>
        public static int[] TranformBitsFromZeroToMinusOne(int[] vectorData)
        {
            return vectorData.Select(x => x == 0 ? -1 : x).ToArray();
        }
    }
}
