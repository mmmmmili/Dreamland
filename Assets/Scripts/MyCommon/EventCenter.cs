using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    // Start is called before the first frame update
    private static Dictionary<EventType, Delegate> m_EventTable = new Dictionary<EventType, Delegate>();

    //这里的static是指不实例化也可以直接使用
    private static void OnListenerAdding(EventType type, Delegate callBack)
    {
        if (!m_EventTable.ContainsKey(type))
        {
            m_EventTable.Add(type, null);
        }
        Delegate d = m_EventTable[type];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", type, d.GetType(), callBack.GetType()));
        }
    }

    //no parament
    public static void AddListener(EventType type, CallBack callBack)
    {
        OnListenerAdding(type, callBack);
        m_EventTable[type] = (CallBack)m_EventTable[type] + callBack;
    }

    //one parament
    public static void AddListener<T>(EventType type, CallBack<T> callBack)
    {
        OnListenerAdding(type, callBack);
        m_EventTable[type] = (CallBack<T>)m_EventTable[type] + callBack;
    }
    //two parameters
    public static void AddListener<T, X>(EventType eventType, CallBack<T, X> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X>)m_EventTable[eventType] + callBack;
    }
    //three parameters
    public static void AddListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] + callBack;
    }
    //four parameters
    public static void AddListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] + callBack;
    }
    //five parameters
    public static void AddListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] + callBack;
    }
    private static void OnListenerRemoving(EventType type, Delegate callBack)
    {
        if (m_EventTable.ContainsKey(type))
        {
            Delegate d = m_EventTable[type];
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误，事件{0}没有委托", type));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误，尝试为事件{0}移除不同类型的委托，当前事件所对应的委托是{1}，要移除的委托类型为{2}", type, d.GetType(), callBack.GetType()));
            }
            else
            {

            }

        }
        else
        {
            throw new Exception(string.Format("移除监听错误，事件{0}没有事件码", type));
        }
    }

    private static void OnListenerRemoved(EventType type)
    {
        if (m_EventTable[type] == null)
        {
            m_EventTable.Remove(type);
        }
    }


    //no parament
    public static void RemoveListener(EventType type, CallBack callBack)
    {
        OnListenerRemoving(type, callBack);
        m_EventTable[type] =(CallBack)m_EventTable[type] - callBack;
        OnListenerRemoved( type);
    }

    //one parament
    public static void RemoveListener<T>(EventType type, CallBack<T> callBack)
    {
        OnListenerRemoving(type, callBack);
        m_EventTable[type] = (CallBack<T>)m_EventTable[type] - callBack;
        OnListenerRemoved(type);
    }
    //two parameters
    public static void RemoveListener<T, X>(EventType eventType, CallBack<T, X> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    //three parameters
    public static void RemoveListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    //four parameters
    public static void RemoveListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    //five parameters
    public static void RemoveListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    //这里是没有参数的广播，把type对应的委托取出来，调用这个委托
    public static void Broadcast(EventType type)

    {
        
        Delegate d;
        if(m_EventTable.TryGetValue(type, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
                
            }
            else
            {
                throw new Exception(string.Format("广播事件错误，事件唉{0}对应委托具有不同的类型",type));
            }
        }
        
        
    }


    //这个委托有一个参数
    public static void Broadcast<T>(EventType type,T arg)

    {

        Delegate d;
        if (m_EventTable.TryGetValue(type, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);

            }
            else
            {
                throw new Exception(string.Format("广播事件错误，事件{0}对应委托具有不同的类型", type));
            }
        }


    }
    //two parameters
    public static void Broadcast<T, X>(EventType eventType, T arg1, X arg2)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X> callBack = d as CallBack<T, X>;
            if (callBack != null)
            {
                callBack(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", eventType));
            }
        }
    }
    //three parameters
    public static void Broadcast<T, X, Y>(EventType eventType, T arg1, X arg2, Y arg3)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", eventType));
            }
        }
    }
    //four parameters
    public static void Broadcast<T, X, Y, Z>(EventType eventType, T arg1, X arg2, Y arg3, Z arg4)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", eventType));
            }
        }
    }
    //five parameters
    public static void Broadcast<T, X, Y, Z, W>(EventType eventType, T arg1, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", eventType));
            }
        }
    }
}
