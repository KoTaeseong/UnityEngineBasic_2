﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C# naming convention
// 사용자정의 자료형의 이름 : PascalCase
// public, protected, internal 멤버 변수 : PascalCase
// private 멤버 변수 : _camelCase 
// 지역 변수 : camelCase
// 함수 : PascalCase
//


namespace ClassObjectInstance
{
    //클래스
    //캡슐화하기위한 사용자정의 자료형
    internal class SwordMan
    {
        // 접근제한자 ( Access Modifiers)
        // 1. private   : 외부 접근 불가능
        // 2. public    : 외부 접근 가능
        // 3. internal  : 동일 어셈블리에서 접근가능 (동일 프로젝트 내에서 접근가능)
        // 4. protected : 상속받은 자식 클래스에서만 접근 가능
        // 클래스는 캡슐화를 위한 자료형이기 때문에
        // 기본적으로 모든 멤버는 private이 default 이다.

        // 멤버 변수들
        public string Name;
        public int Lv;
        private float _exp;
        private char _gender;

        // 클래스 생성자
        // 정의하지 않아도 default생성자가 생략됨(생성됨)
        // 해당 클래스타입의 객체를 힙영역에 할당하고 해당 객체의 참조를 반환
        public SwordMan()
        {

        }

        // 클래스 소멸자
        // 해당 객체를 메모리영역에서 해제할때 호출하는 함수
         ~SwordMan()
        {

        }


        // 멤버 함수들
        public void Slash()
        {
            // this 키워드 :
            // 호출한 객체 자기자신을 참조하는 키워드
            Console.WriteLine($"{this.Name} 이(가) 베기를 시전했다.");
        }
    }
}
