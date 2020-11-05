namespace Reed_Muller.Logic.Matrixes
{
    public static class MatrixUtils
    {
        /// <summary>
        /// Multiplies vector with matrix and returns the result vector
        /// </summary>
        /// <param name="vector">Vector to be multiplied</param>
        /// <param name="matrix">Matrix to be multiplied</param>
        /// <param name="matrixColumns">Number of columns in matrix (it will be the length of result vector)</param>
        /// <returns></returns>
        public static int[] MutltiplyVectorWithMatrix(int[] vector, int[,] matrix, int matrixColumns)
        {
            int[] result = new int[matrixColumns];
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = 0; j < matrixColumns; j++)
                {
                    result[j] += vector[i]*matrix[i, j];
                }
            }
            return result;
        }
    }
}
