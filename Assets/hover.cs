using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    private void FixedUpdate()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 force;
        Vector3 tmp = GameObject.Find(this.gameObject.name).transform.position;
        //if (tmp.y <=6)
        //{
        //    force = new Vector3(0.0f, 10.4f, 0.0f);
        //} else if (tmp.y <= 6.9)
        //{
        //    force = new Vector3(0.0f, 10.2f, 0.0f);
        //}else if (tmp.y <= 7)
        //{
        //    force = new Vector3(0.0f, 10.0f, 0.0f);
        //}else 
        if (tmp.y > 7)
        {
            force = new Vector3(0.0f, 9.4f, 0.0f);
        }else if (tmp.y > 7.1)
        {
            force = new Vector3(0.0f, 9.2f, 0.0f);
        }
        else
        {
            force = new Vector3(0.0f, 9.0f, 0.0f);
        }
        force = new Vector3(0.0f, 8.66f, 0.0f);

        rb.AddForce(force);


    }
}
