using UnityEngine;

public class ConstantDamage : MonoBehaviour
{
    public float damageRate = 1f; // Damage per second
    private PlayerManager playerManager;
    private float timeSinceLastDamage = 0f;

    void Start()
    {
        // Find the PlayerManager in the scene
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Calculate time since last damage
            timeSinceLastDamage += Time.deltaTime;

            // Apply damage at a regular rate
            if (timeSinceLastDamage >= 1f / damageRate)
            {
                // Damage the player
                if (playerManager != null)
                {
                    playerManager.ChangedHealth(-1); // Adjust damage amount as needed
                }

                // Reset timeSinceLastDamage
                timeSinceLastDamage = 0f;
            }
        }
    }
}
