using UnityEngine;

public class activation : MonoBehaviour
{
    public float damage = 5f; // Adjust this value as needed
    private PlayerManager playerManager;

    void Start()
    {
        // Find the PlayerManager in the scene
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetComponent<Animator>().Play("spikes");

            // Damage the player
            if (playerManager != null)
            {
                playerManager.ChangedHealth(-Mathf.RoundToInt(damage));
            }
        }
    }
}
