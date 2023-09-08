using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private string displayText;
    [SerializeField] public bool isHighlighted = false; // Boolean to control highlighting

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Cache the TextMeshProUGUI component
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();
    }

    // This function is called whenever you change the value in the Unity Editor
    void OnValidate()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = displayText;

            // Update text color and outline based on isHighlighted
            if (isHighlighted)
            {
                textMeshPro.color = Color.white;
                textMeshPro.enableWordWrapping = true;
                textMeshPro.outlineWidth = 0.2f;
            }
            else
            {
                textMeshPro.color = new Color(0.5f, 0.5f, 0.5f); // Dull color
                textMeshPro.enableWordWrapping = false;
                textMeshPro.outlineWidth = 0.0f;
            }
        }
    }
}
