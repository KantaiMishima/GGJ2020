using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDates : MonoBehaviour
{
    public bool repairButton = false;

    public float repairTime = 1;
    public float destroyTime = 1;

    enum Player
    {
        player1,
        player2
    }
    [SerializeField] Player player;

    [SerializeField] Slider partsGage;
    [SerializeField] Image gageColor;

    void Start()
    {
        GageColorSet();
    }

    void Update()
    {
        repairButton = false;

        switch (player)
        {
            case Player.player1:
                if (Input.GetKey(KeyCode.A) && partsGage.value > 0)
                {
                    repairButton = true;
                }
                if(Input.GetKeyDown(KeyCode.Alpha1))
                {
                    PartsGet();
                }
                break;

            case Player.player2:
                if (Input.GetKey(KeyCode.B) && partsGage.value > 0)
                {
                    repairButton = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    PartsGet();
                }
                break;
        }
    }

    public void PartsGet()
    {
        partsGage.value++;
        GageColorSet();
    }
    public void PartsOut()
    {
        partsGage.value--;
        GageColorSet();
    }
    public void GageColorSet()
    {
        gageColor.color = Color.green;
        if (GageParcent() <= 0.5f)
        {
            gageColor.color = Color.yellow;
        }
        if(GageParcent() <= 0.2f)
        {
            gageColor.color = Color.red;
        }
        if(GageParcent() == 0)
        {
            gageColor.color = Color.black;
        }

        float GageParcent()
        {
            return partsGage.value / partsGage.maxValue;
        }
    }
}