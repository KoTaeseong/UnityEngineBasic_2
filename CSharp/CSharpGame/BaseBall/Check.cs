using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    internal class Check
    {
        public static void CheckValue(string tNum, string tInput,ref bool tGame)
        {
            int Boll = 0;
            int Strike = 0;
            int Out = 0;

            for (int i = 0; i < tNum.Length; i++)
            {
                bool OutCheck = true;

                for (int j = 0; j < tInput.Length; j++)
                {
                    if (tNum[i] == tInput[j])
                    {
                        if (i == j)
                        {
                            Strike++;
                            OutCheck = false;
                        }
                        else
                        {
                            Boll++;
                            OutCheck = false;
                        }
                    }
                }
                if (OutCheck)
                {
                    Out++;
                }
            }

            Console.WriteLine($"스트라이크 : {Strike}, 볼 : {Boll}, 아웃 : {Out}");

            if (Strike == 3)
            {
                tGame = false;
            }
        }
    }
}
