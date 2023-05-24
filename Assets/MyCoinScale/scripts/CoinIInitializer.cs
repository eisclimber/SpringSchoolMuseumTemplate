using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExPresSXR.Interaction;

public class CoinIInitializer : MonoBehaviour
{

    [SerializeField, Tooltip("GameObjects of the 9 coins")]
    private List<CoinWeight> coins;

    [SerializeField, Tooltip("Transforms of the 9 positions where the coins shall be placed randomly")]
    private Transform[] positions;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        coins = Shuffle.ShuffleList(coins);
        PlaceCoins();
    }

    private void PlaceCoins()
    {
        int pos = 0;
        foreach(CoinWeight coin in coins)
        {
            if (coin.TryGetComponent(out Rigidbody rb))
            {
                rb.velocity = Vector3.zero;
            }

            if (coin.TryGetComponent(out CollisionSoundEmitter soundEmitter))
            {
                soundEmitter.StartNoAudioWaitTime();
            }

            coin.transform.SetParent(positions[pos]);
            coin.transform.localPosition = Vector3.zero;
            coin.transform.localEulerAngles = Vector3.zero; 
            pos++;
        }
    }
}
