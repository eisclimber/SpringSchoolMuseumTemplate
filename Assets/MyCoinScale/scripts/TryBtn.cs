using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TryBtn : MonoBehaviour
{
    public UnityEvent StartWeighing;

    private void OnTriggerEnter(Collider other)
    {
        StartWeighing?.Invoke();
    }

}
