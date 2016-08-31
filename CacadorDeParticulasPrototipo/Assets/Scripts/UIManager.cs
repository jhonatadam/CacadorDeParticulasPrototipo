using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private bool isPaused = false;

    public Canvas pauseMenu;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame ();
        }

	}

    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0.0f;
            pauseMenu.gameObject.SetActive(true);

        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.gameObject.SetActive(false);

        }
    }

    public void ExitGame ()
    {
        Application.Quit ();
    }
}
