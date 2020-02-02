using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    [SerializeField] List<GameObject> Items = new List<GameObject>();

    public float droopItemInterval = 0;
    public float randomRange = 1;

    float moveAmount = 0;
    Vector3 beforePos = Vector3.zero;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        moveAmount += Vector3.Distance(this.transform.position, beforePos);
        beforePos = this.transform.position;

        if (droopItemInterval < Time.time - startTime)
        {
            startTime = Time.time;

            GameObject dropItem = Instantiate(Items[Random.Range(0, Items.Count)]);
            var pos = this.transform.position;
            var random = new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));
            dropItem.transform.position = pos + random;
        }
    }
    private void OnTriggerStay(Collider collider)
    {

        if (collider.tag == "Player1" || collider.tag == "Player2")
        {
            startTime = Time.time;
        }
    }
}
