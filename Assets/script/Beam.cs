using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 300;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
