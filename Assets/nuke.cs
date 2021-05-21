using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GameObject.FindObjectsOfType<enemyBlendTree>().Length; i++)
            Destroy(GameObject.FindObjectsOfType<enemyBlendTree>()[i].gameObject);
    }
}
