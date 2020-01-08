using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
   public PlayerStateValue currentStateValue { get; private set; }
    private PlayerState currentState;
    private PlayerStateBuilder builder;

    public PlayerStateMachine()
    {
        builder = new PlayerStateBuilder();
        currentState = builder.getState(PlayerStateValue.WALK);
        currentStateValue = PlayerStateValue.WALK;
    }
    public void UpdateState(PlayerController controller)
    {
        PlayerStateValue newStateValue = currentState.checkTransitions(controller);
        if(newStateValue != PlayerStateValue.NOT_VALID)
        {
            currentStateValue = newStateValue;
            currentState = builder.getState(newStateValue);
        }


    }
    


}
