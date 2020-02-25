using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/**
 * S - state class
 * V - value enum
 */
public class State<S, V> where S : MonoBehaviour where V : struct, Enum
{
    Dictionary<V?, Func<S, bool>> transitions = new Dictionary<V?, Func<S, bool>>();

    public void AddTransition(V value, Func<S, bool> predicate) => transitions.Add((V?)value, predicate);

    public void RemoveTransition(V value) => transitions.Remove(value);

    public V? CheckTransitions(S state) => transitions.Where(x => x.Value(state)).Select(x => x.Key).FirstOrDefault();

}
