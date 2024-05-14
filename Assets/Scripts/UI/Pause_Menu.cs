using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject Pause;

    public static bool isPaused;

    public OrbitCamera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
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
        Pause.SetActive(true);
        Camera.rotSpeed = 0f;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Pause.SetActive(false);
        Camera.rotSpeed = 1.5f;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Camera.rotSpeed = 1.5f;
        SceneManager.LoadScene("MainMenu");
    }
}
