using Reed_Muller.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reed_Muller.Coding
{
    public static class Encoder
    {
        /// <summary>
        /// Encode vector of m+1 length using Reed Muller's code with parameter m.
        /// Vector is multiplied with Generator matrix G(1,m)
        /// </summary>
        /// <param name="vector">Vector to encode</param>
        /// <param name="m">Code parameter m</param>
        /// <returns>Encoded vector</returns>
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


        /// <summary>
        /// Encode binary sequence using Reed Muller's code with parameter m.
        /// Provided binary sequence is divided to vectors of valid length and each of them
        /// is encoded separately. If the last vector's length after dividing the sequence 
        /// is too short, additional 0 bits are added to it.
        /// </summary>
        /// <param name="sequence">Binary sequence - vector - to be encoded</param>
        /// <param name="m">Code parameter m</param>
        /// <param name="additionalBits">Amout of bits that were added to the last encoded vector</param>
        /// <returns></returns>
        public static List<Vector> EncodeBinarySequence (Vector sequence, int m, out int additionalBits)
        {
            var result = new List<Vector>();
            var vectorLength = m + 1;

            // Divide the sequence to a list of vector of correct length
            var vectors = sequence.Data
                .Select((s, i) => sequence.Data.Skip(i * vectorLength).Take(vectorLength).ToArray())
                .Where(a => a.Any()).Select(x => new Vector(x)).ToList();

            var lastVector = vectors.Last();
            var lastVectorData = lastVector.Data;
            var lastVectorLength = lastVectorData.Count();

            additionalBits = 0;
            // Add additional bits to the last vector if neccessary
            if (lastVectorLength != vectorLength)
            {
                vectors.Remove(lastVector);
                additionalBits = vectorLength - lastVectorLength;
                Array.Resize(ref lastVectorData, vectorLength);
                lastVector.Data = lastVectorData;
                lastVector.Length = vectorLength;
                vectors.Add(lastVector);
            }

            // Encode each vector separately
            foreach(var v in vectors)
            {
                var encoded = v.Encode(m);
                result.Add(encoded);
            }
            return result;

        }

    }
}
