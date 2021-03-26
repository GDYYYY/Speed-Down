using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Platforms;

    public float spawnTime;

    private float countTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= spawnTime)
        {
            SpawnPlatforms();
            countTime = 0;
        }
    }
    

   public void SpawnPlatforms()
   {
       Vector3 spawnPosition = transform.position;
       spawnPosition.x = Random.Range(-3.5f, 3.5f);
       int index = Random.Range(0, Platforms.Count);
       GameObject go = Instantiate(Platforms[index], spawnPosition, Quaternion.identity);
       go.transform.SetParent(this.gameObject.transform);
   }
}
