using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField] List<GameObject> items = new List<GameObject>();

    public float itemSpawnTime = 10;
    private float itemCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        itemCount += Time.deltaTime;
        if(itemCount >= itemSpawnTime)
        {
            itemCount = 0;

            GameObject item = Instantiate(items[Random.Range(0, items.Count)]);
            Vector3 randomPos = new Vector3(Random.Range(-35f,35f), 1f, Random.Range(-25f,25f));
            item.transform.position = randomPos;
        }
    }
}
