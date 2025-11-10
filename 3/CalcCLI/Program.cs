using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите команду в формате: calc-cli <операция> <a> <b>");
        Console.WriteLine("Пример: calc-cli add 2 3");
        Console.WriteLine("Для выхода напишите: exit\n");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (input == null || input.Trim().ToLower() == "exit")
                break;

            string[] args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (args.Length != 4 || args[0] != "calc-cli")
            {
                Console.WriteLine("Ошибка: используйте формат: calc-cli <операция> <a> <b>");
                continue;
            }

            string operation = args[1];

            if (!double.TryParse(args[2], out double a) || !double.TryParse(args[3], out double b))
            {
                Console.WriteLine("Ошибка: аргументы <a> и <b> должны быть числами.");
                continue;
            }

            double result;

            switch (operation)
            {
                case "add": result = a + b; break;
                case "sub": result = a - b; break;
                case "mul": result = a * b; break;
                case "div":
                    if (b == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль.");
                        continue;
                    }
                    result = a / b;
                    break;
                case "pow":
                    result = Math.Pow(a, b);
                    break;
                default:
                    Console.WriteLine($"Ошибка: неизвестная операция '{operation}'.");
                    continue;
            }

            Console.WriteLine($"Результат: {result}\n");
        }
    }
}
