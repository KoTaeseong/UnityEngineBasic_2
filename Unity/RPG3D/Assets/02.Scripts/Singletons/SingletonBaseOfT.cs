using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Singletons
{
    public class SingletonBase<T> 
        where T : SingletonBase<T>
    {
        public T Instnace
        {
            get
            {
                if (_instnace == null)
                {
                    _instnace = Activator.CreateInstance<T>();
                    _instnace.Init();
                }
                return _instnace;
            }
        }
        private T _instnace;

        protected virtual void Init() { }
    }
}

