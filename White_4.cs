using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static LAB_6.White_3;

namespace LAB_6
{
    internal class White_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _scores;
            private int _count;

            public string Surname => _surname;
            public string Name => _name;
            public double[] Scores => _scores;
            public double TotalScores => _scores.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];
                _count = 0;
            }
            public void PlayMatch(double result)
            {
                double[] temp = new double[_scores.Length+1];
                for(int i = 0;i < _scores.Length; i++)
                {
                    temp[i] = _scores[i];
                }
                temp[temp.Length-1] = result;
                _scores = temp;
            }
            public static void Sort(Participant[] array)
            {
                int length = array.Length;
                for (int i = 0; i < length - 1; i++)
                {
                    for (int j = 0; j < length - i - 1; j++)
                    {
                        if (array[j].TotalScores < array[j + 1].TotalScores)
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
                Console.WriteLine($"{Surname} {Name}, кол-во баллов {TotalScores}");
            }
        }
    }
}
