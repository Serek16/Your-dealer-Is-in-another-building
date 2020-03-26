using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    [HideInInspector] public bool isGamePaused;

    void Start()
    {
        isGamePaused = false;
        pauseMenuUI.gameObject.SetActive(isGamePaused);        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameObject.Find("Console").GetComponent<cmd.Console.ConsoleController>().isConsoleActive)
        {
            isGamePaused = !isGamePaused;

            GameObject.Find("Main Camera").GetComponent<Game_data>().canMove = !isGamePaused;

            pauseMenuUI.gameObject.SetActive(isGamePaused);
            Time.timeScale = isGamePaused ? 0 : 1f;            
        }
    }

    public void Resume()
    {
        isGamePaused = !isGamePaused;
        pauseMenuUI.gameObject.SetActive(isGamePaused);
        Time.timeScale = 1f;
        GameObject.Find("Main Camera").GetComponent<Game_data>().canMove = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameObject.Find("Main Camera").GetComponent<Game_data>().canMove = true;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
