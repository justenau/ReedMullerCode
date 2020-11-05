using Reed_Muller.Logic.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reed_Muller.Logic
{
    public static class Decoder
    {

        public static int[] Decode (int[] vector, int m)
        {
            var transformedVector = vector.Select(x => x == 0 ? -1 : x).ToArray();
            for(int i=1; i<=m; i++)
            {
                var calculationMatrix = HadamardTransformMatrix.GetTransformedMatrix(i, m);
                transformedVector = MatrixUtils.MutltiplyVectorWithMatrix(transformedVector, calculationMatrix, Convert.ToInt32(Math.Pow(2, m)));
            }
            var vectorWithAbsValues = transformedVector.Select(x => Math.Abs(x)).ToList();
            var maxPosition = vectorWithAbsValues.IndexOf(vectorWithAbsValues.Max());
            var reversedBinaryValue = Convert.ToString(maxPosition, 2);

            var zerosToAddCount = m - reversedBinaryValue.Length;
            if (zerosToAddCount != 0)
            {
                reversedBinaryValue = new String('0', zerosToAddCount) + reversedBinaryValue;
            }
            reversedBinaryValue+=transformedVector[maxPosition] < 0 ? '0' : '1';
            var binaryValue = reversedBinaryValue.ToCharArray();
            Array.Reverse(binaryValue);
            var decodedVector = new string(binaryValue).Select(n => int.Parse(n.ToString())).ToArray();
            return decodedVector;
        }

        public static int[] DecodeBinarySequence (List<int[]> vectors, int m)
        {
            var result = new List<int[]>();
            foreach(var vector in vectors)
            {
                var decoded = Decode(vector, m);
                result.Add(decoded);
            };
            return result.SelectMany(r => r).ToArray();
        }
    }
}
