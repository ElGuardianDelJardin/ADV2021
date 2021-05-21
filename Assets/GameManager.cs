using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static int score = 0;
    private static int lives = 3;
    private static Text uiScore;

    public static RawImage[] bullets;

    private void Start()
    {
        uiScore = GameObject.Find("SCORE").GetComponent<Text>();
        bullets = GameObject.Find("UIBullets").transform.GetComponentsInChildren<RawImage>();
    }
    public static void IncreaseScore()
    {
        score++;
        uiScore.text = "" + score;
    }
    public static int GetScore()
    {
        return score;
    }
    public static void ShowAmmo(int currentBullets) 
    {
        for (int i = 0; i < currentBullets; i++)
            bullets[i].gameObject.SetActive(true);

        for (int i = currentBullets; i < bullets.Length; i++)
            bullets[i].gameObject.SetActive(false);
    }

    public static void SaveScore()
    {
        if (!PlayerPrefs.HasKey("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", 0);

        if(score > PlayerPrefs.GetInt("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", score);
    }

        public static void ResetScore() 
    {
        score = 0;
    }


}
