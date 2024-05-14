using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] Targets;
    [SerializeField] GameObject WinPanel;
   

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
                
                WinPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject Target in Targets)
            {
                
                
            }
        }
    }
}
