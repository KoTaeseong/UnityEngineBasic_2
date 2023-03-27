using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing
{
    internal class Horse
    {
        public string Name;
        public bool IsFinished;
        public double TotalDistance;
        public int Rank = 0;

        public Horse(string _name, bool _isFinished, double _totalDistance)
        {
            Name = _name;
            IsFinished = _isFinished;
            TotalDistance = _totalDistance;
        }

        public void Move(double distacne)
        {
            if (IsFinished == false)
            {
                if (TotalDistance < 200.0f)
                {
                    TotalDistance += distacne;
                    if (TotalDistance >= 200.0f)
                    {
                        IsFinished = true;
                    }
                }
                else
                {
                    IsFinished = true;
                }
            }
        }
    }
}
