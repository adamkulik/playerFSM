using System;
using System.Linq;
using System.Collections.Generic;

/**
 * S - state class
 * V - value enum
 */
public class State<S, V> where V : Enum
{
	Dictionary<V, Func<S, bool>> transitions = new Dictionary<V, Func<S, bool>>();

    public bool AddTransition(V value, Func<S, bool> predicate) => transitions.Add(value, predicate);

    public bool RemoveTransition(V value) => transitions.Remove(value);

    public V CheckTransitions(S state) => transitions.Where(x => x.Value(state)).Select(x => x.Key).FirstOrDefault();

}
