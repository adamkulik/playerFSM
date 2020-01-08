using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerTransitions 
{
   public static Func<PlayerController, bool> toWalk()
    {
        return ((player) => (!player.isGrounded() || !player.isJumpPressed) && !player.isShootPressed);
    }
    public static Func<PlayerController, bool> toJump()
    {
        return ((player) => player.isGrounded() && player.isJumpPressed);
    }
    public static Func<PlayerController, bool> toAim()
    {
        return ((player) => player.isGrounded() && player.isShootPressed);
    }
    public static Func<PlayerController, bool> toShoot()
    {
        return ((player) => !player.isShootPressed);
    }
}
