using Reed_Muller.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reed_Muller.Coding
{
    public static class Encoder
    {
        public static Vector EncodeSingleVector (Vector vector, int m)
        {
            GeneratorMatrix.GeneratorMatrixes.TryGetValue(m, out int[,] generatorMatrix);
            var encodedVectorLength = GeneratorMatrix.GetMatrixDimensions(m).columns;

            var resultArray = new int[encodedVectorLength];

            for (int i=0; i<m+1; i++)
            {
                for(int j=0; j < encodedVectorLength; j++)
                {
                    resultArray[j] += vector.Data[i] == 0 ? 0 : generatorMatrix[i,j];
                }
            }
            for(int i=0; i<encodedVectorLength; i++)
            {
                resultArray[i] = resultArray[i] % 2;
            }
            return new Vector(resultArray);

        }

        public static List<Vector> EncodeBinarySequence (Vector sequence, int m, out int additionalBits)
        {
            var result = new List<Vector>();
            var vectorLength = m + 1;
            var vectors = sequence.Data
                .Select((s, i) => sequence.Data.Skip(i * vectorLength).Take(vectorLength).ToArray())
                .Where(a => a.Any()).Select(x => new Vector(x)).ToList();

            var lastVector = vectors.Last();
            var lastVectorData = lastVector.Data;
            var lastVectorLength = lastVectorData.Count();

            additionalBits = 0;
            if (lastVectorLength != vectorLength)
            {
                vectors.Remove(lastVector);
                additionalBits = vectorLength - lastVectorLength;
                Array.Resize(ref lastVectorData, vectorLength);
                lastVector.Data = lastVectorData;
                lastVector.Length = vectorLength;
                vectors.Add(lastVector);
            }
            foreach(var v in vectors)
            {
                var encoded = v.Encode(m);
                result.Add(encoded);
            }
            return result;

        }

    }
}
