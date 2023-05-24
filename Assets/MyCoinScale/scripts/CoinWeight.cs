using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWeight : MonoBehaviour
{
    [SerializeField, Tooltip("Defines wheter the coin is fake or real.")]
    private bool isFake = false;
    public bool IsFake
    {
        get { return isFake; }
    }


}
