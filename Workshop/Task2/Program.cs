using System;
using System.Collections.Generic;
using System.Linq;


    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class NameSorter
    {
        public event EventHandler<List<string>> NamesSorted;

        public void SortNames(List<string> names, int sortOrder)
        {
            if (sortOrder == 1)
            {
                names.Sort();
            }
            else if (sortOrder == 2)
            {
                names.Sort((x, y) => string.Compare(y, x));
            }
            else
            {
                throw new InvalidInputException("Некорректный выбор. Введите 1 или 2.");
            }

            NamesSorted?.Invoke(this, names);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> surnames = new List<string> { "Иванов", "Смирнов", "Кузнецов", "Петров", "Сидоров" };
            NameSorter nameSorter = new NameSorter();

            nameSorter.NamesSorted += (sender, sortedNames) =>
            {
                Console.WriteLine("Список фамилий после сортировки:");
                foreach (var name in sortedNames)
                {
                    Console.WriteLine(name);
                }
            };

            int sortOrder = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("\nВведите 1 для сортировки по возрастанию (А-Я) или 2 для сортировки по убыванию (Я-А):");
                    string input = Console.ReadLine();
                    sortOrder = int.Parse(input);

                    nameSorter.SortNames(surnames, sortOrder);
                    break; 
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите числовое значение!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Попробуйте снова.\n");
                }
            }
        }
    }