using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroollMaterial : MonoBehaviour
{
    private Renderer rend;
    float scrollSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float _offset = Time.time * scrollSpeed;
        _offset = Mathf.Repeat( _offset, 1F);
        rend.material.SetTextureOffset("_MainTex", new Vector2( 0F, _offset ));
    }
}
