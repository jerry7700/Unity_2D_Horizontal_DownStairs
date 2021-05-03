using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("時間")]
    public Text timeScore;
    public GameObject gameOverUI;

    static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void GameOver(bool dead)
    {
        if(dead)
        {
            instance.gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
