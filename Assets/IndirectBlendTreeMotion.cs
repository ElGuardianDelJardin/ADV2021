using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IndirectBlendTreeMotion : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    Animator animatorPersonaje;
    public Transform MarcaDestino;
    Camera camara;
    public float runDistance;
    public AudioClip clip;

    float currentSpeed;
    float walkSpeed = 3.5f;
    float runSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorPersonaje = GetComponent<Animator>();
        camara = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        



        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                MarcaDestino.gameObject.SetActive(false);
                agent.destination = MarcaDestino.position = hit.point;
                MarcaDestino.gameObject.SetActive(true);
                MarcaDestino.GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }

        if (Vector3.Distance(MarcaDestino.position, transform.position) > runDistance)
        {
            animatorPersonaje.SetBool("Run", true);
            currentSpeed = runSpeed;
            agent.speed = currentSpeed;
        }
        else
        {
            animatorPersonaje.SetBool("Run", false);
            currentSpeed = walkSpeed;
            agent.speed = currentSpeed;
        }


        if (agent.isOnOffMeshLink)
        {
            animatorPersonaje.SetTrigger("jump");
            agent.speed = walkSpeed;
            animatorPersonaje.applyRootMotion = false;
        }
        else 
        { 
            animatorPersonaje.ResetTrigger("jump");
            agent.speed = currentSpeed;

            if (Vector3.Distance(MarcaDestino.position, transform.position) < 1f || agent.velocity.magnitude < 2f)
                animatorPersonaje.applyRootMotion = false;
            else
                animatorPersonaje.applyRootMotion = true;

        }

        animatorPersonaje.SetFloat("Vertical", transform.InverseTransformDirection(agent.velocity).z);
        animatorPersonaje.SetFloat("Horizontal", transform.InverseTransformDirection(agent.velocity).x);
    }
}
