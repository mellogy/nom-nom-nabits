using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Animator anim;
    float targetZ;
    float upZ = 0.5f;
    float downZ = -2f;

    private void Start()
    {
        targetZ = transform.position.y;
    }

    private void Update()
    {
        if (transform.position.y != targetZ)
        {
            float newY = Mathf.Lerp(transform.position.y, targetZ, 0.05f);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Follower")
        {
            targetZ = downZ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Follower")
        {
            targetZ = upZ;
        }
    }
}
