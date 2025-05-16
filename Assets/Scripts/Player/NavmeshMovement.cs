using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshMovement : MonoBehaviour
{
    public Camera mainCamera;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToMouseClick();
        }   
    }

    void MoveToMouseClick()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        NavMeshHit hit;
        if(NavMesh.SamplePosition(mouseWorldPosition, out hit, 0.5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
