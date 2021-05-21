using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSoundsManagement : MonoBehaviour
{
    public AudioClip[] stepSouds;
    public AudioClip[] RunstepSouds;
    public AudioClip[] Voice;
    public AudioClip[] Hit;

    public GameObject DeathPanel;

    private AudioSource ASouce;
    // Start is called before the first frame update
    void Start()
    {
        ASouce = gameObject.GetComponent<AudioSource>();
    }
    public void Step()
    {
        ASouce.PlayOneShot(stepSouds[Random.Range(0, stepSouds.Length)]);
    }

    public void RunSteps()
    {
        ASouce.PlayOneShot(RunstepSouds[Random.Range(0, RunstepSouds.Length)]);
    }

    public void Vocals()
    {
        ASouce.PlayOneShot(Hit[Random.Range(0, Hit.Length)]);
        ASouce.PlayOneShot(Voice[Random.Range(0, Voice.Length)]);
    }


    public void Die()
    {
        DeathPanel.SetActive(true);
    }
}
