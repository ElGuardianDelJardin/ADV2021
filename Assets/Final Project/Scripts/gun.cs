using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzleflash;
    public Transform Barrel;
    public float force;

    private float restTimer;
    public float maxRestTimer;
    private GameObject Player;

    public float dispersion;

    public AudioClip[] shootSouds;
    public AudioClip[] cockSounds;
    public AudioClip[] MiscSouds;
    public AudioClip[] noBulletSounds;
    public AudioClip[] UnloadSouds;
    public AudioClip[] ReloadSouds;
    private AudioSource ASouce;

    public int bullets = 10;
    public int maxbullets;
    public float reloadTime;
    private bool reloading = false;

    public Shake camara;
    // Start is called before the first frame update
    void Start()
    {
        maxbullets = bullets;
        Player = GameObject.FindGameObjectWithTag("Player");
        restTimer = maxRestTimer;
        ASouce = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(bullets < maxbullets && Input.GetKeyDown(KeyCode.R)) 
        {
            if(!reloading)
                StartCoroutine("Reload");
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && !reloading)
        {
            if (restTimer <= 0)
            {
                ASouce.PlayOneShot(cockSounds[Random.Range(0, cockSounds.Length)]);
                Player.GetComponent<Animator>().SetBool("Rest", false);
                restTimer = maxRestTimer;
                return;
            }
            restTimer = maxRestTimer;

            if (bullets > 0)
            {
                Instantiate(muzzleflash, Barrel.position, Barrel.rotation, Barrel);

                GameObject BulletInstance = Instantiate(bullet, Barrel.position, Barrel.rotation, Barrel);
                BulletInstance.transform.parent = null;
                BulletInstance.AddComponent<Rigidbody>();
                BulletInstance.GetComponent<Rigidbody>().useGravity = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Vector3 aimDirection = new Vector3(hit.point.x + (Mathf.Tan(90 - 44.958f) * (Player.transform.position.y - hit.point.y)), transform.position.y, hit.point.z);
                        
                    aimDirection = aimDirection - Barrel.position;
                    aimDirection = Quaternion.AngleAxis(Random.Range(-dispersion, dispersion), Vector3.up) * aimDirection;
                    aimDirection = Vector3.Normalize(aimDirection);


                    BulletInstance.GetComponent<Rigidbody>().AddForce(aimDirection * force, ForceMode.VelocityChange);
                }
                else
                {
                    BulletInstance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);
                }
                ASouce.PlayOneShot(shootSouds[Random.Range(0, shootSouds.Length)]);
                camara.ShakeCam(3, 0.5f);
                bullets--;

                GameManager.ShowAmmo(bullets);
            }
            else 
            {
                ASouce.PlayOneShot(noBulletSounds[Random.Range(0, noBulletSounds.Length)]);
            }
            
        }

        if(restTimer>0)
            restTimer -= Time.deltaTime;
        if (restTimer < 0)
        {
            ASouce.PlayOneShot(MiscSouds[Random.Range(0, MiscSouds.Length)]);
            Player.GetComponent<Animator>().SetBool("Rest", true);
            restTimer = 0;
        }


        if (Player.GetComponent<Animator>().GetBool("Run"))
            dispersion = 7;
        else
            dispersion = 3;


    }

    public IEnumerator Reload()
    {
        reloading = true;
        ASouce.PlayOneShot(UnloadSouds[Random.Range(0, UnloadSouds.Length)]);
        yield return new WaitForSeconds(reloadTime);
        ASouce.PlayOneShot(ReloadSouds[Random.Range(0, ReloadSouds.Length)]);
        yield return new WaitForSeconds(0.1f);
        bullets = maxbullets;
        reloading = false;

        GameManager.ShowAmmo(bullets);
    }
}
