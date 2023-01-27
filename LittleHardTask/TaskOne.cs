using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHardTask
{
    public class TaskOne
    {
        public static float SpeedTram(float speedHuman, float numberOutrunTram, float numberMeetTrum) // метод находит скорость трамваев по ультро сложной формуле... 
        {
            float nod = NOD(numberMeetTrum, numberOutrunTram);
            float speedTram = ((numberMeetTrum / nod) + (numberOutrunTram / nod)) * speedHuman;
            return speedTram; //и возвращает уже ответ 

        }
        // Решил сделать программу более гибкой(хоть вы и говорили, что не надо), и самое главное - это надо было найти наибольший общий делитель,
        // для решения уровнения, но я удачно зашел в интернет и нашел))(сам думать над таким было тяжко для моего ума), но в принципе трудного в этом нет ничего
        static float Min(float x, float y) // метод находит минимальное число(принимает кол-во встречных и обгоняющих трамваев)
        {
            return x < y ? x : y; // тернарный условный оператор. БОМ БОМ , всё четко и понятно 
        }
        static float Max(float x, float y)// метод находит максимальное число(принимает кол-во встречных и обгоняющих трамваев)
        {
            return x > y ? x : y;
        }
        static float NOD(float a, float b) // метод находит наибольший общий делитель
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                var min = Min(a, b);
                var max = Max(a, b);

                return NOD(max - min, min);
            }
        }

    }
}
