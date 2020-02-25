using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/**
 * S - state class
 * V - value enum
 */
public abstract class StateMachine<S, V> : MonoBehaviour where S : MonoBehaviour where V : struct, Enum
{
    Dictionary<V, State<S, V>> states = new Dictionary<V, State<S, V>>();
    public V currentState;

    public StateTransition[] transitions;
    public V initialState;

    protected virtual void Start()
    {
        currentState = initialState;

        foreach (V value in Enum.GetValues(typeof(V)))
        {
            states.Add(value, new State<S, V>());
        }

        foreach (StateTransition transition in transitions)
        {
            states[(V)Enum.Parse(typeof(V), transition.from)].AddTransition((V)Enum.Parse(typeof(V), transition.to),
                x => (bool)this.GetType().GetRuntimeMethod(transition.transitionPredicateFunction, new[] { typeof(S) }).Invoke(this, new[] { x }));
        }
    }

    protected virtual void Update()
    {
        V? nextState = states[currentState].CheckTransitions(gameObject.GetComponent<S>());
        if (nextState.HasValue)
        {
            currentState = nextState.Value;
        }
    }
}
