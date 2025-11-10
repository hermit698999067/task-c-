using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите команду в формате: calc-cli <операция> <a> <b>");
        Console.WriteLine("Для справки: calc-cli --help");
        Console.WriteLine("Для выхода напишите: exit\n");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (input == null)
                continue;

            input = input.Trim().ToLower();

            if (input == "exit")
                break;

            if (input == "calc-cli --help")
            {
                ShowHelp();
                continue;
            }

            string[] args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (args.Length != 4 || args[0] != "calc-cli")
            {
                Console.WriteLine("Ошибка: используйте формат: calc-cli <операция> <a> <b>");
                Console.WriteLine("Введите calc-cli --help для справки.\n");
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
                case "pow": result = Math.Pow(a, b); break;
                default:
                    Console.WriteLine($"Ошибка: неизвестная операция '{operation}'.");
                    continue;
            }

            Console.WriteLine($"Результат: {result}\n");
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("\n=== Справка по Calc-CLI ===");
        Console.WriteLine("Формат команды:");
        Console.WriteLine("  calc-cli <операция> <a> <b>");
        Console.WriteLine("");
        Console.WriteLine("Доступные операции:");
        Console.WriteLine("  add   — сложение");
        Console.WriteLine("  sub   — вычитание");
        Console.WriteLine("  mul   — умножение");
        Console.WriteLine("  div   — деление");
        Console.WriteLine("  pow   — возведение в степень");
        Console.WriteLine("");
        Console.WriteLine("Примеры использования:");
        Console.WriteLine("  calc-cli add 2 3      -> 5");
        Console.WriteLine("  calc-cli sub 10 4     -> 6");
        Console.WriteLine("  calc-cli mul 4 5      -> 20");
        Console.WriteLine("  calc-cli div 10 2     -> 5");
        Console.WriteLine("  calc-cli pow 2 10     -> 1024");
        Console.WriteLine("");
        Console.WriteLine("Дополнительно:");
        Console.WriteLine("  Встроенная помощь по dotnet:");
        Console.WriteLine("     dotnet --help");
        Console.WriteLine("");
        Console.WriteLine("  Документация C#: https://learn.microsoft.com/dotnet/csharp/");
        Console.WriteLine("===============================\n");
    }
}
