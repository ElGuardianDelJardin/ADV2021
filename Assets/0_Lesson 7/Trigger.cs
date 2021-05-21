using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trigger : MonoBehaviour
{
    public GameObject[] Enable;
    public GameObject[] Disable;

    public int MinScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < Enable.Length; i++)
                Enable[i].SetActive(true);

            for (int i = 0; i < Disable.Length; i++)
                Disable[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(GameManager.GetScore() >= MinScore) 
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
