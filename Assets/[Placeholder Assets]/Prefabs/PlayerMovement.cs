using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public NavMeshAgent agent;
    public Animator anim;
    public SpriteRenderer sprite;
    public GameObject stepIndicator;
    public bool canMove = false;
    public bool hasKey = false;
    public bool hasShield = false;
    public GameObject naviTarget;
    public LineRenderer pathRender;

    private NavMeshPath navPath;
    
    private Vector3[] corners;

    private void Start()
    {
        agent.updateRotation = false;
        //pathRender = GetComponentInChildren<LineRenderer>();

        //UpdatePath();
    }

    private void UpdatePath()
    {
        NavMesh.CalculatePath(transform.position, naviTarget.transform.position, 0, navPath);
        corners = navPath.corners;
        pathRender.SetPositions(corners);
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
                Instantiate(stepIndicator, hit.point, Quaternion.identity);

                if (hit.point.x < transform.position.x) { sprite.flipX = false; }
                if (hit.point.x > transform.position.x) { sprite.flipX = true; }
            }

        }

        if (agent.velocity.magnitude > 0f)
        {
            anim.SetBool("isWalking", true);
            //UpdatePath();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
