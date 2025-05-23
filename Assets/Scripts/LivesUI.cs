using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    
    void Update()
    {
        livesText.text = "LIVES: " + PlayerStats.Lives.ToString();
    }
}
