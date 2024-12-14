using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  I know ,I could've deleted these Thomas's and declare on the script 
///  and make it static but I want to keep channels together
/// </summary>

public class GlobalEvents : Channel
{
    public readonly static Channel tiles = new Channel();
}
public class GlobalEvents<T> : Channel<T>
{
    public static List<Channel<T>> channels = new List<Channel<T>>();
    public readonly static GlobalEvents<Vector2> coordinates = new GlobalEvents<Vector2>();
    public readonly static GlobalEvents<bool> tiles = new GlobalEvents<bool>();
}
#region  non-generic Channel
public class Channel
{
    private readonly HashSet<Action> ListenerLists = new HashSet<Action>();
    private readonly HashSet<Action> listenes = new HashSet<Action>();
    public void AddListener(Action A)
    {
        if (ListenerLists == null) throw new System.ArgumentNullException("Channel null");
        ListenerLists.Add(A);
    }
    public void RemoveListener(Action A)
    {
        if (ListenerLists == null) throw new System.ArgumentNullException("Channel null");
        ListenerLists.Remove(A);
    }
    public HashSet<Action> GetInstance()
    {
        return ListenerLists;
    }
    public void Execute()
    {
        foreach (Action A in ListenerLists)
        {
            A.Invoke();
        }
    }
}
#endregion


#region  generic Channel
public class Channel<T>
{
    private readonly HashSet<Action<T>> ListenerLists = new HashSet<Action<T>>();
    public HashSet<Action<T>> GetInstance()
    {
        return ListenerLists;
    }
    public void AddListener(Action<T> A)
    {
        if (ListenerLists == null) throw new System.ArgumentNullException("Channel null");
        ListenerLists.Add(A);
    }
    public void RemoveListener(Action<T> A)
    {
        if (ListenerLists == null) throw new System.ArgumentNullException("Channel null");
        ListenerLists.Remove(A);
    }
    public void Execute(T t)
    {
        foreach (var A in ListenerLists)
        {
            A.Invoke(t);
        }
    }
}
#endregion