using UnityEngine;

public class activation : MonoBehaviour
{
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
            }
        }
    }
}
