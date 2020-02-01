using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    float Count = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Count += Time.deltaTime;
        if(Count > 0)
        {
            this.gameObject.tag = "Items";
            Destroy(this);
        }
    }
}
