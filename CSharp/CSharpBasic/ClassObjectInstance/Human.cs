using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    internal class CMan
    {
        string Name;
        int Age;
        float Height;
        float Weight;
        bool IsAvailable;

        public CMan(string name, int age, float height, float weight, bool use)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            IsAvailable = use;
        }

        public void PrintInfo()
        {
            string _IsAvailable;
            if (IsAvailable)
            {
                _IsAvailable = "가능";
            }
            else
            {
                _IsAvailable = "불가능";
            }

            Console.WriteLine($"{Name}씨는 나이가 {Age}, 키가 {Height}, 몸무게가 {Weight}, 이용 {_IsAvailable}");
        }
    }
}
