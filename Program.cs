using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            // Сообщение-приветствией при запуске программы. 
            Console.WriteLine("Консольный калькулятор 1.0\n");
        // Метка, которая служит для обнуления переменных, после ввода знака равенства.
        MetkaReset:
            // Ввод первого числа для его последующей конвертации к типу double.
            string StrNumber;
            // Ввод второго числа для его последующей конвертации к типу double, задана с пустым символом, чтобы компилятор не ругался.
            string StrNumber2 = "";
            // Конвертированная переменная для подсчётов и вторичного использования при подсчете нескольких действий.
            double DoobleNumber;
            // Конвертированная переменная для подсчётов и постоянного изменения для работы нескольких действий.
            double DoobleNumber2;
            // Переменная для записи операции над числом, используется, как ввод операций */+-=.
            string Operation;
            // Переменная для вывода результата на экран пользователя и подсчета результата, текст задан для того, чтобы компилятор не ругался, а так же можно было вывести нужное сообщение.
            string Result = "Нет результата";


        // Метка, которая вызывается в случае неправильного ввода первого числа.
        NoSimbol:
            // Проверка ввода первого числа на цифры.
            try
            {
                // Запрос ввода числа у пользователя.
                Console.WriteLine("Введите число");
                // Ввод первого числа с клавиатуры и запись в переменную для последующих операций.
                StrNumber = Console.ReadLine();
                // Конвертация переменной в длинный числовой тип.
                DoobleNumber = Convert.ToDouble(StrNumber);

            }
            catch
            {
                // Вывод ошибки при наличии непредусмотренных для ввода символов.
                Console.WriteLine("Вы ввели символ, который не поддерживается, пожалуйста, введите числовое значение.");
                // Переход к метке для повторного ввода числа.
                goto NoSimbol;
            }
        // Метка, которая служит для повторного ввода операции над числом или продолжения действия.
        NoOperation:
            // Запрос ввода операции у пользователя.
            Console.WriteLine("Введите операцию (+-*/=):");
            // Сохранение переменной при вводе с клавиатуры в переменную для последующего использования.
            Operation = Console.ReadLine();
            // Проверка переменной операции на правильность ввода.
            switch (Operation)
            {
                case "+":
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
                case "=":
                    // Проверка на ввод первого числа, при условии отстутствия второго, ввиду чего
                    if (StrNumber2 == "")
                    {
                        Console.WriteLine("Вы не ввели второе число, поэтому результат равен первому числу.\nКонечный результат: " + DoobleNumber);
                        goto MetkaReset;
                    }
                    break;
                default:
                    // Вывод сообщения о недопустимой операции, если введена не та операция.
                    Console.WriteLine("Недопустимая операция");
                    // Возвращение на метку ввода операции.
                    goto NoOperation;
            }
        // Метка для возвращения на ввод второго числа
        NoSymbol2:
            // Проверка ввода
            try
            {
                if (Operation == "=")
                {
                    goto MetkaRavenstvo;
                }
                // Запрос ввода второго числа
                Console.WriteLine("Введите cледующее число");
                // Сохранение ввода с клавиатуры
                StrNumber2 = Console.ReadLine();
                // Перевод числа в численные
                DoobleNumber2 = Convert.ToDouble(StrNumber2);
            }
            catch
            {
                // Вывод об ошибке
                Console.WriteLine("Вы ввели букву или символ вместо числа, повторите попытку.");
                // Возвращение к метке ввода второго числа
                goto NoSymbol2;
            }
            // Операция над числами
            switch (Operation)
            {
                case "+":
                    {
                        // Сохранение результата
                        Result = Convert.ToString(DoobleNumber + DoobleNumber2);
                        // Вывод предварительного результата
                        Console.WriteLine("Результат: " + DoobleNumber + "+" + DoobleNumber2 + "=" + Result);
                        // Сохранение результата в первую переменную
                        DoobleNumber = Convert.ToDouble(Result);
                    }
                    break;
                case "-":
                    {
                        // Сохранение результата
                        Result = Convert.ToString(DoobleNumber - DoobleNumber2);
                        // Вывод предварительного результата
                        Console.WriteLine("Результат: " + DoobleNumber + "-" + DoobleNumber2 + "=" + Result);
                        // Сохранение результата в первую переменную
                        DoobleNumber = Convert.ToDouble(Result);
                    }
                    break;
                case "/":
                    // Проверка на нуль.
                    if (DoobleNumber2 != 0)
                    {
                        // Сохранение результата
                        Result = Convert.ToString(DoobleNumber / DoobleNumber2);
                        // Вывод предварительного результата
                        Console.WriteLine("Результат: " + DoobleNumber + "/" + DoobleNumber2 + "=" + Result);
                        // Сохранение результата в первую переменную
                        DoobleNumber = Convert.ToDouble(Result);
                    }
                    else
                    {
                        // Вывод об ошибке в случае деления на нуль.
                        Console.WriteLine("Деление на ноль недопустимо");
                        // Возвращение к вводу операции
                        goto NoOperation;
                    }
                    break;
                case "*":
                    // Сохранение результата
                    Result = Convert.ToString(DoobleNumber * DoobleNumber2);
                    // Вывод предварительного результата
                    Console.WriteLine("Результат: " + DoobleNumber + "*" + DoobleNumber2 + "=" + Result);
                    // Сохранение результата в первую переменную
                    DoobleNumber = Convert.ToDouble(Result);
                    break;
                default:
                    break;
            }
        MetkaRavenstvo:
            // Проверка ввода на равенство
            if (Operation == "=")
            {
                // Вывод результата
                Console.WriteLine("Окончательный результат:" + Result);
                // Возвращает на метку для обнуления всех переменных и очищения памяти от мусора..
                goto MetkaReset;
            }
            // Возвращение к вводу операции для следующего действия
            goto NoOperation;
        }
    }
}
