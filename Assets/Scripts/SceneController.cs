using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public CoinManager gm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void NextLevel()
    {
        gm.endLevel = false;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
