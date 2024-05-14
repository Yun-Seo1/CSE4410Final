using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] Targets;
    public TimelineController timelineController;

    public bool RequireKey;

    private void OnTriggerEnter(Collider other)
    {
        if (RequireKey && Managers.Inventory.EquippedItem != "Key")
        {
            return;
        }

        if(other.gameObject.tag == "Player")
        {
            foreach (GameObject Target in Targets)
            {
                Target.SendMessage("Activate");
            }

            if (timelineController != null)
            {
                timelineController.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject Target in Targets)
            {
                Target.SendMessage("Deactivate");
                
            }
        }
    }
}
