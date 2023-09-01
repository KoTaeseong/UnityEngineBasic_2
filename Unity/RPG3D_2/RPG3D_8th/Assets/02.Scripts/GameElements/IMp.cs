using RPG.FSM;
using System;

namespace RPG.GameElements
{
    public interface IMp
    {
        float mp { get; set; }
        float mpMax { get; }
        float mpMin { get; }

        event Action<float> onMpchanged;    //����� ��
        event Action<float> onMpRecovered;  //ȸ���� ��
        event Action<float> onMpDepleted;   //���ҵ� ��
        event Action onMpMax;
        event Action onMpMin;

        void RecorverMp(MachineManager characterMachine, float amount);
        void DepleteMp(MachineManager characterMachine, float amount);
    }
}