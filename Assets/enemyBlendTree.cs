using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBlendTree : MonoBehaviour
{
    public Transform Player;

    public Transform goal;
    NavMeshAgent agent;
    Animator animatorPersonaje;
    public Transform MarcaDestino;

    public float runDistance;

    float currentSpeed;
    float walkSpeed = 1.75f;
    float runSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorPersonaje = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = MarcaDestino.position = Player.position;


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
