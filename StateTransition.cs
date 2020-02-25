using System;

public struct StateTransition<V> where V: Enum
{
	public V from;
	public V to;
	public string transitionPredicateFunction;
}
