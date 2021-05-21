using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class blendTreeMotion : MonoBehaviour
{
    private Animator anim;
    private CharacterController charControl;

    Camera camara;

    public float gravity = 1;

    float currentSpeed = 1f;
    public float walkSpeed = 0.025f;
    public float runSpeed = 0.075f;

    public float radius = 10f;

    public Transform composer;

    public Volume volume;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        charControl = gameObject.GetComponent<CharacterController>();

        

    }

    // Update is called once per frame
    void Update()
    {
        charControl.Move(Vector3.up * gravity * Time.deltaTime);
        if (Camera.main)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 aimDirection = new Vector3(hit.point.x + (Mathf.Tan(90 - 44.958f) * (hit.point.y - transform.position.y)), transform.position.y, hit.point.z);
                

                if (Vector3.Distance(transform.position, aimDirection) < radius)
                    composer.position = aimDirection;
                else
                {
                    aimDirection = aimDirection - transform.position;
                    aimDirection = Vector3.Normalize(aimDirection);
                    composer.position = transform.position + aimDirection * radius;
                }

                if (Vector3.Distance(transform.position, aimDirection) > 0.25f)
                    transform.LookAt(composer, Vector3.up);
            }
        }

        Vector3 moveDirecction = new Vector3(-Input.GetAxis("Vertical"),0, Input.GetAxis("Horizontal")) * currentSpeed;
        Vector3.ClampMagnitude(moveDirecction, currentSpeed);
        charControl.Move(moveDirecction * Time.deltaTime);

        Vector3 AnimDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        AnimDirection = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * AnimDirection;
        anim.SetFloat("Horizontal", -AnimDirection.x);
        anim.SetFloat("Vertical",  AnimDirection.z);

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            anim.SetBool("Run", true);
            currentSpeed = runSpeed;
        }
        else 
        {
            anim.SetBool("Run", false);
            currentSpeed = walkSpeed;
        }


    }


}
