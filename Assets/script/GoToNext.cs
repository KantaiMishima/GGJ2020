using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNext : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (audioSource)
            {
                audioSource.Play();
            }
            SceneManager.LoadScene(nextScene);
        }
    }
}
