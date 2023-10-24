using System;
using System.Linq;

namespace Lab_OOP_6
{
    class Program
    {
        //заполнение одномерного массива вручную
        static char[] CreateArrayManually(int len)
        {
            char[] arr = new char[len];
            for (int i = 0; i < len; i++)
                arr[i] = InputChar("Введите " + (i + 1) + " элемент массива: ");
            return arr;
        }
        //заполнение одномерного массива случайными элементами
        static char[] CreateArrayRandom(int len)
        {
            char[] arr = new char[len];
            Console.WriteLine("Введите диапазон задания случайных символов (a-z): ");
            char left = InputChar("Введите левую границу: ");
            char right = InputChar("Введите правую границу: ");
            Random rnd = new Random();
            byte[] bytes = new byte[100];
            for (int i = 0; i < len; i++)
            {
                rnd.NextBytes(bytes);
                arr[i] = Convert.ToChar(rnd.Next(left, right));
            }
            return arr;
        }
        //удаление из массива последней гласной буквы
        static char[] DeleteLastVowel(char[] arr)
        {
            int indexLastVowel = -1;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'y' || arr[i] == 'u' || arr[i] == 'o' || arr[i] == 'i')
                    indexLastVowel = i;
            }
            if (indexLastVowel == -1)
            {
                Console.WriteLine("Гласных нет");
                return arr;
            }
            char[] arrRes = new char[arr.Length - 1];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == indexLastVowel)
                    continue;
                arrRes[j] = arr[i];
                j++;
            }
            return arrRes;
        }
        //вывод на экран одномерного массива
        static void OutputArr(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }


        //создание строки - ввод с клавиатуры
        static string CreateString()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            return str;
        }
        //создание строки - заранее сформированный массив
        static string CreateStringDefault()
        {
            string[] arr = new string[10];
            arr[0] = "Привет. ";
            arr[1] = "Меня ";
            arr[2] = "зовут ";
            arr[3] = "Кирилл. ";
            arr[4] = "Мне ";
            arr[5] = "19 ";
            arr[6] = "лет. ";
            arr[7] = "Я ";
            arr[8] = "люблю ";
            arr[9] = "C#.";
            string str = String.Join("", arr);
            return str;
        }
        //Перестановка местами 1 и последнего предложения
        static string ReverseString(string str)
        {
            string strCopy = str.Substring(0, str.Length - 1);
            int[] indexs1 = new int[3];
            int[] indexs2 = new int[3];
            indexs1[0] = str.IndexOf(".");
            indexs2[0] = strCopy.LastIndexOf(".");
            indexs1[1] = str.IndexOf("!");
            indexs2[1] = strCopy.LastIndexOf("!");
            indexs1[2] = str.IndexOf("?");
            indexs2[2] = strCopy.LastIndexOf("?");
            indexs1[0] = (indexs1[0] == -1) ? (100) : (indexs1[0]);
            indexs1[1] = (indexs1[1] == -1) ? (100) : (indexs1[1]);
            indexs1[2] = (indexs1[2] == -1) ? (100) : (indexs1[2]);
            int indexPEQ1 = indexs1.Min();
            int indexPEQ2 = indexs2.Max();
            string substring1 = str.Substring(indexPEQ2 + 2, str.Length - indexPEQ2 - 2);
            string substring2 = str.Substring(indexPEQ1 + 1, indexPEQ2 - indexPEQ1 + 1);
            string substring3 = str.Substring(0, indexPEQ1 + 1);
            return (substring1 + substring2 + substring3);
        }
        //вывод строки
        static void OutputString(string str)
        {
            Console.WriteLine(str);
        }

        //проверка на ввод целого числа
        static int InputInt(string message)
        {
            int number;
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                do
                {
                    Console.WriteLine("Ошибка!");
                    Console.WriteLine("Введите число типа int: ");
                    Console.Write(message);
                } while (!int.TryParse(Console.ReadLine(), out number));
            }
            return number;
        }
        //проверка на ввод char символа
        static char InputChar(string message)
        {
            char number;
            Console.Write(message);
            if (!char.TryParse(Console.ReadLine(), out number))
            {
                do
                {
                    Console.WriteLine("Ошибка!");
                    Console.WriteLine("Введите одиночный символ (char): ");
                    Console.Write(message);
                } while (!char.TryParse(Console.ReadLine(), out number));
            }
            return number;
        }
        static void Main(string[] args)
        {
            string[] menu =
            {
                "1. Создание одномерного массива - char (заполнение вручную)\n",
                "2. Создание одномерного массива - char (заполнение ДСЧ)\n",
                "3. Удалить из массива последнюю гласную букву\n",
                "4. Вывод массива\n",
                "5. Создание строки - ввод с клавиатуры\n",
                "6. Заранее сформированный массив строк\n",
                "7. Поменять местами первое и последнее предложение в строке\n",
                "8. Вывод строки\n",
                "0. Выход\n",
            };
            int command = 0;
            int lenArr = 0;
            char[] arr = new char[lenArr];
            string str = "";
            do
            {
                //вывод меню
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine(menu[i]);
                }
                command = InputInt("\nВведите команду: ");
                switch(command)
                {
                    case 1: //Создание одномерного массива - char (заполнение вручную)
                        lenArr = InputInt("\nВведите размер массива: ");
                        while (lenArr < 0)
                            lenArr = InputInt("\nРазмер массива не может быть отрицательным! Введите размер массива: ");
                        arr = new char[lenArr];
                        arr = CreateArrayManually(lenArr);
                        OutputArr(arr);
                        break;
                    case 2: //Создание одномерного массива - char (заполнение ДСЧ)
                        lenArr = InputInt("\nВведите размер массива: ");
                        while (lenArr < 0)
                            lenArr = InputInt("\nРазмер массива не может быть отрицательным! Введите размер массива: ");
                        arr = new char[lenArr];
                        arr = CreateArrayRandom(lenArr);
                        OutputArr(arr);
                        break;
                    case 3: //Удалить из массива последнюю гласную букву
                        arr = DeleteLastVowel(arr);
                        OutputArr(arr);
                        break;
                    case 4: //Вывод массива
                        OutputArr(arr);
                        break;
                    case 5: //Создание строки - ввод с клавиатуры
                        str = CreateString();
                        break;
                    case 6: //Заранее сформированный массив строк
                        str = CreateStringDefault();
                        OutputString(str);
                        break;
                    case 7: //Поменять местами первое и последнее предложение в строке
                        str = ReverseString(str);
                        OutputString(str);
                        break;
                    case 8: //Вывод строки
                        OutputString(str);
                        break;
                    case 0: //Выход
                        Console.WriteLine("Спасибо, что пользуетесь нашим продуктом!");
                        break;
                    default:
                        Console.WriteLine("Неправильная команда");
                        break;
                }
                Console.WriteLine("_____________________________________\n");
                Console.ReadKey();
            } while (command != 0);
        }
    }
}
