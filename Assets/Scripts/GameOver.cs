using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public TextMeshProUGUI roundsText;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    //void OnEnable()
    //{
    //    roundsText.text = PlayerStats.Rounds.ToString();
    //}
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
