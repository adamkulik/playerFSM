using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBuilder
{
    Dictionary<PlayerStateValue, PlayerState> stateValueToState;
   
    public PlayerStateBuilder()
    {
        stateValueToState = new Dictionary<PlayerStateValue, PlayerState>();
        PlayerState walk = new PlayerState();
        stateValueToState.Add(PlayerStateValue.WALK, walk);
        PlayerState jump = new PlayerState();
        stateValueToState.Add(PlayerStateValue.JUMP, jump);
        PlayerState aim = new PlayerState();
        stateValueToState.Add(PlayerStateValue.AIM, aim);
        PlayerState shoot = new PlayerState();
        stateValueToState.Add(PlayerStateValue.SHOOT, shoot);
        walk.AddStateAndTransition(PlayerStateValue.JUMP, PlayerTransitions.toJump());
        jump.AddStateAndTransition(PlayerStateValue.WALK, PlayerTransitions.toWalk());
        walk.AddStateAndTransition(PlayerStateValue.AIM, PlayerTransitions.toAim());
        aim.AddStateAndTransition(PlayerStateValue.SHOOT, PlayerTransitions.toShoot());
        
        
    }
    public PlayerState getState(PlayerStateValue stateValue)
    {
        return stateValueToState[stateValue];
    }



}
