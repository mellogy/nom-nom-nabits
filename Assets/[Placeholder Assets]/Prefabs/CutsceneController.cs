using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    public PlayableDirector timeline;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeline.Play();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
