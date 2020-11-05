using Reed_Muller.Models;

namespace Reed_Muller.Utils
{
    public static class MatrixUtils
    {
        /// <summary>
        /// Multiplies vector with matrix and returns the result vector
        /// </summary>
        /// <param name="vector">Vector to be multiplied</param>
        /// <param name="matrix">Matrix to be multiplied</param>
        /// <param name="matrixColumns">Number of columns in matrix (it will be the length of result vector)</param>
        /// <returns>Result vector</returns>
        public static Vector MutltiplyVectorWithMatrix(Vector vector, int[,] matrix, int matrixColumns)
        {
            int[] data = new int[matrixColumns];
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = 0; j < matrixColumns; j++)
                {
                    data[j] += vector.Data[i]*matrix[i, j];
                }
            }
            return new Vector(data);
        }
    }
}
