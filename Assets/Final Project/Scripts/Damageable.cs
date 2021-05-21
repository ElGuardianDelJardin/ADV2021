using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    int health = 3;
    bool invincible;
    public float invincibleTime;
    public Shake camara;

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Enemy")
        {
            if (other.tag == "Bullet" && !invincible)
            {
                invincible = true;
                health--;
                StartCoroutine("Invencible");
            }
        }
        else
        {
            if (other.tag == "Damage" && !invincible)
            {
                invincible = true;
                health--;
                gameObject.GetComponent<Animator>().SetTrigger("Hurt");
                StartCoroutine("Invencible");
                camara.ShakeCam(5, 1f);
            }
        }
    }
    

    public IEnumerator Invencible() 
    {

        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if(!gameObject.GetComponent<Animator>().GetBool("Die")){
                gameObject.GetComponent<Animator>().SetBool("Die", true);
                if (gameObject.tag != "Player")
                {
                    GameManager.IncreaseScore();
                    gameObject.AddComponent<Destruir>();
                    gameObject.GetComponent<enemyBlendTree>().agent.speed = 0;
                    Destroy(gameObject.GetComponent<enemyBlendTree>());
                    Destroy(gameObject.GetComponent<Damageable>());

                }
                else
                {
                    Destroy(gameObject.GetComponent<blendTreeMotion>());
                    Destroy(GameObject.Find("Pistol").GetComponent<gun>());
                    Destroy(gameObject.GetComponent<Damageable>());
                }
            }
        }
    }


}
