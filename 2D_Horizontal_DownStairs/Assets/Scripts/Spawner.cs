using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("生成物件")]
    public List<GameObject> platforms = new List<GameObject>();
    [Header("生成物件的間隔時間")]
    public float spwanTime;

    private float countTime; //紀錄時間
    private Vector3 spwanposition; //生成位置

    void Update()
    {
        SpwanPlatform();
    }

    public void SpwanPlatform()
    {
        countTime += Time.deltaTime;
        spwanposition = transform.position;
        spwanposition.x = Random.Range(-3.5f, 3.5f);

        if(countTime >= spwanTime)
        {
            createPlatform();
            countTime = 0;
        }
    }

    public void createPlatform()
    {
        int index = Random.Range(0, platforms.Count);
        int spikeNum = 0;

        if(index == 4)
        {
            spikeNum++;
        }
        if (spikeNum > 1)
        {
            spikeNum = 0;
            countTime = spwanTime;
            return;
        }
        GameObject newPlatform = Instantiate(platforms[index], spwanposition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
