using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scale : MonoBehaviour
{
    public UnityEvent<ScaleMessage> OnScaleCheck;

    [SerializeField, Tooltip("Ref. to the left Bowl")]
    private Bowl leftBowl;

    [SerializeField, Tooltip("Ref. to the right Bowl")]
    private Bowl rightBowl;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckBowls();
        }
    }

    public void CheckBowls()
    {
        ScaleMessage msg;
        if(leftBowl.GetBowlWeight() < rightBowl.GetBowlWeight())
        {
            msg = new ScaleMessage(ScaleMessage.Heights.up, ScaleMessage.Heights.down);
        }else if (leftBowl.GetBowlWeight() > rightBowl.GetBowlWeight())
        {
            msg = new ScaleMessage(ScaleMessage.Heights.down, ScaleMessage.Heights.up);
        }
        else
        {
            msg = new ScaleMessage(ScaleMessage.Heights.center, ScaleMessage.Heights.center);
        }
        OnScaleCheck?.Invoke(msg);
    }

    public void Reset()
    {
        leftBowl.Reset();
        rightBowl.Reset();
    }
}
