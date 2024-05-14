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

    [SerializeField] private string pauseSoundName;
    [SerializeField] private string resumeSoundName;
    [SerializeField] private string goToMainMenu;


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
        AudioManager.Instance.PlayPauseSound(pauseSoundName);

        Pause.SetActive(true);
        Camera.rotSpeed = 0f;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        AudioManager.Instance.PlayResumeSound(resumeSoundName);

        Pause.SetActive(false);
        Camera.rotSpeed = 1.5f;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        AudioManager.Instance.PlaySoundEffect("MainMenu", transform.position);

        Time.timeScale = 1f;
        Camera.rotSpeed = 1.5f;
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Scene");
        Debug.Log($"Resetting game...");
    }
}
