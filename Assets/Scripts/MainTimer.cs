using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTimer : MonoBehaviour
{
    public float timeLimit = 100;
    private float startTime;
    public int remainingTime;
    public GameObject[] Towers;
    public string WinScene1P;
    public string WinScene2P;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time - startTime;
        remainingTime = Mathf.CeilToInt(timeLimit - time);

        if (remainingTime <= 0) {
            Time.timeScale = 0;

            int point1P = 1;
            int point2P = 2;
            // TODO: 計算処理
            if (point1P > point2P)
            {
                SceneManager.LoadScene(WinScene1P);
            }
            if (point1P < point2P)
            {
                SceneManager.LoadScene(WinScene2P);
            }
        }
    }
}
