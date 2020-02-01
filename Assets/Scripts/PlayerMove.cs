using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string playerPrefix = "";
    [SerializeField] float speed = 30f;
    private Rigidbody rg;

    void Start()
    {
        rg = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = speed * Input.GetAxis("Horizontal" + playerPrefix);
        var vertical = speed * Input.GetAxis("Vertical" + playerPrefix);
        rg.velocity = - this.transform.forward * vertical + this.transform.right * horizontal;
    }
}
