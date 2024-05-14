using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class activation : MonoBehaviour
{
    [SerializeField] GameObject HurtPanel;


    public float damage = 5f; // Adjust this value as needed
    private PlayerManager playerManager;
    private Animator animator;

    void Start()
    {
        // Find the PlayerManager in the scene
        playerManager = FindObjectOfType<PlayerManager>();
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    public IEnumerator HurtFlash()
    {
        
        HurtPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        HurtPanel.SetActive(false);
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the animator state
            animator.Play("idle", -1, 0f); // Change "Idle" to the name of your idle animation
            // Play the spikes animation
            animator.Play("spikes");

            // Damage the player
            if (playerManager != null)
            {
                playerManager.ChangedHealth(-Mathf.RoundToInt(damage));
                StartCoroutine(HurtFlash());

            }
        }
    }
}
