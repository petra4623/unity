using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    public GameObject level;
    public GameObject bullerSpawnerPrefab;
    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime;
    private bool isgameover;
    void Start()
    {
        surviveTime = 0;
        isgameover = false;

        bulletSpawners[0].x = -8f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 8f;

        bulletSpawners[1].x = 8f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 8f;

        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -8f;

        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isgameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;

            if (surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime>= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime>= 5f && surviveTime <10f && spawnCounter ==2)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletSpawner = Instantiate(bullerSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void EndGame()
    {
        isgameover = true;
        gameoverText.SetActive(true);
        float besttime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > besttime)
        {
            besttime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", besttime);
        }

        recordText.text = "Best Time: " + (int)besttime;
    }
}
