using System.Reflection;    //런타임중에 어셈블리 등의 코드에 접근하는 용도 (메타데이터) 의 기능을 제공하는 네임스페이스
using System;


public class SingletonBase<T>
    where T : SingletonBase<T>
{
    private static readonly object _spinLock = new object();
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_spinLock)
                {
                    //ConstructorInfo constructorInfo = typeof(T).GetConstructor(new Type[] { });
                    //_instance = constructorInfo.Invoke(new object[] { }) as T;

                    _instance = Activator.CreateInstance<T>();  //Activator클래스는 위의 연산을 편하게 해준다
                    _instance.Init();
                }
            }

            return _instance;
        }
    }
    private static T _instance;

    protected virtual void Init() {}
}
