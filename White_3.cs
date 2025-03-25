using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_3
    {
        public struct Student
        {
            private readonly string _surname;
            private readonly string _name;
            private int[] _marks;
            private int _skipped;

            public string Surname => _surname;
            public string Name => _name;
            public int Skipped => _skipped;
            public double AvgMark => _marks.Length == 0 ? 0 : Math.Round(_marks.Sum() / Convert.ToDouble(_marks.Length), 2);

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }

            public void Lesson(int mark)
            {
                if (mark == 0) _skipped++;
                else
                {
                    int[] temp = new int[_marks.Length + 1];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        temp[i] = _marks[i];
                    }
                    temp[temp.Length - 1] = mark;
                    _marks = temp;
                }
            }
            public static void SortBySkipped(Student[] array)
            {
                int length = array.Length;
                for (int i = 0; i < length - 1; i++)
                {
                    for (int j = 0; j < length - i - 1; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Surname} {Name} средний балл: {AvgMark}, кол-во пропущенных занятий: {Skipped}");
            }
        }
    }
}
