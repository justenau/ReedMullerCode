using System;
using System.Collections.Generic;

namespace Reed_Muller.Models
{
    public static class HadamardTransformMatrix
    {
        private static readonly int[,] HadamardMatrix;
        public static Dictionary<int, int[,]> IdentityMatrixes { get; set; }
        public static Dictionary<int, int[,]> TransformedMatrixes { get; set; }

        static HadamardTransformMatrix()
        {
            HadamardMatrix = new int[2, 2] { { 1, 1 }, { 1, -1 } };
            IdentityMatrixes = new Dictionary<int, int[,]>();
            TransformedMatrixes = new Dictionary<int, int[,]>();
        }


        /// <summary>
        /// Prepares all identity matrixes of 2^i, where i = 0, 1, ..., m-1.
        /// These matrixes are used for transformation matrix calculations
        /// </summary>
        /// <param name="m">Code parameter m</param>
        public static void PrepareIdentityMatrixes(int m)
        {
            for (int c = 1; c <= Convert.ToInt32(Math.Pow(2, m-1)); c*=2)
            {
                var matrix = new int[c, c];
                for(int i = 0; i<c; i++)
                {
                    for(int j=0; j<c; j++)
                    {
                        matrix[i, j] = i == j ? 1 : 0;
                    }
                }
                IdentityMatrixes.Add(c, matrix);
            }
        }

        /// <summary>
        /// Returns transformed matrix H_m^i
        /// </summary>
        /// <param name="i">Matrix parameter i</param>
        /// <param name="m">Code parameter m</param>
        /// <returns>Transformed matrix H_m^i</returns>
        public static int[,] GetTransformedMatrix(int i, int m)
        {
            TransformedMatrixes.TryGetValue(i, out int[,] matrix);
            return matrix ?? CalculateTransformedMatrix(i, m);
        }

        /// <summary>
        /// Calculates, generates and returns transform matrix H_m^i.
        /// Saves the new generated matrix to the common list.
        /// </summary>
        /// <param name="i">Matrix parameter i</param>
        /// <param name="m">Code parameter m</param>
        /// <returns>New generated transform matrix H_m^i</returns>
        public static int [,] CalculateTransformedMatrix(int i, int m)
        {
            // Get first multiplicand - identity matrix with 2^(m-i) rows/columns
            int firstIdentityMatrixDimension = Convert.ToInt32(Math.Pow(2, m - i));
            IdentityMatrixes.TryGetValue(firstIdentityMatrixDimension, out int[,] firstIdentityMatrix);

            // Get third multiplicand - identity matrix with 2^(i-1) rows/columns
            int secondIdentityMatrixDimension = Convert.ToInt32(Math.Pow(2, i - 1));
            IdentityMatrixes.TryGetValue(secondIdentityMatrixDimension, out int[,] secondIdentityMatrix);

            // Calculate dimension of matrix which will be returned after first multiplication and then do the first transformation
            var firstTransformedMatrixDimension = firstIdentityMatrixDimension * 2;
            var firstTransformedMatrix = new int[firstTransformedMatrixDimension, firstTransformedMatrixDimension];
            ApplyFirstTransformation(firstIdentityMatrix, firstTransformedMatrix, firstIdentityMatrixDimension);

            // Calculate dimension of the final matrix and do the second transformation
            var dimension = Convert.ToInt32(Math.Pow(2, m));
            var finalMatrix = new int[dimension, dimension];
            ApplySecondTransformation(secondIdentityMatrix, firstTransformedMatrix, finalMatrix, firstTransformedMatrixDimension, secondIdentityMatrixDimension);

            TransformedMatrixes.Add(i, finalMatrix);
            return finalMatrix;
        }

        /// <summary>
        /// Does the first multiplication where identity matrix is multiplied with Hadamard matrix
        /// </summary>
        /// <param name="identityMatrix">First multipland</param>
        /// <param name="transformedMatrix">Result is stored in this matrix</param>
        /// <param name="dimension">Identity matrix dimension (rows/columns) count</param>
        private static void ApplyFirstTransformation(int[,] identityMatrix, int[,] transformedMatrix, int dimension)
        {
            for(int i = 0; i < dimension; i++)
            { 
                for(int j=0; j<dimension; j++)
                {
                    if (identityMatrix[i, j] == 1)
                    {
                        transformedMatrix[i * 2, j * 2] = HadamardMatrix[0, 0];
                        transformedMatrix[i * 2, j * 2 + 1] = HadamardMatrix[0, 1];
                        transformedMatrix[i * 2 + 1, j * 2] = HadamardMatrix[1, 0];
                        transformedMatrix[i * 2 + 1, j * 2 + 1] = HadamardMatrix[1, 1];
                    }
                }
            }
        }

        /// <summary>
        /// Does the second multiplication where the result matrix is multiplied with second identity matrix
        /// </summary>
        /// <param name="identityMatrix">Second multipland</param>
        /// <param name="firstTransformedMatrix">First multipland - result of the first transformation</param>
        /// <param name="finalMatrix">Final result matrix is stored in this matrix</param>
        /// <param name="firstTransformedMatrixDimension">Row/column count of the matrix which was result of the first transformation</param>
        /// <param name="identityDimension">Row/column count of the second multipland - identity matrix</param>
        private static void ApplySecondTransformation(int[,] identityMatrix, int[,] firstTransformedMatrix, int[,] finalMatrix, int firstTransformedMatrixDimension, int identityDimension)
        {
            for (int i = 0; i < firstTransformedMatrixDimension; i++)
            {
                for (int j = 0; j < firstTransformedMatrixDimension; j++)
                {
                    for(int k = 0; k<identityDimension; k++)
                    {
                        for(int l=0; l<identityDimension; l++)
                        {
                            finalMatrix[i * identityDimension + k, j * identityDimension + l] = identityMatrix[k, l] * firstTransformedMatrix[i, j];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears all previously generated matrixes which will not be used after changing M parameters value.
        /// This helps to prevent memory leaks.
        /// </summary>
        public static void PrepareHadamardTransformMatrixes(int m)
        {
            IdentityMatrixes.Clear();
            TransformedMatrixes.Clear();
            PrepareIdentityMatrixes(m);
        }

    }
}
