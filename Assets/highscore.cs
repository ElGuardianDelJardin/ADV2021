using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.SaveScore();
        gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
