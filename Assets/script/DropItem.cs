using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] List<GameObject> Items = new List<GameObject>();

    public float droopItemDistance = 0;

    float moveAmount = 0;
    Vector3 beforePos = Vector3.zero;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        moveAmount += Vector3.Distance(this.transform.position, beforePos);
        beforePos = this.transform.position;

        if(droopItemDistance < moveAmount)
        {
            moveAmount = 0;

            GameObject dropItem = Instantiate(Items[Random.Range(0,Items.Count)]);
            dropItem.transform.position = this.transform.position;
        }
    }
}
