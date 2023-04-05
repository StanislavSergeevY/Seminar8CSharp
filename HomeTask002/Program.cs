// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив: 1 4 7 2
//                         5 9 2 3
//                         8 4 2 4
//                         5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

void PrintMatrixArray(int[,] matrixArray)
{
  for (int i = 0; i < matrixArray.GetLength(0); i++)
  {
    Console.Write($"string index '{i}' - ");
    for (int j = 0; j < matrixArray.GetLength(1); j++)
    {
      Console.Write($"|{matrixArray[i, j]}\t|");
    }
    Console.WriteLine();
  }
}

int[,] GetAndFillMatrixArray()
{
  int[,] rectangleMatrixArray = new int[4, 6];
  for (int i = 0; i < rectangleMatrixArray.GetLength(0); i++)
    for (int j = 0; j < rectangleMatrixArray.GetLength(1); j++)
      rectangleMatrixArray[i, j] = new Random().Next(1, 11);
  return rectangleMatrixArray;
}

int[] GetArraySum(int[,] matrixArray)
{
  int[] sumArray = new int[matrixArray.GetLength(0)];
  for (int i = 0; i < matrixArray.GetLength(0); i++)
  {
    for (int j = 0; j < matrixArray.GetLength(1); j++)
    {
      sumArray[i] += matrixArray[i, j];
    }
    // Console.Write($"[{string.Join(", ", sumArray)}\t]"); // Проверка
    // Console.WriteLine(); // Проверка
  }
  return sumArray;
}

void PrintResult(int[] ArraySum)
{
  int str = 0;
  int MinSum = ArraySum[0];
  for (int i = 0; i < ArraySum.Length; i++)
  {
    if(ArraySum[i] < MinSum) str = i;
  }
  Console.Write($"Строка с индексом: {str}, содержит наименьшую сумму элементов.");
}

Console.Clear(); Console.WriteLine("приготовься увидеть чудо!");
int[,] rectangleMatrixArray = GetAndFillMatrixArray();
PrintMatrixArray(rectangleMatrixArray);
int[] ArraySum = GetArraySum(rectangleMatrixArray);
PrintResult(ArraySum);