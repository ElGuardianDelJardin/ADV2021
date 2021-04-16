using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, target1.transform.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, target2.transform.position);
    }
}
