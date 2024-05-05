using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]

public class Managers : MonoBehaviour
{
    public static PlayerManager Player {  get; private set; }
    public static InventoryManager Inventory {  get; private set; }

    private List<IGameManager> StartSequence;

    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        StartSequence = new List<IGameManager>();

        StartSequence.Add(Player);
        StartSequence.Add(Inventory);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager Manager in StartSequence)
        {
            Manager.StartUp();
        }

        yield return null;

        int NumberModules = StartSequence.Count;
        int NumberReady = 0;

        while (NumberReady < NumberModules)
        {
            int LastReady = NumberReady;
            NumberReady = 0;

            foreach (IGameManager Manager in StartSequence)
            {
                if (Manager.status == ManagerStatus.Started)
                {
                    NumberReady++;
                }
            }

            if (NumberReady > LastReady)
            {
                Debug.Log($"Progress: {NumberReady}/{NumberModules}");
            }

            yield return null;
        }

        Debug.Log("All Managers started up!");
    }

}
