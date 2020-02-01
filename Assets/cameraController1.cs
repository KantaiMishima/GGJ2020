using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController1 : MonoBehaviour
{
    [SerializeField] float angularVelocity = 30f;   //回転速度の設定
    float horizontalAngle = 0f;     //水平方向の回転量を保存
    float verticalAngle = 0f;       //垂直方向の回転量を保存

    // Update is called once per frame
    void Update()
    {
        //入力による回転量を取得
        var horizontalRotation = angularVelocity * Time.deltaTime;
        var rotation = 0f;
        if (Input.GetButton("Left2"))
        {
            rotation -= horizontalRotation;
        }
        if (Input.GetButton("Right2"))
        {
            rotation += horizontalRotation;
        }
        print(rotation);
        //回転量を更新
        horizontalAngle += rotation;
        //Transformコンポーネントに回転量を適用する
        this.gameObject.transform.rotation = Quaternion.Euler(0f, horizontalAngle, 0f);
    }
}