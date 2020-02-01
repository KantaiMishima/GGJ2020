using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChangeColorForTower : MonoBehaviour
{
    // From inspector.
    List<Renderer> childObjects = new List<Renderer>();


    void Start()
    {
        foreach (Transform _child in transform)
        {
            Renderer _ren = _child.GetComponent<Renderer>();
            if(_ren != null)
            {
                childObjects.Add(_ren);
            }
        }

        SetColor( false);
    }

    //カラーを変更するときに、呼び出す。
    public void SetColor( bool isPlayer1)
    {
        Color _color = Color.blue;
        if(isPlayer1)
        {
            _color = Color.red;
        }

        //マテリアル変更
        foreach( Renderer _ren in childObjects)
        {
            Debug.Log("hello");
            _ren.material.SetColor( "_Color", _color);
        }
    }
}
