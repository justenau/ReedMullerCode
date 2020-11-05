using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Reed_Muller.Utils
{
    public static class ConversionUtils
    {

        /// <summary>
        /// Converts bytes to a binary string (made of 0s and 1s)
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>String representation of bytes array</returns>
        public static string ConvertBytesToBinaryString(byte[] bytes)
        {
            return string.Join("",bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
        }

        /// <summary>
        /// Converts binary sequence to human-readable text using ASCII encoding
        /// </summary>
        /// <param name="binarySequence">Text representation in binary form</param>
        /// <param name="additionalBits">Amount of bits which were added additionally to the message during encoding</param>
        /// <returns>String representation of the text</returns>
        public static string ConvertBinaryArrayToString(int[] binarySequence, int additionalBits)
        {
            var bytes = new List<byte>();
            var sequenceWithoutAdditionalBytes = binarySequence.Take(binarySequence.Length - additionalBits).ToArray();
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
        /// Coverts binary string to an integer array
        /// </summary>
        /// <param name="text">String to be coverted</param>
        /// <returns>Integer array made of digits from the string</returns>
        public static int[] ConvertStringToIntegerArray(string text)
        {
            return text.Select(n => int.Parse(n.ToString())).ToArray();
        }

        /// <summary>
        /// Encodes text message ASCII and returns to its binary representation of integer array of 0s and 1s.
        /// </summary>
        /// <param name="text">Text message</param>
        /// <returns>Array made of 0s and 1s which represents binary form of the text</returns>
        public static int[] CovertStringToBinaryArray(string text)
        {
            return ConvertStringToIntegerArray(ConvertBytesToBinaryString(Encoding.ASCII.GetBytes(text)));
        }

        /// <summary>
        /// Converts Bitmap image to its representation in binary digit array
        /// </summary>
        /// <param name="bitmap">Bitmap image to convert</param>
        /// <returns>Binary representation of the image</returns>
        public static int[] ConvertBitmapToIntArray(Bitmap bitmap)
        {
            var imageConvert = new ImageConverter();
            var bytes = imageConvert.ConvertTo(bitmap, typeof(byte[])) as byte[];

            return ConvertStringToIntegerArray(ConvertBytesToBinaryString(bytes));
        }

        /// <summary>
        /// Convert binary integer array to an image
        /// </summary>
        /// <param name="array">Array containing 0s or 1s - binary image representation</param>
        /// <param name="additionalBits">Amount of bits which were added additionally to the message during encoding</param>
        /// <returns>Converted image</returns>
        public static Image ConvertIntArrayToImage(int[] array, int additionalBits=0)
        {
            var cleanedUpArray = array.Take(array.Length - additionalBits).ToArray();
            var arrayLength = cleanedUpArray.Length / 8;
            var bytes = new byte[arrayLength];

            for (var i = 0; i < arrayLength; i++)
            {
                bytes[i] = Convert.ToByte(ConvertIntegerArrayToString(array.Skip(8*i).Take(8).ToArray()), 2);
            }

            ImageConverter imageConverter = new ImageConverter();
            return imageConverter.ConvertFrom(bytes) as Image;
        }
    }
}
