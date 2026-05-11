using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeState(GameState.Playing);
        }
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void Restart()
    {
         SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        GameManager.Instance.ChangeState(GameState.Playing);
    }
}