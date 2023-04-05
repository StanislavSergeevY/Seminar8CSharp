// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы: 2 4 | 3 4  |  Результирующая матрица будет: 18 20
//                           3 2 | 3 3  |                                15 18

void PrintMatrix(int[,] matrix)
{
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
      Console.Write($"|{matrix[i, j]}\t|");
    Console.WriteLine();
  }
}

int[,] GetAndFillMatrix()
{
  int[,] Matrix = new int[2, 2];
  for (int i = 0; i < Matrix.GetLength(0); i++)
    for (int j = 0; j < Matrix.GetLength(1); j++)
      Matrix[i, j] = new Random().Next(1, 11);
  return Matrix;
}

int[,] MultiplicationMatrix(int[,] matrixFirst, int[,] matrixSecond)
{
  int[,] compositionMatrix = new int[matrixFirst.GetLength(0), matrixSecond.GetLength(1)];
  for (int a = 0; a < matrixFirst.GetLength(0); a++)
  {
    for (int b = 0; b < matrixSecond.GetLength(0); b++)
    {
      for (int c = 0; c < matrixSecond.GetLength(1); c++)
      {
        compositionMatrix[a, b] += matrixFirst[a, c] * matrixSecond[c, b];
        // Console.WriteLine($" : a={a}, c={b}, b={c}, matrixFirst[a={a}, b={c}] = {matrixFirst[a, c]}, matrixSecond[b={c}, c={b}] = {matrixSecond[c, b]} : compositionMatrix[i={a}, j={b}] = {compositionMatrix[a, b]}"); // Log
      }
    }
  }
  return compositionMatrix;
}

Console.Clear(); Console.WriteLine("Hello my friend, get ready to see a miracle!");
int[,] matrixFirst = GetAndFillMatrix();
int[,] matrixSecond = GetAndFillMatrix();
PrintMatrix(matrixFirst); Console.WriteLine();
PrintMatrix(matrixSecond); Console.WriteLine();
PrintMatrix(MultiplicationMatrix(matrixFirst, matrixSecond));