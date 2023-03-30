using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal abstract class Character : Creature, IDamagealbe,IAttackable
    {
        public int Hp
        {
            get 
            {
                return hp; 
            }
        }

        public int AttackPower
        { 
            get 
            { 
                return attackPower; 
            }
        }

        protected int hp;
        protected int attackPower;

        public void Damage(int value)
        {
            if (hp - value <0)
                hp = 0;
            else
                hp -= value;
        }

        public void Attack(IDamagealbe target)
        {
            target.Damage(attackPower);
        }
    }
}
