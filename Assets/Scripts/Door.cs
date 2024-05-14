using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 dPos;

    private bool _Open;
    private bool isOpen = false;


    public void Operate()
    {
        if (_Open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        AudioManager.Instance.PlayDoorSound(transform.position);
        _Open = !_Open;
    }

    public void Activate()
    {
        if (!_Open)
        {
            Vector3 Pos = transform.position + dPos;
            transform.position = Pos;
            _Open = true;
        }
    }

    public void Deactivate()
    {
        if ( _Open)
        {
            Vector3 Pos = transform.position - dPos;
            transform.position = Pos;
            _Open = false;
        }
    }
}
