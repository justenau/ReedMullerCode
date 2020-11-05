using Reed_Muller.Utils;
using System.Linq;
using Encoder = Reed_Muller.Coding.Encoder;
using Decoder = Reed_Muller.Coding.Decoder;

namespace Reed_Muller.Models
{
    public class Vector
    {
        public int[] Data { get; set; }
        public int M { get; set; }
        public int Length { get; set; }

        /// <summary>
        /// Initialize empty vector with provided length
        /// </summary>
        /// <param name="length">Length of the new vector</param>
        public Vector(int length)
        {
            Length = length;
            Data = new int[Length];
        }

        /// <summary>
        /// Initialize vector with the provided data
        /// </summary>
        /// <param name="data">New vector data</param>
        public Vector(int[] data)
        {
            Length = data.Length;
            Data = data;
        }

        /// <summary>
        /// Initialize vector with binary string converted to integer array
        /// </summary>
        /// <param name="data">Binary string</param>
        public Vector(string data)
        {
            Data = ConversionUtils.ConvertStringToIntegerArray(data);
            Length = Data.Length;
        }

        /// <summary>
        /// Encode vector using Reed Muller code
        /// </summary>
        /// <param name="m">Code parameter m</param>
        /// <returns>Encoded vector</returns>
        public Vector Encode(int m)
        {
            return Encoder.EncodeSingleVector(this, m);
        }

        /// <summary>
        /// Decode vector using Fast Hadamard Transform
        /// </summary>
        /// <param name="m">Code parameter m</param>
        /// <returns>Decoded vector</returns>
        public Vector Decode(int m)
        {
            return Decoder.DecodeSingleVector(this, m);
        }

        /// <summary>
        /// Change all 0s in vector to -1 value
        /// </summary>
        /// <returns>Transformed vector</returns>
        public Vector TranformBitsFromZeroToMinusOne()
        {
            return new Vector(Data.Select(x => x == 0 ? -1 : x).ToArray());
        }
    }
}
