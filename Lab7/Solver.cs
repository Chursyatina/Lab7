using Accord.Math.Optimization;
using MathNet.Numerics.LinearAlgebra;
using System.Numerics;

namespace Lab7
{
    public class Solver : ISolver
    {
        private double[,] GetMatrixW(double[] tolerance)
        {
            double[,] result = new double[tolerance.Length, tolerance.Length];
            for (int i = 0; i < tolerance.Length; i++)
            {
                for (int j = 0; j < tolerance.Length; j++)
                {
                    result[i, j] = i == j ? 1 / (tolerance[j] * tolerance[j]) : 0;
                }
            }

            return result;
        }

        private double[,] GetMatrixI(double[] vectorI)
        {
            double[,] result = new double[vectorI.Length, vectorI.Length];
            for (int i = 0; i < vectorI.Length; i++)
            {
                for (int j = 0; j < vectorI.Length; j++)
                {
                    result[i, j] = i == j ? vectorI[j] : 0;
                }
            }

            return result;
        }

        private double[,] GetMatrixH(double[,] matrixW, double[,] matrixI)
        {
            var w = Matrix<double>.Build.SparseOfArray(matrixW);
            var i = Matrix<double>.Build.SparseOfArray(matrixI);

            return w.Multiply(i).ToArray();
        }

        private double[] GetVectorD(double[,] matrixH, double[] vectorX0)
        {
            var h = Matrix<double>.Build.SparseOfArray(matrixH);
            var x0 = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.SparseOfArray(vectorX0);

            return h.Multiply(x0).Multiply(-1).ToArray();
        }

        private double[] FindMinimum(double[,] matrixH, double[] vectorD, double[,] matrixA, double[] vectorY)
        {
            GoldfarbIdnani solver = new GoldfarbIdnani(matrixH, vectorD, matrixA, vectorY, 3);
            solver.Minimize();
            return solver.Solution;
        }

        public double[] Solve(Data data)
        {
            var i = this.GetMatrixI(data.VectorI);
            var w = this.GetMatrixW(data.Tolerance);
            var h = this.GetMatrixH(w, i);
            var d = this.GetVectorD(h, data.VectorX0);

            return this.FindMinimum(h, d, data.MatrixA, data.VectorY);
        }
    }
}