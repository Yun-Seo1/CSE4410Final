using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    public PlayerManager playerManager; // Reference to the PlayerManager script

    void Start()
    {
        // Find the PlayerManager in the scene
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        // Check if player's health reaches zero
        if (playerManager != null && playerManager.Health <= 0)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
