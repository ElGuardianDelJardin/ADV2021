using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class skipAnim : MonoBehaviour
{

    public void skip() 
    {
        gameObject.GetComponent<PlayableDirector>().time = gameObject.GetComponent<PlayableDirector>().duration;
    }

    public void ReloadScene()
    {
        GameManager.ResetScore();
        SceneManager.LoadScene(0);
    }
}
