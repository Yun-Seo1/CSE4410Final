using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;

    void Awake()
    {
        if (_mainMenuCanvas == null) {return;}
        // disable the main menu canvas if its not a first level.
        if(SceneManager.GetActiveScene().buildIndex !=0){ _mainMenuCanvas.SetActive(false); return;}
        Time.timeScale = 0f;
    }

    public void playButton()
    {
        Time.timeScale = 1f;
    }

    public void pauseButton()
    {
        Time.timeScale = 0f;
    }

    public void resumeButton()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log($"Resetting game...");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
