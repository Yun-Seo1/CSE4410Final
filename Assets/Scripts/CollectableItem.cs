using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] string ItemName;
    [SerializeField] private string collectSoundName; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySoundEffect(collectSoundName, transform.position);
            //Debug.Log("Item collected: " + ItemName);
            Managers.Inventory.AddItem(ItemName);
            Destroy(this.gameObject);
        }
        
    }
}
