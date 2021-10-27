using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinosaal_Blinov
{
    class Program
    {
        public static int Saali_suurus()
        {
            Console.WriteLine("Razmer Zala [1,2,3]");//Записывает указанные мною данные размера зала(1,2,3)
            int a = int.Parse(Console.ReadLine());//Статический метод, который преобразует переменную типа строка в целое число.
            return a;//возвращает переменную a
        }
        static int[,] saal = new int[,] { };//матрица будет прорисовываться между целыми числами
        static int kohad, read;//int хранит пременные места и ряды
        public static void Saali_taitmine(int a)//Я использую void в качестве возвращаемого типа метода, чтобы указать, что метод не возвращает значение.В данном случае переменной a
        {
            Random rnd = new Random();//Класс Random используется для создания чисел random.
            if (a == 1)//если a==1,тогда мест 15,а рядов 10. Создаем двухмерные массивы
            {
                kohad = 15;
                read = 10;

            }
            else if (a == 2)//если a== 2,тогда мест 30,а рядов 20
            {
                kohad = 30;
                read = 20;
            }
            else//если a== 2,тогда мест 40,а рядов 26
            {
                kohad = 40;
                read = 26;
            }
            saal = new int[read, kohad];//new int выделяет память для обьектов ряды и места

            for (int rida = 0; rida < read; rida++)//создаем цикл for,который работает через random и подсчитывает какое место будет для нас выбрано
            {
                for (int koht = 0; koht < kohad; koht++)//создаем цикл for,если место меньше мест,тогда добавляет места
                {
                    saal[rida, koht] = rnd.Next(0, 2);//метод rnd next генерирует новые значения мест и рядов
                }
            }

        }
        public static void Saal_ekraanile()
        {
            Console.Write("     ");//Выводит число мест на экран
            for (int koht = 0; koht < kohad; koht++)//Создаем цикл for,где на основе того какой ряд мы хотим подсчитывает какие места свободны
            {
                if (koht.ToString().Length == 2)//возвращает количество значений в строке,в данном случае значение 2
                { Console.Write(" {0}", koht + 1); }
                else
                { Console.Write("  {0}", koht + 1); }
            }

            Console.WriteLine();
            for (int rida = 0; rida < read; rida++)
            {
                Console.Write("Rida " + (rida + 1).ToString() + ": ");
                for (int koht = 0; koht < kohad; koht++)
                {

                    Console.Write(saal[rida, koht] + "  ");
                }
                Console.WriteLine();//Метод WriteLine записывает указанные данные в выходной поток
            }

        }
        static bool Muuk_ise()//Выбор ряда
        {
            Console.WriteLine("Rida:");

            int pileti_rida = int.Parse(Console.ReadLine());
            Console.WriteLine("koht:");
            int pileti_koht = int.Parse(Console.ReadLine());
            bool b = false;
            if (saal[pileti_rida - 1, pileti_koht - 1] == 0)//Цикл if зал,билеты мест и билеты рядов=0 и =1
            {
                saal[pileti_rida - 1, pileti_koht - 1] = 1;
                Console.WriteLine("sinu koht on broneeritud");
                b = true;
            }
            else if (saal[pileti_rida - 1, pileti_koht - 1] == 1)
            {
                Console.WriteLine("Sinu koht ostatud. Valige teine koht");
                b = false;
            }
            return b;


        }
        static bool Muuk()//здесь я организую продажу билетов и выбор ряда,а также количество либо занятых либо свободных мест
        {
            Console.WriteLine("sisesta rida");//Пишим желаемый ряд
            int rida1 = int.Parse(Console.ReadLine());//подсчитывает ряд,после чего спрашивает сколько билетов я желаю
            Console.WriteLine("mitu piletid:");//Сколько билетов
            int mitu = int.Parse(Console.ReadLine());//Сколько билетов выводит в целое число при помощью int porse
            int mitu_veel = mitu;//выделяет память для обьекта сколько(mitu)
            int[] ost = new int[mitu];
            int p = (kohad - mitu) / 2;//выводит с помощью подсчета сколько мест занято
            bool t = false;//возвращает логическое значение t,если выражение ложно
            int k = 0;
            do
            {
                if (saal[rida1, p] == 0)//Создаем функцию if чтобы подсчитать сколько мест свободно
                {
                    ost[k] = p;
                    Console.WriteLine($"Koht {p} on vaba");//пишет сколько мест свободно
                    t = true;//t=верному значению
                }
                else
                {
                    Console.WriteLine($"Koht {p} on kinni");//пишет сколько мест занято
                    t = false;
                    ost = new int[mitu];
                    k = 0;
                    p = (kohad - mitu) / 2;//на основе подсчета выводит сколько мест занято
                    break;//С помощью оператора break можно специально организовать немедленный выход из цикла в обход любого кода
                }
                p++;
                k++;
            } while (mitu != k);//оператор while если количество не равняется k
            if (t == true)//если t равняется верному значению
            {
                Console.WriteLine("Sinu kohad on: ");//На основе желаемого ряда показывает какие места в наличии
                foreach (var koh in ost)//foreach делает циклическое обращение  обьявляя переменную мест в ost
                {
                    Console.WriteLine("{0}\n", koh);//выводит какие моими места являются на основе подсчета которые мы произвели
                }
            }
            else
            {
                Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");
            }
            return t;

        }
        static void Main(string[] args)
        {
            int suurus = Saali_suurus();//хранит целое значение suurus приравнивая его к saali_suurus
            Saali_taitmine(suurus);
            while (true)//оператор while принимает выражения saal_ekraanile и muuk и выполняет тело цикла
            {//выражения принимают значения true
                Saal_ekraanile();
                Console.WriteLine("1-ise valik, 2-masina valik");//машинный или автоматический выбор и собственный выбор
                int valik = int.Parse(Console.ReadLine());
                if (valik == 1)
                {
                    int koh = 0;
                    Console.WriteLine("Mittu piletid tahad osta?");//Сколько билетов хотите купить?
                    int kogus = int.Parse(Console.ReadLine());
                    bool a = false;
                    while (a != true)
                    {

                        for (int i = 0; i < kohad * read; i++)
                        {
                            a = Muuk_ise();
                            if (a) { koh++; }
                            if (koh == kogus) { break; }
                        }
                    }
                }
                else
                {
                    bool b = false;
                    while (b != true)
                    {
                        b = Muuk();
                    }
                    break;
                }
                Console.ReadKey();//считывает символы и выводит их на экран

            }

        }
    }
}
