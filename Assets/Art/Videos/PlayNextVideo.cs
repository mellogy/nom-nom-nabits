using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayNextVideo : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject nextPlayer;

    public void Update()
    {
        if (player.frame == (long)player.frameCount-1)
        {
            nextPlayer.SetActive(true);
            Destroy(gameObject);
        }
    }
}
