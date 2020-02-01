using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorForTower : MonoBehaviour
{
    // From inspector.
    List<Renderer> childObjects = new List<Renderer>();
    Animator animCtr; 


    void Start()
    {
        //初期化
        animCtr = this.gameObject.GetComponent<Animator>();
        BreakTower();

        foreach (Transform _child in transform)
        {
            Renderer _ren = _child.GetComponent<Renderer>();
            if(_ren != null)
            {
                childObjects.Add(_ren);
            }
        }

        /*!!!!!!!!!!! テストコードです !!!!!!!!!!!!!!!*/
        BreakTower();
        SetColor( false);
    }

    //タワーを倒す
    public void BreakTower()
    {
        animCtr.SetBool("isBuild", false);
        SetNormalColor();
    }

    //タワーを
    public void BuildTower()
    {
        animCtr.SetBool( "isBuild", true);
    }


    //タワーのカラーを変更するときに、呼び出す。
    public void SetColor( bool isPlayer1)
    {
        Color _color = Color.blue;
        if(isPlayer1)
        {
            _color = Color.red;
        }

        SetTowerColor( _color);
    }

    public void SetNormalColor()
    {
        Color _color = Color.gray;
        SetTowerColor( _color);
    }

    void SetTowerColor( Color _color)
    {
        //マテリアル変更
        foreach( Renderer _ren in childObjects)
        {
            _ren.material.SetColor( "_Color", _color);
        }
    }
}
