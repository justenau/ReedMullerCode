using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Reed_Muller.Logic
{
    public static class ConversionUtils
    {
        /// <summary>
        /// Covert text message to its binary representation of 0s and 1s.
        /// </summary>
        /// <param name="text">Text message</param>
        /// <returns>Array made of 0s and 1s which represents binary form of the text</returns>
        public static int[] CovertStringToBinaryArray (string text)
        {
            return string.Join("", Encoding.ASCII.GetBytes(text)
                .Select(n => Convert.ToString(n, 2).PadLeft(8, '0')))
                .Select(n => int.Parse(n.ToString())).ToArray();
        }

        /// <summary>
        /// Convert binary sequence to human-readable text using ASCII encoding
        /// </summary>
        /// <param name="binarySequence">Text representation in binary form</param>
        /// <param name="additionalBytes">Aamount of bytes which were added additionally to the message during encoding</param>
        /// <returns>String representation of the text</returns>
        public static string ConvertBinaryArrayToString(int[] binarySequence, int additionalBytes)
        {
            var bytes = new List<byte>();
            var sequenceWithoutAdditionalBytes = binarySequence.Take(binarySequence.Length - additionalBytes).ToArray();
            var message = ConvertIntegerArrayToString(binarySequence);

            for (var i = 0; i < sequenceWithoutAdditionalBytes.Length; i += 8)
            {
                bytes.Add(Convert.ToByte(message.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Concatenates integers in the array to a single string value
        /// </summary>
        /// <param name="array">Integer array</param>
        /// <returns>String representation of the array</returns>
        public static string ConvertIntegerArrayToString(int[] array)
        {
            return string.Join("", array);
        }

        /// <summary>
        /// Coverts string, made of digits, to an integer arrays
        /// </summary>
        /// <param name="text">String to be coverted</param>
        /// <returns>Integer array made of digits from the string</returns>
        public static int[] ConvertStringToIntegerArray(string text)
        {
            return text.Select(n => int.Parse(n.ToString())).ToArray();
        }

        public static int[] ConvertBitmapToIntArray(Bitmap bitmap)
        {
            var converter = new ImageConverter();
            var bytes = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));

            return ConvertStringToIntegerArray(string.Join("", bytes?.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))));
        }
    }
}
