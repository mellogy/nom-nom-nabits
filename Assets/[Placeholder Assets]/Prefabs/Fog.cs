using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Destroy", true);
            Invoke("Die", 1f);
        }    
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
