using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Singletons
{
    public class SingletonBase<T> 
        where T : SingletonBase<T>
    {
        public static T Instnace
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
        private static T _instnace;

        protected virtual void Init() { }
    }
}

