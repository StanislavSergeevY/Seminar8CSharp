// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] FillMatrix(int[] arrayNumber, int sizeX, int sizeY)
{
  int steps = 0, outline = 0;
  int[,] rMatrix = new int[sizeX, sizeY];
  for (int i = 0; i < rMatrix.GetLength(0) - outline * 2; i++)
  {
    for (int columnPositive = outline; columnPositive < rMatrix.GetLength(1) - outline; columnPositive++)
    {
      rMatrix[outline, columnPositive] = arrayNumber[steps++];
      // Console.WriteLine($"1 For по столбам в Право | ЗНАЧЕНИЕ={steps} | СТРОКА={outline} | СТОЛБЕЦ={columnPositive} | - кол-во СТОЛБЦОВ = {rMatrix.GetLength(1)}");
    }
    for (int linePositive = outline + 1; linePositive < rMatrix.GetLength(0) - outline; linePositive++)
    {
      rMatrix[linePositive, rMatrix.GetLength(1) - outline -1] = arrayNumber[steps++];
      // Console.WriteLine($"2 For по строкам в Низ | ЗНАЧЕНИЕ={steps} | СТРОКА={linePositive} | СТОЛБЕЦ={outline -1} | - кол-во СТРОК = {rMatrix.GetLength(0)}");
    }
    for (int columNegative = rMatrix.GetLength(1) - outline -2; columNegative >= outline; columNegative--)
   {
      rMatrix[rMatrix.GetLength(0) - outline - 1, columNegative] = arrayNumber[steps++];
      // Console.WriteLine($"3 For по столбам в Лево | ЗНАЧЕНИЕ={steps} | СТРОКА={rMatrix.GetLength(0) - outline - 1} | СТОЛБЕЦ={columNegative} | - кол-во СТОЛБЦОВ = {rMatrix.GetLength(1)}");
    }
    for (int lineNegative = rMatrix.GetLength(0) - outline - 2; lineNegative > outline; lineNegative--)
    {
      rMatrix[lineNegative, outline] = arrayNumber[steps++];
      // Console.WriteLine($"4 For по строкам в Верх | ЗНАЧЕНИЕ={steps} | СТРОКА={lineNegative} | СТОЛБЕЦ={outline} | - кол-во СТРОК = {rMatrix.GetLength(0)}");
    }
    outline++;
  }
  return rMatrix;
}

int[] NumbersArray(int sizeX, int sizeY)
{
  int a0 = 0, a1 = 1, x;
  int[] array = new int[sizeX * sizeY];
  for (int i = 0; i < array.Length; i++)
  {
    array[i] = a0;
    x = a0 + a1;
    a0 = a1;
    a1 = x;
  }
  Array.Reverse(array);
  // Console.WriteLine($"{string.Join(", ", array)}");
  return array;
}

void PrintMatrix(int[,] matrix)
{
  for (int i1 = 0; i1 < matrix.GetLength(0); i1++)
  {
    for (int i2 = 0; i2 < matrix.GetLength(1); i2++)
    {
      Console.Write($"{matrix[i1, i2]}\t");
    }
    Console.WriteLine();
  }
}

Console.Clear(); Console.WriteLine("Вас приветствует спиральная матрица Фибоначчи!");
Console.Write("Выберите размер квадратной матрицы от 2 до 5: ");
int[] sizeArray = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
PrintMatrix(FillMatrix(NumbersArray(sizeArray[0], sizeArray[0]), sizeArray[0], sizeArray[0]));