using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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

    [SerializeField] GameObject Beam;

    [SerializeField] Animator anim;
    float moveAmount = 0;
    Vector3 beforePos = Vector3.zero;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        GageColorSet();
    }

    void Update()
    {
        repairButton = false;

        switch (player)
        {
            case Player.player1:
                if (Input.GetButton("Fire1") && partsGage.value > 0)
                {
                    repairButton = true;
                }
                if (Input.GetButton("Fire2") && partsGage.value == partsGage.maxValue)
                {
                    var beam = Instantiate(Beam);
                    beam.transform.position = this.transform.position;
                    beam.transform.rotation = this.transform.rotation;
                    partsGage.value = 0;
                    GageColorSet();
                }
                break;

            case Player.player2:
                if (Input.GetButton("Fire12") && partsGage.value > 0)
                {
                    repairButton = true;
                }
                if (Input.GetButton("Fire22") && partsGage.value == partsGage.maxValue)
                {
                    var beam = Instantiate(Beam);
                    beam.transform.position = this.transform.position;
                    beam.transform.rotation = this.transform.rotation;
                    partsGage.value = 0;
                    GageColorSet();
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, beforePos) > 0.1)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        beforePos = this.transform.position;
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Items" && partsGage.maxValue > partsGage.value)
        {
            PartsGet();
            Destroy(collider.gameObject);
        }
    }

    public void RepairAnim()
    {
        anim.SetTrigger("Repair");
    }

    public void PlaySE()
    {
        audioSource.Stop();
        audioSource.time = 1.5f;
        audioSource.Play();
    }

    public void StopSE()
    {
        audioSource.Stop();
    }
}