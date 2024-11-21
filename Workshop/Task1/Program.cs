using System;

    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[]
            {
                new DivideByZeroException("Ошибка: Деление на ноль."),
                new ArgumentNullException("Ошибка: Аргумент не может быть null."),
                new IndexOutOfRangeException("Ошибка: Индекс был вне диапазона."),
                new InvalidOperationException("Ошибка: Недопустимая операция."),
                new MyCustomException("Ошибка: Это мое собственное исключение.")
            };

            foreach (var exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (MyCustomException ex)
                {
                    Console.WriteLine($"Обработано собственное исключение: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Обработано исключение деления на ноль: {ex.Message}");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Обработано исключение: {ex.Message}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Обработано исключение выхода за границы: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Обработано исключение недопустимой операции: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Блок finally выполнен.\n");
                }
            }
        }
    }