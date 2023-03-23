using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statement_SwitchAndEnum
{
    //Attribute ?
    // 타입의 메타데이터를 정의하는 형태의 클래스
    // 메타데이터 ? 데이터의 데이터

    //Flags Attribute
    // 중복된 Flag들을 각 요소들에대한 문자열로 변환해주는 기능을 가지고 있는 Attribute
    [Flags]
    public enum LayerMask
    {
        None    = 0 << 0,   // ... 0000 0000 == 0
        NPC     = 1 << 0,   // ... 0000 0001 == 1
        Enemy   = 1 << 1,   // ... 0000 0010 == 2
        Player  = 1 << 2,   // ... 0000 0100 == 4
        Ground  = 1 << 3,   // ... 0000 1000 == 8
        wall    = 1 << 4,   // ... 0001 0000 == 16
        //EnemyNPC = NPC | Enemy, // ... 0000 0011  
    }

    public enum LayerMaskDummy
    {
        None,   // ... 0000 0000
        NPC,    // ... 0000 0001
        Enemy,  // ... 0000 0010
        Player, // ... 0000 0011
        Ground, // ... 0000 0100
        wall,   // ... 0000 0101

        EnemyNPC = NPC | Enemy, // ... 0000 0011 == LayerMaskDummy.Player
    }
}
