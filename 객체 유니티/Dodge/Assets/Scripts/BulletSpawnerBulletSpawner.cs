using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefam;
    public float spawnRAteMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 8f;
        spawnRate = Random.RandomRange(spawnRAteMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefam, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRAteMin, spawnRateMax);
        }
    }
}
