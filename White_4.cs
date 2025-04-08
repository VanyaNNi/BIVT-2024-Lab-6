using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _scores;

            public string Surname => _surname;
            public string Name => _name;
            public double[] Scores
            {
                get
                {
                    if (_scores == null)
                        return new double[0];
                    double[] copy_scores = new double[_scores.Length];
                    for(int i = 0; i < copy_scores.Length; i++)
                    {
                        copy_scores[i] = _scores[i];
                    }
                    return copy_scores;
                }
            }
            public double TotalScore => _scores == null || _scores.Length == 0 ? 0 : _scores.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];
            }
            public void PlayMatch(double result)
            {
                if (_scores == null)
                    _scores = new double[0];
                double[] temp = new double[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    temp[i] = _scores[i];
                }
                temp[temp.Length - 1] = result;
                _scores = temp;
            }
            public static void Sort(Participant[] array)
            {
                int length = array.Length;
                for (int i = 0; i < length - 1; i++)
                {
                    for (int j = 0; j < length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
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
                Console.WriteLine($"{Surname} {Name}, кол-во баллов {TotalScore}");
            }
        }
    }
}
