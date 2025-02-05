using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string nextLevel;
    public int nextLevelIndex;

    bool gameHasEnded = false;

    public float restartDelay = 1f;
    public float winDelay = 5f;

    public GameObject completeLevelUI;

    public void WinLevel()
    {
        if (PlayerPrefs.GetInt("levelsCompleted") < nextLevelIndex)
        {
            PlayerPrefs.SetInt("levelsCompleted", nextLevelIndex);
            PlayerPrefs.SetString("NextLevel", nextLevel);
        }

        SceneManager.LoadScene("LevelSelector");
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("WinLevel", winDelay);
    }

    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
