using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerController, PlayerStateValue>
{
    public bool toWalk(PlayerController player)
    {
        return (!player.isGrounded() || !player.isJumpPressed) && !player.isShootPressed;
    }
    public bool toJump(PlayerController player)
    {
        return player.isGrounded() && player.isJumpPressed;
    }
    public bool toAim(PlayerController player)
    {
        return player.isGrounded() && player.isShootPressed;
    }
    public bool toShoot(PlayerController player)
    {
        return !player.isShootPressed;
    }
}
