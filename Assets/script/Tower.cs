using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int player1PartsNum;//このタワーがもっているPlayer1のパーツ数
    public int player2PartsNum;//このタワーがもっているPlayer2のパーツ数

    public int maxPartsNum = 30;

    [SerializeField] PlayerDates player1Date;
    [SerializeField] PlayerDates player2Date;

    Renderer testMaterial;

    [SerializeField] GameObject player1Area;
    [SerializeField] GameObject player2Area;
    GameObject areaOb = null;

    public enum TowerType
    {
        NoPlayer,
        Player1,
        Player2
    }
    public TowerType towerType;

    private float player1RepairCT = 0;
    private float player2RepairCT = 0;

    void Start()
    {
        testMaterial = this.GetComponentInChildren<Renderer>();
    }
    private void FixedUpdate()
    {
        switch (towerType)
        {
            case TowerType.NoPlayer:
                if(player1PartsNum == 0 && player2PartsNum == 0)
                {
                    testMaterial.material.color = new Color(0f, 0f, 0f, 1f);
                }
                else if(player1PartsNum > 0)
                {
                    testMaterial.material.color = new Color(0.5f, 0f, 0f, 1f);
                }
                else
                {
                    testMaterial.material.color = new Color(0f, 0f, 0.5f, 1f);
                }

                if (player1PartsNum > 10)
                {
                    ChangePlayer1Tower();
                }//10個以上パーツを入れたプレイヤーのタワーになる
                if (player2PartsNum > 10)
                {
                    ChangePlayer2Tower();
                }
                break;

            case TowerType.Player1:

                areaOb.transform.localScale = new Vector3(player1PartsNum, 0.75f, player1PartsNum);
                if(player1PartsNum <= 0)
                {
                    ChangeTowerNoPlayer();
                }

                break;

            case TowerType.Player2:

                areaOb.transform.localScale = new Vector3(player2PartsNum,0.75f, player2PartsNum);
                if(player2PartsNum <= 0)
                {
                    ChangeTowerNoPlayer();
                }

                break;
        }

        player1RepairCT += Time.deltaTime;
        player2RepairCT += Time.deltaTime;
    }

    private void OnTriggerStay(Collider collider)
    {
        
        if(collider.tag == "Player1" && player1Date.repairButton)
        {
            if(player2PartsNum == 0 && player1RepairCT >= player1Date.repairTime && maxPartsNum > player1PartsNum)
            {
                player1PartsNum++;
                player1RepairCT = 0;

                Player1PartsOut();
            }
            else if(player1RepairCT >= player1Date.destroyTime)
            {
                player2PartsNum--;
                player1RepairCT = 0;

                Player1PartsOut();
            }
        }

        if(collider.tag == "Player2"&& player2Date.repairButton)
        {
            if(player1PartsNum == 0 && player2RepairCT >= player2Date.repairTime && maxPartsNum > player2PartsNum)
            {
                player2PartsNum++;
                player2RepairCT = 0;

                Player2PartsOut();
            }
            else if(player2RepairCT >= player2Date.destroyTime)
            {
                player1PartsNum--;
                player2RepairCT = 0;

                Player2PartsOut();
            }
        }
    }

    void ChangeTowerNoPlayer()
    {
        towerType = TowerType.NoPlayer;

        AreaDeleet();
    }
    void ChangePlayer1Tower()
    {
        towerType = TowerType.Player1;

        AreaDeleet();
        areaOb = Instantiate(player1Area);
        areaOb.transform.position = this.transform.position;
        Debug.Log(this.name);

        ChangeColorForTower changeColor = this.GetComponentInChildren<ChangeColorForTower>();
        changeColor.SetColor(true);

    }//Player1のタワーに変更
    void ChangePlayer2Tower()
    {
        towerType = TowerType.Player2;

        AreaDeleet();
        areaOb = Instantiate(player2Area);
        areaOb.transform.position = this.transform.position;
        Debug.Log(player2Area.transform.position);

        ChangeColorForTower changeColor = this.GetComponentInChildren<ChangeColorForTower>();
        changeColor.SetColor(true);
    }//Player2のタワーに変更
    void AreaDeleet()
    {
        if(areaOb != null)
        {
            Destroy(areaOb);
            areaOb = null;
        }
    }

    void Player1PartsOut()
    {
        player1Date.PartsOut();
    }
    void Player2PartsOut()
    {
        player2Date.PartsOut();
    }
}