using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject MainTimer;
    private MainTimer timer;
    [SerializeField]
    private TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        timer = MainTimer.GetComponent<MainTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = timer.remainingTime.ToString("000");
    }
}
