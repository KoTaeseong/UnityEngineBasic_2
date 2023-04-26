﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Player
    {
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                if (_hp == value)
                    return;

                _hp= value;
                //RaceCondition : 구독자들에게 값을 넘겨주는 중에 값이 바뀌는 경우
                //다른 스레드에서 값을 수정할 수 도 있어서 _hp값이 아닌 value값을 넣는다. 대리자에 여러개의 함수가 구독될경우 여전히 문제가 생길 수 있다.
                //멀티스레드에서 안돌릴경우 아래의 경우를 사용한다.
                //OnHPChanged(value); 
                //OnHPChanged.Invoke(value);  // invoke는 대리자에 등록된 함수들의 RaceCondition을 방지하기위해 사용하는 함수
                if (value <= _hpMin)
                    OnHpMin?.Invoke();
                else
                    OnHPChanged?.Invoke(value); // ?.invoke 대리자에 등록된 함수가 없을경우 호출하지 않는 구문
                // ? : null체크 연산자
            }
        }
        private int _hp;
        private int _hpMax = 100;
        private int _hpMin = 0;
        //public delegate void HPChangedHandler(int hp);
        //public event HPChangedHandler OnHPChanged; // event한정자 : 대리자를 외부 클래스에서 직접 호출하거나 invoke할 수 없도록 제한
        public event Action<int> OnHPChanged;
        public event Action OnHpMin;
        private PlayerUI _playerUI;



        public delegate void SomthingHandler(int a, int b);
        public SomthingHandler OnSomehow;

        //Generic
        public Action<int, int> action; //반환 타입이 없고, 파라미터는 0개~16개 까지 정의되어있으므로 쓸 수 있다.
        public Func<int,float> func;    //반환 타입이 있고, "
        public Predicate<int> predicate;//반환 타입이 bool, 파라미터는 1개~16개 까지
        
        
        
        public Player()
        {
            _hp = _hpMax;
        }
    }
}