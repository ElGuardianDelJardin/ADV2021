using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{


    public GameObject Parent;
    public Transform Obj; // The object to place the camera on
    public float Radius = 4.5f;
    private float Dist;
    private Vector3 MousePos1;
    private Vector3 MousePos2;
    private Vector3 ScreenMouse;
    private Vector3 MouseOffset;
    private float z;
    private float x;

    public Vector3 offset;


    private void Awake()
    {
        Parent = GameObject.FindGameObjectWithTag("Player");
        Obj = transform;
    }


    void Update()
    {
        if (Parent != null && Obj != null)
        {
            if (Parent != null && Obj != null)
            {
                MousePos1 = Input.mousePosition;
                ScreenMouse = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(MousePos1.x, MousePos1.y, Obj.position.z - GetComponent<Camera>().transform.position.z));
                MouseOffset = ScreenMouse - Parent.transform.position;

                MousePos2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
                z = (float)((MousePos2.y - Parent.transform.position.z) / 2.0) + Parent.transform.position.z;
                x = (float)((MousePos2.x - Parent.transform.position.x) / 2.0) + Parent.transform.position.x;
                Obj.position = new Vector3(x, Obj.position.y, z) + offset;


                Dist = Vector2.Distance(new Vector2(Obj.position.x, Obj.position.z), new Vector2(Parent.transform.position.z, Parent.transform.position.z));

                if (Dist > Radius)
                {

                    Vector3 norm = MouseOffset.normalized;
                    z = Mathf.RoundToInt(norm.y * Radius + Parent.transform.position.z);
                    x = Mathf.RoundToInt(norm.x * Radius + Parent.transform.position.x);
                    Obj.position = new Vector3(x, Obj.position.y, z) + offset;
                }


            }
        }
    }
}