using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamStart : MonoBehaviour
{
    private float startTime;
    [SerializeField] private float desTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > desTime)
        {
            Destroy(this.gameObject);
        }
    }
}
