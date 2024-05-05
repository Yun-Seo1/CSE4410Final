using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {  get; private set; }

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public void StartUp()
    {
        Debug.Log("Player manager starting...");

        Health = 50;
        MaxHealth = 100;




        status = ManagerStatus.Started;
    }

    public void ChangedHealth(int Value)
    {
        Health += Value;
        //To not exceed max health or go into the negative
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        Debug.Log($"Health: {Health}/{MaxHealth}");
    }
}
