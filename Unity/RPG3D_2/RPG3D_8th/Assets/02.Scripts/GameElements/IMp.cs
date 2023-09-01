using RPG.FSM;
using System;

namespace RPG.GameElements
{
    public interface IMp
    {
        float mp { get; set; }
        float mpMax { get; }
        float mpMin { get; }

        event Action<float> onMpchanged;    //변경된 값
        event Action<float> onMpRecovered;  //회복된 양
        event Action<float> onMpDepleted;   //감소된 양
        event Action onMpMax;
        event Action onMpMin;

        void RecorverMp(MachineManager characterMachine, float amount);
        void DepleteMp(MachineManager characterMachine, float amount);
    }
}