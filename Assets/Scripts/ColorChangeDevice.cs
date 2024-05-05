using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : MonoBehaviour
{
    public void Operate()
    {
        float RandomRed = Random.Range(0f, 1f);
        float RandomGreen = Random.Range(0f, 1f);
        float RandomBlue = Random.Range(0f, 1f);

        Renderer R = GetComponent<Renderer>();

        R.material.color = new Color(RandomRed, RandomGreen, RandomBlue);
    }
}
