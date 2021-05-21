using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBlendTree : MonoBehaviour
{
    public Transform Player;

    public Transform goal;
    public NavMeshAgent agent;
    Animator animatorPersonaje;

    public float runDistance;

    float currentSpeed;
    public float walkSpeed = 1f;
    public float runSpeed = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animatorPersonaje = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Player.position;


        if (Vector3.Distance(Player.position, transform.position) > runDistance)
        {
            animatorPersonaje.SetBool("Run", true);
            currentSpeed = runSpeed;
            agent.speed = currentSpeed;
        }
        else
        {
            animatorPersonaje.SetBool("Run", false);
            animatorPersonaje.SetBool("Attack", true);
            currentSpeed = walkSpeed;
            agent.speed = currentSpeed;
        }




        animatorPersonaje.SetFloat("Vertical", transform.InverseTransformDirection(agent.velocity).z);
        animatorPersonaje.SetFloat("Horizontal", transform.InverseTransformDirection(agent.velocity).x);
    }

    public void Attack()
    {
        transform.Find("Attack").gameObject.SetActive(!transform.Find("Attack").gameObject.activeInHierarchy);
    }
}
