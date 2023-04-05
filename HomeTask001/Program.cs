// Задача 54: Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив: 1 4 7 2  |  В итоге получается вот такой массив: 7 4 2 1
//                         5 9 2 3  |                                       9 5 3 2
//                         8 4 2 4  |                                       8 4 4 2

void PrintMatrixArray(int[,] matrixArray)
{
  for (int i = 0; i < matrixArray.GetLength(0); i++)
  {
    // Console.Write($"index'{i}' ");
    for (int j = 0; j < matrixArray.GetLength(1); j++)
    {
      Console.Write($"|{matrixArray[i, j]}\t|");
    }
    Console.WriteLine();
  }
}

int[,] FillMatrixArray(int[,] matrixArray)
{
  for (int i = 0; i < matrixArray.GetLength(0); i++)
  {
    for (int j = 0; j < matrixArray.GetLength(1); j++)
    {
      matrixArray[i, j] = new Random().Next(1, 11);
    }
  }
  return matrixArray;
}

int[,] SortMatrixArray(int[,] matrixArray)
{
  int[] sortArray = new int[matrixArray.GetLength(1)];
  for (int i = 0; i < matrixArray.GetLength(0); i++)
  {
    for (int j = 0; j < matrixArray.GetLength(1); j++)
    {
      sortArray[j] = matrixArray[i, j];
    }
    Array.Sort(sortArray);
    Array.Reverse(sortArray);
    for (int j = 0; j < matrixArray.GetLength(1); j++)
    {
      matrixArray[i, j] = sortArray[j];
    }
    // Console.Write($"[{string.Join(", ", sortArray)}\t]");
  }
  return matrixArray;
}

Console.Clear(); Console.Write("Введите размер массива через пробел N N: ");
int[] sizeArray = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
int[,] matrixArray = new int[sizeArray[0], sizeArray[1]];
PrintMatrixArray(FillMatrixArray(matrixArray));
Console.WriteLine();
PrintMatrixArray(SortMatrixArray(matrixArray));