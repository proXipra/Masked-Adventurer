using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public int totalCoin;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetCoins()
    {
        return totalCoin;
    }
}
