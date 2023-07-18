using System.Reflection;    //��Ÿ���߿� ����� ���� �ڵ忡 �����ϴ� �뵵 (��Ÿ������) �� ����� �����ϴ� ���ӽ����̽�
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

                    _instance = Activator.CreateInstance<T>();  //ActivatorŬ������ ���� ������ ���ϰ� ���ش�
                    _instance.Init();
                }
            }

            return _instance;
        }
    }
    private static T _instance;

    protected virtual void Init() {}
}
