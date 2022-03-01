using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnding : MonoBehaviour
{
    public GameObject toActivate;

    public void Update()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        if (spawners.Length<1)
        {
            toActivate.SetActive(true);
        }
    }
}
