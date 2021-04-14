using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trigger : MonoBehaviour
{
    public Animator objectToAnimate;
    public string animatorVariable;

    public Text texto;

    private bool open;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            objectToAnimate.SetBool("Trigger", true);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MainCamera")
            objectToAnimate.SetBool(animatorVariable, open);

        if (objectToAnimate.GetBool(animatorVariable)) {
            if (texto)
                texto.text = "press Space to close chest"; }
        else {
            if (texto)
                texto.text = "press Space to open chest"; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            objectToAnimate.SetBool(animatorVariable, false);
            objectToAnimate.SetBool("Trigger", false);
            if(texto)
            texto.text = "";


        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            open = !open;
    }

}
