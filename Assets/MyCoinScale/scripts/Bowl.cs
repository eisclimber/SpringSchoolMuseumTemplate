using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public enum Side { left, right };

    private List<CoinWeight> containedCoins = new();

    [SerializeField, Tooltip("Defines whether the bow is the left or the right one.")]
    private Side side;

    private Vector3 initialPos;

    public Side BowlSide
    {
        get { return side; }
    }

    private void Start()
    {
        initialPos = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null && rb.TryGetComponent(out CoinWeight weight) && !containedCoins.Contains(weight))
        {
            containedCoins.Add(weight);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null && rb.TryGetComponent(out CoinWeight weight) && containedCoins.Contains(weight))
        {
            containedCoins.Remove(weight);
        }
    }

    public int GetBowlWeight()
    {
        int weight = 0;

        foreach(CoinWeight cw in containedCoins)
        {
            if (!cw.IsFake)
            {
                weight++;
            }
        }

        return weight;
    }

    public void Reset()
    {
        containedCoins = new();
        transform.localPosition = initialPos;
    }
}
