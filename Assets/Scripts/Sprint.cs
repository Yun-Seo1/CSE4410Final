using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class Sprint : MonoBehaviour
{
    public RelativeMovement RelativeMovement;

    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _SprintSpeed;


    private bool _Grounded = true;

    public KeyCode SprintKey = KeyCode.LeftShift;

    public MovementState State;

    public enum MovementState
    {
        Walking,
        Sprinting,
        air
    }
    // Update is called once per frame
    void Update()
    {
        StateHandler(); 
    }

    private void StateHandler()
    {
        if (_Grounded && Input.GetKey(SprintKey))
        {
            State = MovementState.Sprinting;
            RelativeMovement.moveSpeed = _SprintSpeed;

        }
        else if (_Grounded)
        {
            State = MovementState.Walking;
            RelativeMovement.moveSpeed = _MovementSpeed;
        }
        else
        {
            State = MovementState.air;
        }
    }
}
