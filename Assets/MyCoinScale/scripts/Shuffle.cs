using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle
{
    
    public static List<CoinWeight> ShuffleList(List<CoinWeight> list)
    {
        int amount = list.Count;
        while (amount > 1)
        {
            amount--;
            int k = Random.Range(0, amount+1);
            CoinWeight o = list[k];
            list[k] = list[amount];
            list[amount] = o;
        }

        return list;
    }  

}
