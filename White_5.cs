using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_5
    {
        public struct Match
        {
            private readonly int _goals;
            private readonly int _misses;

            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => _goals - _misses;
            public int Score
            {
                get
                {
                    if (Difference < 0) return 0;
                    else if (Difference == 0) return 1;
                    else return 3;
                }
            }
            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }

            public void Print()
            {
                Console.WriteLine($"Голы: {_goals}, пропущенные: {_misses}, очки: {Score}");
            }
        }
        public struct Team
        {
            private readonly string _name;
            private Match[] _matches;
            private int _count;

            public string Name => _name;
            public Match[] Matches => _matches;

            public int TotalDifference
            {
                get
                {
                    int totaldifference = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        totaldifference += _matches[i].Score;
                    }
                    return totaldifference;
                }
            }

            public int TotalScore
            {
                get
                {
                    int totalScore = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        totalScore += _matches[i].Score;
                    }
                    return totalScore;
                }
            }
            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
                _count = 0;
            }
            public void PlayMatch(int goals, int misses)
            {
                if (_count < _matches.Length)
                {
                    _matches[_count] = new Match(goals, misses);
                    _count++;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Команда - {Name}, общий счёт - {TotalScore}, разница голов - {TotalDifference}");
            }
            public static void SortTeams(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TotalDifference < teams[j + 1].TotalDifference)
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                            }
                        }
                    }
                }
            }
        }
    }
}
