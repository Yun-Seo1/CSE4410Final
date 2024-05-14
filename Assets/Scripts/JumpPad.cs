using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpSpeed;
    public RelativeMovement relativeMovement;
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch(hit.gameObject.tag)
        {
            case "SpeedBoost":
                
                relativeMovement.moveSpeed = MoveSpeed;
                break;
            case "JumpBoost":
                AudioManager.Instance.PlaySoundEffect("JumpPad", transform.position);
                relativeMovement.jumpSpeed = JumpSpeed;
                break;
            case "Untagged":
                relativeMovement.jumpSpeed = 15.0f;
                relativeMovement.moveSpeed = 6.0f;
                break;
        }
    }
}
