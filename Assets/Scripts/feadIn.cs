using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feadIn : MonoBehaviour
{
    [SerializeField] Image image;
    public float speed = 0.1f;
    public float acc = 0f;
    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        speed += acc;
        var color = new Color(0,0,0, Mathf.Lerp(0, 1, Time.deltaTime * speed));
        image.color -= color;
    }
}
