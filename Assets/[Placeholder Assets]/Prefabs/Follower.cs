using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public GameObject bullet2;
    public NavMeshAgent agent;
    public Animator anim;
    public SpriteRenderer sprite;

    float cooldown = .2f;

    private void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        if (agent.destination.x < transform.position.x) { sprite.flipX = false; }
        if (agent.destination.x > transform.position.x) { sprite.flipX = true; }

        if (agent.velocity.magnitude > 0f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (cooldown > 0) { cooldown -= Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.E) && cooldown <= 0)
        {
            GameObject t = FindClosestEnemy();
            if (FindClosestEnemy())
            {
                GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                b.transform.localScale = new Vector3(.2f, .2f, .2f);
                b.GetComponent<Bullet>().target = t;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && cooldown <= 0 && GameObject.FindObjectOfType<PlayerMovement>().hasShield)
        {
            GameObject t = FindClosestSpawner();
            if (FindClosestEnemy())
            {
                GameObject b = Instantiate(bullet2, transform.position, Quaternion.identity);
                b.transform.localScale = new Vector3(.2f, .2f, .2f);
                b.GetComponent<Bullet>().target = t;
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    GameObject FindClosestSpawner()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Spawner");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
