using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    private void OnGUI()
    {
        int PosX = 15;
        int PosY = 15;
        int Width = 100;
        int Height = 35;
        int Buffer = 15;

        List<string> ItemList = Managers.Inventory.GetItemList();
        if (ItemList.Count == 0 )
        {
            GUI.Box(new Rect(PosX, PosY, Width, Height), "No Items");
        }

        foreach ( string Item in ItemList )
        {
            int Count = Managers.Inventory.GetItemCount(Item);

            Texture2D Image = Resources.Load<Texture2D>($"Icons/{Item}");
            GUI.Box(new Rect(PosX, PosY, Width, Height), new GUIContent($"({Count})", Image));

            PosX += Width + Buffer;
        }

        PosX = 15;
        PosY += Height + Buffer;

        foreach ( string Item in ItemList )
        {
            if (GUI.Button(new Rect(PosX, PosY, Width, Height), $"Equip {Item}"))
            {
                Managers.Inventory.EquipItem(Item);
            }
            if(Item == "Health")
            {
                if(GUI.Button(new Rect(PosX, PosY + Height + Buffer, Width, Height), "Use Health"))
                {
                    Managers.Inventory.ConsumeItem("Health");
                    Managers.Player.ChangedHealth(25);
                }
            }
            PosX += Width + Buffer;
        }
    }
}
