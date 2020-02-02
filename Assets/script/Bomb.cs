using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject boomParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(0f, 2f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.transform.tag == "Player1" || other.transform.tag == "Player2")
        {
            GameObject boom = Instantiate(boomParticle);
            boom.transform.position = this.transform.position;

            PlayerDates playersc = other.GetComponent<PlayerDates>();
            playersc.PartsOut(10);

            Destroy(boom.gameObject, 2);
            Destroy(this.gameObject);
        }
    }
}
