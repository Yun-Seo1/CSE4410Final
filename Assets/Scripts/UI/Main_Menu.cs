using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Main_Menu : MonoBehaviour
{
    public void LoadLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene");
    }
}
