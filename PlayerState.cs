using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    Dictionary<PlayerStateValue, Func<PlayerController, bool>> statesWithTransitions;
    public PlayerState ()
    {
        statesWithTransitions = new Dictionary<PlayerStateValue, Func<PlayerController, bool>>();
    }
    public PlayerStateValue checkTransitions(PlayerController controller)
    {
        foreach(var stateWithTransition in statesWithTransitions)
        {
            if(stateWithTransition.Value(controller))
            {
                return stateWithTransition.Key;
            }
        }
        return PlayerStateValue.NOT_VALID;
    }
    public void AddStateAndTransition(PlayerStateValue state, Func<PlayerController, bool> transition)
    {
        statesWithTransitions.Add(state, transition);
    }
}
