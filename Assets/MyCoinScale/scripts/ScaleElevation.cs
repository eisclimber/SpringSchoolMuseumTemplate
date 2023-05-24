using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Bowl))]
public class ScaleElevation : MonoBehaviour
{
    [SerializeField, Tooltip("Min. height")]
    private float minHeight = 0.0f;

    [SerializeField, Tooltip("Max. height")]
    private float maxHeight = 0.0f;

    [SerializeField, Tooltip("Center height")]
    private float centerHeight = 0.0f;

    [SerializeField, Tooltip("Transition Speed")]
    private float speed = 0.0f;

    private int transitionDirection = 0;
    private float targetHeight;


    // Update is called once per frame
    void Update()
    {
        Elevate();
    }

    public void Activate(ScaleMessage scaleMessage)
    {
        if(GetComponent<Bowl>().BowlSide == Bowl.Side.left)
        {
            StartTransition(scaleMessage.LeftBowlState);
        }
        else
        {
            StartTransition(scaleMessage.RightBowlState);
        }
        
    }

    private void StartTransition(ScaleMessage.Heights height)
    {

        if (height == ScaleMessage.Heights.down)
        {
            targetHeight = minHeight;
        }else if(height == ScaleMessage.Heights.center)
        {
            targetHeight = centerHeight;
        }
        else
        {
            targetHeight = maxHeight;
        }

        if(transform.localPosition.y < targetHeight)
        {
            transitionDirection = 1;
        }else if(transform.localPosition.y > targetHeight)
        {
            transitionDirection = -1;
        }
        else
        {
            transitionDirection = 0;
        }

        enabled = true; 
    }

    private void Elevate()
    {
        if (CheckPosReached())
        {
            enabled = false;
        }
        else
        {
            transform.localPosition += Time.deltaTime * speed * transitionDirection * new Vector3(0, 1, 0);
        }
    }

    private bool CheckPosReached()
    {
        bool posReached = false;
        if (transitionDirection == -1 &&
            transform.localPosition.y <= targetHeight)
        {
            posReached = true;
        }
        else if (transitionDirection == 1 &&
           transform.localPosition.y >= targetHeight)
        {
            posReached = true;
        }
        return posReached;
    }
}
