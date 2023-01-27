using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHardTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            Console.WriteLine("Введите номер задания(1, 2(пункт a) и 3(пункт б)): ");
            int numTask = int.Parse(Console.ReadLine());
            switch (numTask)
            {
                case 1:
                    Console.WriteLine("Задача 1: Человек шел со скоростью 3 км/ч вдоль трамвайной линии и считал трамваи.\n" +
                "И те, которые двигались ему на встречу, и те, которые обгоняли его. Человек насчитал 40 трамваев, обгонявших его, и 60 встречных.\n" +
                "Предположим, что трамваи движутся равномерно, с одинаковыми интервалами между собой (в задаче это вполне возможно)\n" +
                "Какова средняя скорость движения трамваев?");
                    Console.Write("Введите сколько трамваев двигались на встречу человеку: ");
                    float numberMeetTrum = float.Parse(Console.ReadLine());
                    Console.Write("Введите сколько трамваев обгоняли человека: ");
                    float numberOutrunTram = float.Parse(Console.ReadLine());
                    Console.Write("Введите скорость с которой шёл человек: ");
                    float speedHuman = float.Parse(Console.ReadLine());
                    Console.WriteLine("Скорость трамваев: " + TaskOne.SpeedTram(speedHuman, numberMeetTrum, numberOutrunTram) + "км/ч");
                    break;
                    //насчёт корреляции Спирмена- очень интересно и непонятно.. было пока не нашел дедка на ютубе который за шесть минут рассказал про корреляцию(мог и за 5 минут, но зато я теперь знаю что Спирмен был психолог, а не математик)
                    //сама программа - мне помог максим ночевный, ну и мной она была переделанна , для моих нужд
                    //саммая сложность , это сортировки , находящиеся в другом классе , ну вобщем вот так 
                case 2:
                    Console.WriteLine("Имеется корреляция Спирмена... с существующими данными");
                    Console.WriteLine("Численность исследуемой группы равна 7 ");
                    int staticGroupSize = 7;
                    double t_one = 0, t_b_one = 0, S_one = 0, Rs_one = 0;

                    SpearmanCorrelation.Variables[] a_one = new SpearmanCorrelation.Variables[staticGroupSize];
                    for (int i = 0; i < staticGroupSize; i++)
                    {
                        a_one[i] = new SpearmanCorrelation.Variables();
                    }
                    SpearmanCorrelation.Sort_Rank sortRank_one = new SpearmanCorrelation.Sort_Rank(); // экземпляр класса для сортировки рангов
                    //заполняется 2 массива
                    a_one[0].x = 123;
                    a_one[0].y = 134;
                    a_one[1].x = 142;
                    a_one[1].y = 142;
                    a_one[2].x = 125;
                    a_one[2].y = 163;
                    a_one[3].x = 154;
                    a_one[3].y = 127;
                    a_one[4].x = 133;
                    a_one[4].y = 142;
                    a_one[5].x = 119;
                    a_one[5].y = 155;
                    a_one[6].x = 148;
                    a_one[6].y = 120;
                    //выводится массив
                    for (int i = 0; i < staticGroupSize; i++)
                    {
                        Console.WriteLine(a_one[i].x + "   " + a_one[i].y);
                    }

                    // сортировки массива и рангов 
                    sortRank_one.QuickX(0, staticGroupSize - 1, ref a_one);
                    sortRank_one.RankX(staticGroupSize - 1, ref t_one, ref a_one);
                    sortRank_one.QuickY(0, staticGroupSize - 1, ref a_one);
                    sortRank_one.RankY(staticGroupSize - 1, ref t_b_one, ref a_one);
                    // находится "число" Спирмена(из видео на ютубе: если оно равно 0 , то корреляция равноа 1(тоесть всё чётко)) 
                    for (int i = 0; i < staticGroupSize; i++)
                    {
                        a_one[i].dr = Math.Pow(a_one[i].rx - a_one[i].ry, 2);
                        Console.WriteLine("{0:f4}", a_one[i].dr);
                        S_one = S_one + a_one[i].dr;
                    }
                    Console.WriteLine("S=" + S_one);
                    //ну и ответ по формуле, которая в задании
                    Rs_one = 1 - 6 * (S_one + t_one + t_b_one) / (staticGroupSize * (staticGroupSize * staticGroupSize - 1));
                    Console.WriteLine("Rs = {0:f10}", Rs_one);
                    break;

                case 3:
                    Console.WriteLine("Имеется корреляция Спирмена... с данными которые надо вводить" );
                    Console.Write("Введите численность исследуемой группы: "); 
                    int studyGroupSize = int.Parse(Console.ReadLine()); // чиcло сколько будет строчек в массиве
                    double t_a =0 , t_b = 0 , S = 0 , Rs;

                   SpearmanCorrelation.Variables[] a = new SpearmanCorrelation.Variables[studyGroupSize];

                    for (int i = 0; i < studyGroupSize; i++)
                    {
                        a[i] = new SpearmanCorrelation.Variables();
                    }

                   SpearmanCorrelation.Sort_Rank sortRank = new SpearmanCorrelation.Sort_Rank(); // экземпляр класса для сортировки рангов

                    for (int i = 0; i < studyGroupSize; i++)
                    {
                        Console.Write("Enter a[" + (i + 1) + "].x = ");
                        a[i].x = Double.Parse(Console.ReadLine());
                        Console.Write("Enter a[" + (i + 1) + "].y = ");
                        a[i].y = Double.Parse(Console.ReadLine());
                    }


                    sortRank.QuickX(0, studyGroupSize - 1, ref a);
                    sortRank.RankX(studyGroupSize - 1, ref t_a, ref a);
                    sortRank.QuickY(0, studyGroupSize - 1, ref a);
                    sortRank.RankY(studyGroupSize - 1, ref t_b, ref a);
                   
                    for (int i = 0; i <studyGroupSize; i++)
                    {
                        a[i].dr = Math.Pow(a[i].rx - a[i].ry, 2);
                        S = S + a[i].dr;
                    }
                    Console.WriteLine("S=" + S);

                    Rs = 1 - 6 * (S + t_a + t_b) / (studyGroupSize * (studyGroupSize * studyGroupSize - 1));
                    Console.WriteLine("Rs = {0:f10}", Rs);
                    break;
               
            }
            Console.ReadKey();
            
            
        }
       


    }
}
