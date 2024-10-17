using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ColorShowScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image imageComponent;
    private float colorChangeDuration = 0.25f;
    private float timer = 0f;
    private Color textColor;

    void Start()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            imageComponent = GetComponent<Image>();
        }

    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= colorChangeDuration)
        {
            timer = 0f;
            textColor = textComponent.color;
            textComponent.color = imageComponent.color;
            imageComponent.color = textColor;
        }
    }
}
