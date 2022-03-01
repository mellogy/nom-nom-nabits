using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutscene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            gameObject.GetComponent<PlayableDirector>().Play();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
