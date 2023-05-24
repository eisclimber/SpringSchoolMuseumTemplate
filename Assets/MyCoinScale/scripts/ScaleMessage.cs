using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMessage
{
    public enum Heights {down, center, up}

    private readonly Heights leftBowlState;
    public Heights LeftBowlState
    {
        get { return leftBowlState; }    
    }

    private readonly Heights rightBowlState;
    public Heights RightBowlState
    {
        get { return rightBowlState; }
    }

    public ScaleMessage(Heights left, Heights right)
    {
        leftBowlState = left;
        rightBowlState = right;
    }

}
