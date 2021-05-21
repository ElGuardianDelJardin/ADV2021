using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float time = 5f;
    public GameObject Particles;
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Bullet")
        Invoke("destruir", 0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destruir", time);
    }

    void destruir() 
    {
        if (Particles)
            Instantiate(Particles, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
