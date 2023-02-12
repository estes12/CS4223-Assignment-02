using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;

    public float restartDelay = 0.5f;

    private bool isPaused;

    public GameObject resumeButton;
    public GameObject pauseMenu;
    public void Win()
    {
        Invoke("WinGame", 1f);
    }

    void WinGame()
    {
        SceneManager.LoadScene(2);
    }
    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC key pauses AND resumes
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        resumeButton.gameObject.SetActive(true); // show the Resume button
    }
    public void ResumeGame() // called from ESC; also attached to the resume button
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        resumeButton.gameObject.SetActive(false); // hide the Resume button while playing

    }

    public void Start()
    {
        Time.timeScale = 1;
    }
}