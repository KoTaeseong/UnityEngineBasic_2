using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class SwordMan : Character
    {
        public override void SayHi()
        {
            base.SayHi();
        }

        public SwordMan(int hp, int attackPower)
            : base(hp, attackPower)
        {

        }

        protected override void Breath()
        {
            Console.WriteLine("SwordMan 이(가) 숨을 쉰다.");
        }
    }
}
