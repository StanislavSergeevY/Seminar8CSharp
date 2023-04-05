// +ЗАДАНИЕ. Написать функцию Sqrt(x) - квадратного корня,
// которая принимает на вход целочисленное значение х и возвращает целую часть
//  квадратного корня от введенного числа.
// 4 -> 2
// 28-> 5

int Sqrt(int x)
{
  int result = 0; 
  for (int i = 1; i <= x; i+=2)
  {
    x -= i;
    result++;
  }
  return result;
}

Console.Clear(); Console.Write("Введите значение для извлечения из него квадратного корня: ");
int x = int.Parse(Console.ReadLine());
Console.WriteLine($"Квадратный корень из числа {x} = {Sqrt(x)}");