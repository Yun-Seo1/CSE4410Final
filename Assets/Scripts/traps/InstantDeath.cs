using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    public float damage = 100f; // Adjust this value as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.ChangedHealth(-Mathf.RoundToInt(damage));
            }
        }
    }
}
