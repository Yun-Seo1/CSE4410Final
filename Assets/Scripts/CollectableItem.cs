using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] string ItemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Item collected: " + ItemName);
            Managers.Inventory.AddItem(ItemName);
            Destroy(this.gameObject);
        }
        
    }
}
