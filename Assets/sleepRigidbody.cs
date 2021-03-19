using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepRigidbody : MonoBehaviour
{
    private Rigidbody rbGO;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
            rbGO.WakeUp();
    }

    void Start()
    {
        rbGO = gameObject.GetComponent<Rigidbody>();
        rbGO.Sleep();
    }

   
}

