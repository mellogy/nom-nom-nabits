using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathRenderer : MonoBehaviour
{
    public LineRenderer line;
    public GameObject target;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        UpdatePath();
    }

    public void UpdatePath()
    {
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(player.transform.position, target.transform.position, 1, path);
        Vector3[] corners = path.corners;
        line.SetPositions(corners);
    }
}
