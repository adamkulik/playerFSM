using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class StateMachine<S, V>: MonoBehaviour where V: Enum
{
	Dictionary<V, State<S, V>> states = new Dictionary<V, State<S, V>>();
    public V CurrentState { get; }

    public StateTransition<V>[] transitions;
    public V initialState;

	void Start()
    {
        CurrentState = initialState;

		foreach(V value in Enum.GetValues(typeof(V)))
        {
            states.Add(value, new State<S, V>());
        }

        foreach(StateTransition<V> transition in transitions)
        {
            states[transition.from].AddTransition(transition.to,
                this.GetType().GetRuntimeMethod(transition.transitionPredicateFunction, new[] { typeof(S) }).CreateDelegate(typeof(Func<S, bool>), this));
        }
    }

    void Update()
    {
        V nextState = states[CurrentState].CheckTransitions(gameObject);
        if (nextState != null)
        {
            CurrentState = nextState;
        }
    }
}
