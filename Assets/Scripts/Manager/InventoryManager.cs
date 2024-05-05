using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    private Dictionary<string, int> Items;
    public ManagerStatus status { get; private set; }

    public string EquippedItem { get; private set; }

    public void StartUp()
    {
        Debug.Log("Inventory manager starting...");

        Items = new Dictionary<string, int>();





        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        string ItemDisplay = "";
        foreach (KeyValuePair<string, int> Item in Items) 
        {
            ItemDisplay += Item.Key + "(" + Item.Value + ")";
        }
        Debug.Log(ItemDisplay);
    }


    public void AddItem(string Name)
    {
        if (Items.ContainsKey(Name))
        {
            Items[Name] += 1;
        }
        else
        {
            Items[Name] = 1;
        }

        DisplayItems();
    }


    public List<string> GetItemList()
    {
        List<string> list = new List<string>(Items.Keys);
        return list;
    }

    public int GetItemCount(string Name)
    {
        if(Items.ContainsKey(Name))
        {
            return Items[Name];
        }
        else
        {
            return 0;
        }
    }


    public bool EquipItem(string Name)
    {
        if (Items.ContainsKey(Name) && EquippedItem != Name)
        {
            EquippedItem = Name;
            Debug.Log("Equipped Item: " + Name);
            return true;
        }

        EquippedItem = null;
        Debug.Log("Unequipped Item");
        return false;
    }

    public bool ConsumeItem(string Name)
    {
        if (Items.ContainsKey(Name))
        {
            Items[Name]--;
            if (Items[Name] == 0)
            {
                Items.Remove(Name);
            }
            DisplayItems();
            return true;
        }
        else
        {
            Debug.Log($"Cannot consume item {Name}");
            return false;
        }
        



    }
}
