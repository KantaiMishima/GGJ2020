using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(90, 90, 90) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        print("a");
    }
}
