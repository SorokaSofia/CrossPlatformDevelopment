using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Library;

class Program
{
    static void Main(string[] args)
    {
        var app = new CommandLineApplication();
        app.HelpOption(inherited: true);

        // Команда "version" для виведення інформації про програму
        app.Command("version", cmd =>
        {
            cmd.Description = "Display version information";
            cmd.OnExecute(() =>
            {
                Console.WriteLine("Автор: Сорока Софія");
                Console.WriteLine("Версія: 1.0.0");
            });
        });

        // Команда "run" для запуску відповідної лабораторної роботи
        app.Command("run", cmd =>
        {
            cmd.Description = "Run a specific lab";
            var labOption = cmd.Argument("lab", "The lab to run (lab1, lab2, lab3)").IsRequired();
            var inputOption = cmd.Option("-I|--input <FILE>", "Input file path", CommandOptionType.SingleValue);
            var outputOption = cmd.Option("-o|--output <FILE>", "Output file path", CommandOptionType.SingleValue);

            cmd.OnExecute(() =>
            {
                string inputFile = GetFilePath(inputOption.Value(), "INPUT.TXT");
                string outputFile = GetFilePath(outputOption.Value(), "OUTPUT.TXT");

                switch (labOption.Value.ToLower())
                {
                    case "lab1":
                        new Lab1Runner().Run(inputFile, outputFile);
                        break;
                    case "lab2":
                        new Lab2Runner().Run(inputFile, outputFile);
                        break;
                    case "lab3":
                        new Lab3Runner().Run(inputFile, outputFile);
                        break;
                    default:
                        Console.WriteLine("Invalid lab specified.");
                        break;
                }
            });
        });

        // Команда "set-path" для встановлення шляху до файлів
        app.Command("set-path", cmd =>
        {
            cmd.Description = "Set path for lab files";
            var pathOption = cmd.Option("-p|--path <PATH>", "Specify the path to lab files", CommandOptionType.SingleValue).IsRequired();

            cmd.OnExecute(() =>
            {
                if (pathOption.HasValue())
                {
                    var path = pathOption.Value();
                    Environment.SetEnvironmentVariable("LAB_PATH", path);
                    Console.WriteLine($"Шлях встановлено: {path}");
                }
                else
                {
                    Console.WriteLine("Шлях не задано.");
                }
            });
        });

        // Запуск програми з переданими аргументами
        app.OnExecute(() =>
        {
            Console.WriteLine("Будь ласка, використовуйте одну з команд:");
            Console.WriteLine("  version - Вивести інформацію про програму");
            Console.WriteLine("  run <lab1|lab2|lab3> [--input <файл>] [--output <файл>] - Запустити лабораторну роботу");
            Console.WriteLine("  set-path -p <шлях> - Встановити шлях до папки з файлами");
            return 1;
        });

        app.Execute(args);
    }

    // Метод для визначення шляху до файлів з пріоритетом
    static string GetFilePath(string specifiedPath, string defaultFileName)
    {
        if (!string.IsNullOrEmpty(specifiedPath) && File.Exists(specifiedPath))
        {
            return specifiedPath;
        }

        var labPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (!string.IsNullOrEmpty(labPath))
        {
            var envFilePath = Path.Combine(labPath, defaultFileName);
            if (File.Exists(envFilePath))
            {
                return envFilePath;
            }
        }

        var userHomePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), defaultFileName);
        if (File.Exists(userHomePath))
        {
            return userHomePath;
        }

        Console.WriteLine($"Помилка: файл {defaultFileName} не знайдено.");
        Environment.Exit(1);
        return null;
    }
}
