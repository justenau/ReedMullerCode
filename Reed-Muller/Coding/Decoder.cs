using Reed_Muller.Models;
using Reed_Muller.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reed_Muller.Coding
{
    public static class Decoder
    {

        public static Vector DecodeSingleVector (Vector vector, int m)
        {
            var transformedVector = vector.TranformBitsFromZeroToMinusOne();

            for(int i=1; i<=m; i++)
            {
                var calculationMatrix = HadamardTransformMatrix.GetTransformedMatrix(i, m);
                transformedVector = MatrixUtils.MutltiplyVectorWithMatrix(transformedVector, calculationMatrix, Convert.ToInt32(Math.Pow(2, m)));
            }
            var vectorDataAbsValues = transformedVector.Data.Select(x => Math.Abs(x)).ToList();
            var maxPosition = vectorDataAbsValues.IndexOf(vectorDataAbsValues.Max());
            var reversedBinaryValue = Convert.ToString(maxPosition, 2);

            var zerosToAddCount = m - reversedBinaryValue.Length;
            if (zerosToAddCount != 0)
            {
                reversedBinaryValue = new String('0', zerosToAddCount) + reversedBinaryValue;
            }
            reversedBinaryValue+=transformedVector.Data[maxPosition] < 0 ? '0' : '1';
            var binaryValue = reversedBinaryValue.ToCharArray();
            Array.Reverse(binaryValue);
            var decodedVectorData = ConversionUtils.ConvertStringToIntegerArray(new string(binaryValue));
            return new Vector(decodedVectorData);
        }

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
