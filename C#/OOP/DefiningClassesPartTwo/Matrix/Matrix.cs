using System;
using System.Linq;

//Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
//Implement an indexer this[row, col] to access the inner matrix cells.
//Implement the operators + and - (addition and subtraction of matrices of the same size)
//and * for matrix multiplication. Throw an exception when the operation cannot be performed.
//Implement the true operator (check for non-zero elements).

namespace Matrix
{
    class Matrix<T> where T : IComparable
    {
        private readonly T[,] matrix;

        public Matrix()
        { 
        }

        public Matrix(int col, int row)
        {
            this.Col = col;
            this.Row = row;
            this.matrix = new T[Col, Row];
        }

        public int Col { get; private set; }
        public int Row { get; private set; }
        
        public T this[int col, int row]
        {
            get { return this.matrix[col, row]; }
            set { this.matrix[col, row] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Col != matrix2.Col && matrix1.Row != matrix2.Row)
            {
                throw new OperationCanceledException("The matrices must be with the same size.");
            }
            Matrix<T> result = new Matrix<T>(matrix1.Row, matrix1.Col);
            for (int i = 0; i < matrix1.Row; i++)
            {
                for (int j = 0; j < matrix1.Col; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] + (dynamic)matrix2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Col != matrix2.Col && matrix1.Row != matrix2.Row)
            {
                throw new OperationCanceledException("The matrices must be with the same size.");
            }
            Matrix<T> result = new Matrix<T>(matrix1.Row, matrix1.Col);
            for (int i = 0; i < matrix1.Row; i++)
            {
                for (int j = 0; j < matrix1.Col; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] - (dynamic)matrix2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Col != matrix2.Row)
            {
                throw new OperationCanceledException("The matrices cannot be multiplied.");
            }
            Matrix<T> result = new Matrix<T>(matrix1.Row, matrix1.Col);
            for (int i = 0; i < matrix1.Row; i++)
            {
                for (int j = 0; j < matrix1.Col; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] * (dynamic)matrix2[i, j];
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            bool nonZero = true;
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        nonZero = false;
                    }
                }
            }
            return nonZero;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool nonZero = true;
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        nonZero = false;
                    }
                }
            }
            return nonZero;
        }
    }
}
