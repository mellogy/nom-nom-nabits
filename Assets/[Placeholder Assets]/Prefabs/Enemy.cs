using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public GameObject deathParticle;
    public NavMeshAgent agent;
    public Animator anim;
    public SpriteRenderer sprite;
    public SpriteRenderer item;
    public float aggroRange = 6f;
    public float passRange = 12f;
    public float wanderTimer = 4f;
    public int health = 1;
    public float wanderRange = 3f;
    public Sprite[] heldItems;

    private bool isAggro = false;
    public float timeToWander = 0f;

    private void Start()
    {
        agent.updateRotation = false;
        target = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        item.sprite = heldItems[Random.Range(0, heldItems.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= aggroRange && isAggro == false)
        {
            isAggro = true;
        }
        else if (Vector3.Distance(target.transform.position, transform.position) >= passRange && isAggro == true)
        {
            isAggro = false;
        }

        if (isAggro)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            timeToWander -= Time.deltaTime;
            if (timeToWander <= 0f)
            {
                Vector2 dir = Random.insideUnitCircle;
                float dist = Random.Range(1f, wanderRange);
                agent.destination = transform.position + new Vector3(dir.x * dist, 0, dir.y * dist);
                timeToWander = wanderTimer;
            }
        }

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        CameraShake.Shake(0.25f, .2f);
        Instantiate(deathParticle, transform.position, Quaternion.identity);
    }
}
