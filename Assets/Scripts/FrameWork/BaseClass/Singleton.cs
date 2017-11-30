using System;
using System.Reflection;
public abstract class Singleton<T> where T : class
{
    private static T m_intance;

    public static T Instance
    {
        get
        {
            if (m_intance == null)
            {
                m_intance = null;
                Type type = typeof(T);
                // public item should cut it out
                BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
                ConstructorInfo[] constructorInfoArray = type.GetConstructors(bindingAttr);

                foreach (ConstructorInfo constructorInfo in constructorInfoArray)
                {
                    ParameterInfo[] parameterInfoArray = constructorInfo.GetParameters();
                    if (parameterInfoArray.Length == 0)
                    {
                        m_intance = (T)constructorInfo.Invoke(null);
                        break;
                    }
                }

                if (null == m_intance)
                {
                    throw new NotSupportedException("No NonPublic constructor without 0 parameter");
                }
            }

            return m_intance;
        }
    }

    protected Singleton()
    {
    }
}

//public class Singleton<T>where T :new()
//{
//    public static T Instance
//    {
//        get
//        {
//            return SingletonCreator.instance;
//        }
//    }

//	protected Singleton()
//    {
//        if(Instance != null)
//        {
//            throw (new Exception("You have tried to create a new singleton class where you should have instanced it.Replace your \"new class()\" with \"class.Instance\""));
//        }
//    }

//    class SingletonCreator
//    {
//        static SingletonCreator()
//        {

//        }
//        internal static readonly T instance = new T();
//    }
//}
//using System;
