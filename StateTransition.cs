using System;

[System.Serializable]
public struct StateTransition
{
	public string from;
	public string to;
	public string transitionPredicateFunction;
}
