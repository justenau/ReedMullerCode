using Reed_Muller.Logic.Matrixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reed_Muller.Logic
{
    public static class Encoder
    {
        public static int[] EncodeSingleVector (int[] vector, int m)
        {
            var generatorMatrix = GeneratorMatrix.GetGeneratorMatrix(m);
            var encodedVectorLength = GeneratorMatrix.GetMatrixDimensions(m).columns;

            var resultArray = new int[encodedVectorLength];

            for (int i=0; i<m+1; i++)
            {
                for(int j=0; j < encodedVectorLength; j++)
                {
                    resultArray[j] += vector[i] == 0 ? 0 : generatorMatrix[i,j];
                }
            }
            for(int i=0; i<encodedVectorLength; i++)
            {
                resultArray[i] = resultArray[i] % 2;
            }
            return resultArray;

        }

        public static List<int[]> EncodeBinarySequence (int[] vector, int m, out int additionalBits)
        {
            var result = new List<int[]>();
            var vectorLength = m + 1;
            var vectors = vector.Select((s, i) => vector.Skip(i * vectorLength).Take(vectorLength).ToArray()).Where(a => a.Any()).ToList();
            var lastVector = vectors.Last();
            var lastVectorLength = lastVector.Count();

            additionalBits = 0;
            if (lastVectorLength != vectorLength)
            {
                additionalBits = vectorLength - lastVectorLength;
                vectors.Remove(lastVector);
                Array.Resize(ref lastVector, vectorLength);
                vectors.Add(lastVector);
            }
            foreach(var v in vectors)
            {
                var encoded = EncodeSingleVector(v, m);
                result.Add(encoded);
            }
            return result;

        }

    }
}
