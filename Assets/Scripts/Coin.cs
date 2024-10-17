using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isCollected = false;

    public bool IsCollected()
    {
        return isCollected;
    }

    public void CollectCoin()
    {
        isCollected = true;
    }
}
