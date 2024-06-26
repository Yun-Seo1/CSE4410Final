using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class FalsePlatform : MonoBehaviour{
    bool isFalling = false;
    float fallSpeed = 0;

    // Update is called once per frame
    void Update(){
        if(isFalling){
            AudioManager.Instance.PlaySoundEffect("TrapShake", transform.position);
            fallSpeed += Time.deltaTime / 10;
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
        }
    }
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "player"){
            isFalling = true;
        }
    }

}
