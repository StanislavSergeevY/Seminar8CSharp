// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// ####################
// ## МОИ КОСТЫЛИ ;) ##
// ####################
int[] DataArray(int min, int max, int x, int y, int z) // Генератор неповторяющихся двузначных чисел
{
  bool logics;              // передаёт логику проверки случайных чисел
  int flag = 0;             // управляет счётчиком проверки числе массива
  int bufferNumber = 0;     // служит для проверки логики
  int randomNumber = 0;     // запоминает последнее случайное число

  int[] arrayRandomNumber = new int[x * y * z];
  for (int i = 0; i < arrayRandomNumber.Length; i++)
  {
    randomNumber = new Random().Next(min, max);
    for (int sort = 0; sort < arrayRandomNumber.Length; sort++)
    {
      if (flag == 1)
      {
        flag = 0;
        sort = 0;
      }
      if (arrayRandomNumber[sort] == randomNumber)
      {
        logics = arrayRandomNumber[sort] == randomNumber;
        while (logics == true)
        {
          bufferNumber = randomNumber;
          randomNumber = new Random().Next(min, max);
          logics = bufferNumber == randomNumber; // проверка, на самое число должен вернуть "False" что бы завершить итерацию
          flag = 1; // обнулят счётчика после замены числа, что бы убедиться, что новое число не использовалось ранее
        }
      }
    }
    arrayRandomNumber[i] = randomNumber; // по итогу проверок помещает в массив уникальное число
  }
  // Array.Sort(arrayRandomNumber); // не требуется
  // Console.WriteLine($"{string.Join(", ", arrayRandomNumber)}"); // не требуется
  return arrayRandomNumber;
}

int[,,] GetFillMatrix3D(int[] arrayNumbers, int x, int y, int z)
{
  int i = 0;
  int[,,] matrix3D = new int[x, y, z];
  for (int i1 = 0; i1 < matrix3D.GetLength(0); i1++)
  {
    for (int i2 = 0; i2 < matrix3D.GetLength(1); i2++)
    {
      for (int i3 = 0; i3 < matrix3D.GetLength(2); i3++)
      {
        matrix3D[i1, i2, i3] = arrayNumbers[i++];
      }
    }
  }
  return matrix3D;
}

void PrintMatrix3D(int[,,] matrix3D)
{
  for (int i1 = 0; i1 < matrix3D.GetLength(0); i1++)
  {
    for (int i2 = 0; i2 < matrix3D.GetLength(1); i2++)
    {
      for (int i3 = 0; i3 < matrix3D.GetLength(2); i3++)
      {
        Console.Write($"| {matrix3D[i1, i2, i3]}({i1},{i2},{i3}) |");
      }
      Console.WriteLine();
    }
  }
}

Console.Clear(); Console.Write("Введите размер трёхмерного массива через пробел X Y Z: ");
int[] sizeMatrix3D = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
int min = 10, max = 100;  // диапазон генератора случайных чисел
int[] arrayNumber = DataArray(min, max, sizeMatrix3D[0], sizeMatrix3D[1], sizeMatrix3D[2]);
int[,,] Matrix3D = GetFillMatrix3D(arrayNumber, sizeMatrix3D[0], sizeMatrix3D[1], sizeMatrix3D[2]);
PrintMatrix3D(Matrix3D);