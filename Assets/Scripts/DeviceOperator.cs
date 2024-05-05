using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            Collider[] HitColliders =
                Physics.OverlapSphere(transform.position, radius);

            foreach (Collider Collider in HitColliders) 
            {
                Vector3 HitPosition = Collider.transform.position;
                HitPosition.y = transform.position.y;

                Vector3 Direction = HitPosition - transform.position;

                if (Vector3.Dot(transform.forward, Direction.normalized) > 0.2f)
                {
                    Collider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }


                
            }
        }
    }
}
