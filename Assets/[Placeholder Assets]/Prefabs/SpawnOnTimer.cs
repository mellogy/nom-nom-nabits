using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTimer : MonoBehaviour
{
    public GameObject toSpawn;
    public Transform[] spawnPoints;
    public float timer = 5f;
    public bool off = false;

    private float current;

    // Start is called before the first frame update
    void Start()
    {
        current = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!off)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position;
                Instantiate(toSpawn, spawnPoint, Quaternion.identity);
                timer = current;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
