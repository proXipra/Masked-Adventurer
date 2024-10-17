using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class FinishPoint : MonoBehaviour
{
    public CoinManager gm;
    public TextMeshProUGUI winText;
    public Image winImg;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int lastSceneIndex = totalScenes - 1;
        
        if ((coll.CompareTag("Player")) && (gm.endLevel == true) && (lastSceneIndex != currentSceneIndex))
        {
            SceneController.instance.NextLevel();
        }
        else if ((coll.CompareTag("Player")) && (gm.endLevel == true) && (lastSceneIndex == currentSceneIndex))
        {
            Debug.Log("bok");
            winText.gameObject.SetActive(true);
            winImg.gameObject.SetActive(true);
        }
    }
}
