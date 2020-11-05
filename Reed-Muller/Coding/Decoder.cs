using Reed_Muller.Models;
using Reed_Muller.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reed_Muller.Coding
{
    public static class Decoder
    {
        /// <summary>
        /// Decodes vector using Fast Hadamard Transform.
        /// 0s in the vector are changed to '-1', then the encoded vector is multiplied with H matrixes and the results
        /// and summed up together. The index of the highest absolute value in the sum vector is used for decoding.
        /// Index value is transformed to reversed binary number with '1' in front of it the highest value 
        /// was positive and '0' if it was negative. The final vector is the decoded vector.
        /// </summary>
        /// <param name="vector">Encoded vector</param>
        /// <param name="m">Code parameter m</param>
        /// <returns>Decoded vector</returns>
        public static Vector DecodeSingleVector (Vector vector, int m)
        {
            var transformedVector = vector.TranformBitsFromZeroToMinusOne();

            // Multiply vector with H matrixes and sum up the results to a single vector
            for(int i=1; i<=m; i++)
            {
                var calculationMatrix = HadamardTransformMatrix.GetTransformedMatrix(i, m);
                transformedVector = MatrixUtils.MutltiplyVectorWithMatrix(transformedVector, calculationMatrix, Convert.ToInt32(Math.Pow(2, m)));
            }

            // Get the index of the highest absolute value in the vector and convert it to binary representation
            var vectorDataAbsValues = transformedVector.Data.Select(x => Math.Abs(x)).ToList();
            var maxPosition = vectorDataAbsValues.IndexOf(vectorDataAbsValues.Max());
            var reversedBinaryValue = Convert.ToString(maxPosition, 2);

            var zerosToAddCount = m - reversedBinaryValue.Length;
            if (zerosToAddCount != 0)
            {
                reversedBinaryValue = new string('0', zerosToAddCount) + reversedBinaryValue;
            }

            // Add the first digit, based on if the highest value was positive or negative
            reversedBinaryValue+=transformedVector.Data[maxPosition] < 0 ? '0' : '1';

            var binaryValue = reversedBinaryValue.ToCharArray();
            Array.Reverse(binaryValue);
            var decodedVectorData = ConversionUtils.ConvertStringToIntegerArray(new string(binaryValue));
            return new Vector(decodedVectorData);
        }

        /// <summary>
        /// Decoded binary sequence using Fast Hadamar Transform. All of the vectors in the received list
        /// are decoded independently and then combined to a single decoded result vector.
        /// </summary>
        /// <param name="vectors">List of vectors to be decoded</param>
        /// <param name="m">Code parameter m</param>
        /// <returns>Decoded vector</returns>
        public static Vector DecodeBinarySequence (List<Vector> vectors, int m)
        {
            var result = new List<Vector>();
            foreach(var vector in vectors)
            {
                var decoded = vector.Decode(m);
                result.Add(decoded);
            };
            return new Vector(result.Select(v=>v.Data).SelectMany(r => r).ToArray());
        }
    }
}
