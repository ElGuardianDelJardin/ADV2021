using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blendTreeMotion : MonoBehaviour
{
    private Animator anim;
    private CharacterController charControl;

    public float gravity = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        charControl = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            anim.SetBool("Run", true);
        }
        else 
        {
            anim.SetBool("Run", false);
        }


    }
}
