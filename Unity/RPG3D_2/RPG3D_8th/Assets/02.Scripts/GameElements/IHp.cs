using RPG.FSM;
using System;

namespace RPG.GameElements
{
    public interface IHp
    {
        float hp { get; set; }
        float hpMax { get; }
        float hpMin { get; }

        event Action<float> onHpChanged;    //����� ��
        event Action<float> onHpRecovered;  //ȸ���� ��
        event Action<float> onHpDepleted;   //���ҵ� ��
        event Action onHpMax;
        event Action onHpMin;

        void RecorverHp(MachineManager characterMachine, float amount);
        void DepleteHp(MachineManager characterMachine, float amount);
    }
}