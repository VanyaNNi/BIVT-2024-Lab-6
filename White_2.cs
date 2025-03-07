using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    internal class White_2
    {
        public struct Participant
        {
            private readonly string _name;
            private readonly string _surname;
            private double _firstjump;
            private double _secondjump;

            public string Name => _name;
            public string Surname => _surname;
            public double FirstJump => _firstjump;
            public double SecondJump => _secondjump;
            public double BestJump => Math.Max(_firstjump, _secondjump);

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstjump = 0;
                _secondjump = 0;
            }
            public void Jump(double result)
            {
                if (FirstJump == 0) _firstjump = result;
                else if (SecondJump == 0) _secondjump = result;

            }
            public static void Sort(Participant[] array)
            {
                int length = array.Length;
                for (int i = 0; i < length - 1; i++)
                {
                    for (int j = 0; j < length - i - 1; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Surname} {Name}, лучший из 2 прыжков - {BestJump}");
            }
        }
    }
}
