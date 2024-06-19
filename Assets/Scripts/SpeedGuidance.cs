using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedGuidance
{
    static float mySpeed;
    public static void TakeSpeed(float speed)
    {
        mySpeed = speed;
    }
    public static float GetSpeed()
    {
        return mySpeed;
    }
}
