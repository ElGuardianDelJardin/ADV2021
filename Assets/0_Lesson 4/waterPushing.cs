using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterPushing : MonoBehaviour
{
    public Vector3 pushForce;
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>() && other.transform.tag != "rock")
            other.GetComponent<Rigidbody>().AddForce(pushForce * Time.deltaTime,ForceMode.VelocityChange);
    }
    
}
