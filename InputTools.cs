namespace lab9;

static class InputTools
{
   
    public static int ReadInt(string entryMessage, string errorMessage,int min = int.MinValue, int max = int.MaxValue)
    {
        /*  Функция для ввода, проверки и дальнейшего "отправления" целых чисел в код
         *  entryMessage - строчка, которую получает пользователь
         *  errorMessage - строчка, которую получает пользователь в случае ошибочного ввода
         *  min - автоматически стоит минимально возможное целое число, которое можно изменить для задавания одз
         *  max - автоматически стоит максимально возможное целое число, которое можно изменить для задавания одз
         */
        // константы для использования ниже
        int result = 0;
        string? buffer;
        bool isSuccess;
        do
        {
            Console.WriteLine(entryMessage);
            buffer = Console.ReadLine(); // ввод в буффер
            isSuccess = int.TryParse(buffer, out result); // проверка буффера
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            if (isSuccess) // проверка всех возможных ситуаций
            {
                if (result > min && result < max)
                {
                    Console.WriteLine("Успешный ввод!");
                }
                else
                {
                    Console.WriteLine($"Ошибка! Вводом должно быть число больше {min} и меньше {max}");
                }
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        } while (!isSuccess || !(result > min) || !(result < max)); // условие выхода из цикла
        return result; // возврат числа для функции для которой он был вызван
    }

    
    /*
     *  Абсолютно все то же самое, что и с предыдущим методом, однако, целые числа заменены на числа двойной точности
     */
    public static double ReadDouble(string entryMessage, string errorMessage, double min = double.MinValue,
        double max = double.MaxValue)
    {
        double result = 0;
        string? buffer;
        bool isSuccess;
        do
        {
            ClearLogs();
            Console.WriteLine(entryMessage);
            buffer = Console.ReadLine();
            isSuccess = double.TryParse(buffer, out result);
            if (isSuccess)
            {
                if (result > min && result < max)
                {
                    Console.WriteLine("Успешный ввод!");
                }
                else
                {
                    Console.WriteLine($"Ошибка! Вводом должно быть число больше {min} и меньше {max}");
                }
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        } while (!isSuccess || !(result > min) || !(result < max));
        return result;
    }

    public static void ClearLogs() // метод для удобной "чистки" консоли
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }

    public static void MenuOutputLine(string incomingMessage) // метод 
    {
        Console.WriteLine(incomingMessage);
    }

    public static void MenuOutputNotALine(string incomingMessage)
    {
        Console.Write(incomingMessage);
    }
}