using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public Animator animator;
    public bool endLevel = false;

    // Update is called once per frame
    void Update()
    {
        coinText.text = CoinCounter.instance.GetCoins().ToString();

        if (CoinCounter.instance.GetCoins() == (SceneManager.GetActiveScene().buildIndex * 7) + 7)
        {
            Debug.Log("All Coins Collected!");
            endLevel = true;
            animator.SetBool("endLevel", endLevel);
        }
    }
}
