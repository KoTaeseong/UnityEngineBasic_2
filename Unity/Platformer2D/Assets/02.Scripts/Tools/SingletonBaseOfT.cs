using System.Reflection;    //��Ÿ���߿� ����� ���� �ڵ忡 �����ϴ� �뵵 (��Ÿ������) �� ����� �����ϴ� ���ӽ����̽�
using System;


public class SingletonBase<T>
    where T : SingletonBase<T>
{

    public static T instance
    {
        get
        {
            if (instance == null)
            {
               //ConstructorInfo constructorInfo = typeof(T).GetConstructor(new Type[] { });
               //_instance = constructorInfo.Invoke(new object[] { }) as T;

                _instance = Activator.CreateInstance<T>();  //ActivatorŬ������ ���� ������ ���ϰ� ���ش�
            }

            return _instance;
        }
    }
    private static T _instance;
}
