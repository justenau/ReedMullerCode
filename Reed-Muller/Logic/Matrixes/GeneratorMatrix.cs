using System;
using System.Collections.Generic;

namespace Reed_Muller.Logic.Matrixes
{
    public static class GeneratorMatrix
    {

        public static Dictionary<int, int[,]> GeneratorMatrixes { get; set; }

        static GeneratorMatrix()
        {
            GeneratorMatrixes = new Dictionary<int, int[,]>();
            RefreshMatrixes();
        }

        /// <summary>
        /// Return generator matrix for provided parameter m
        /// </summary>
        /// <param name="m">Code parameter m</param>
        /// <returns>Generator matrix for parameter m</returns>
        public static int[,] GetGeneratorMatrix (int m)
        {
            GeneratorMatrixes.TryGetValue(m, out int[,] matrix);
            return matrix ?? CalculateGeneratorMatrix(m);
        }

        /// <summary>
        /// Calculate matrix dimensions (row and column count) based on provided parameter m
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Generator matrix dimensions</returns>
        public static (int rows, int columns) GetMatrixDimensions(int m)
        {
            var rows = m + 1;
            var columns = Convert.ToInt32(Math.Pow(2, m));
            return (rows, columns);
        }

        /// <summary>
        /// Calculate generator matrix for parameter m.
        /// This is a recursive function which uses previously calculated matrixes and combines them
        /// to final required generator matrix. If there were no previously calculated matrixes for parameters lower
        /// than m, this function generates all of them and adds them to generated matrixes dictionary.
        /// </summary>
        /// <param name="m">Code parameter m</param>
        /// <returns>New calculated generator matrix for parameter m</returns>
        public static int[,] CalculateGeneratorMatrix (int m)
        {
            // Calculate all matrixes for parameter lower than m
            for(int i = 1; i<m; i++)
            {
                if (!GeneratorMatrixes.ContainsKey(i))
                {
                    CalculateGeneratorMatrix(i);
                }
            }

            // Get value of matrix G(1,m-1)
            GeneratorMatrixes.TryGetValue(m - 1, out int[,] lowerMatrix);

            // Get dimensions of matrixes m and m-1
            var (rows, columns) = GetMatrixDimensions(m);
            var lowerMatrixDimensions = GetMatrixDimensions(m - 1);

            var newMatrix = new int[rows, columns];

            // Fill part of generator matrix G(1,m) with G(1,m-1) values
            for (int i=0; i < lowerMatrixDimensions.rows; i++)
            {
                for(int j=0; j<lowerMatrixDimensions.columns; j++)
                {
                    newMatrix[i, j] = lowerMatrix[i, j];
                    newMatrix[i, lowerMatrixDimensions.columns + j] = lowerMatrix[i, j];
                }
            }

            // Fill last row of G(1,m)
            for (int i = 0; i<lowerMatrixDimensions.columns*2; i++)
            {
                newMatrix[rows - 1, i] = i< lowerMatrixDimensions.columns ? 0 : 1;
            }

            // Save new generator matrix
            GeneratorMatrixes.Add(m, newMatrix);
            return newMatrix;

        }

        /// <summary>
        /// Clears all previously generated matrixes which will not be used after changing M parameters value.
        /// This helps to prevent memory leaks.
        /// Also it initializes G(1,1) matrix because it will be used recursively later
        /// </summary>
        public static void RefreshMatrixes()
        {
            GeneratorMatrixes.Clear();
            GeneratorMatrixes.Add(1, new int[2, 2] { { 1, 1 }, { 0, 1 } });
        }
    }
}
