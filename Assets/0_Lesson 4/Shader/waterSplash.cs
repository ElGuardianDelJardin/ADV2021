using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterSplash : MonoBehaviour
{
    public GameObject SplashInPrefab;
    public GameObject SplashOutPrefab;

    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(SplashInPrefab, collision.ClosestPointOnBounds(collision.attachedRigidbody.position),Quaternion.identity);
    }
    private void OnTriggerExit(Collider collision)
    {
        Instantiate(SplashOutPrefab, collision.ClosestPointOnBounds(collision.attachedRigidbody.position), Quaternion.identity);
    }
}
