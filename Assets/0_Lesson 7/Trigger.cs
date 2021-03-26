using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Animator objectToAnimate;
    public string animatorVariable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "MainCamera")
            objectToAnimate.SetBool(animatorVariable, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MainCamera")
            objectToAnimate.SetBool(animatorVariable, false);
    }
}
