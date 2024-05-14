using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    // Reference to the health bar image
    public Image healthBar;

    public void StartUp()
    {
        Debug.Log("Player manager starting...");

        Health = 50;
        MaxHealth = 100;

        UpdateHealthBar();

        status = ManagerStatus.Started;
    }

    public void ChangedHealth(int value)
    {
        Health += value;
        // To not exceed max health or go into the negative
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        
        UpdateHealthBar();
        if (Health <= 0)
        {
            Debug.Log($"PLAYER DEAD! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Debug.Log($"Health: {Health}/{MaxHealth}");
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)Health / MaxHealth;
        }
    }
}
