using UnityEngine;
using UnityEngine.AI;

public class blank : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 movementInput;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        // Ta in input
        float h = Input.GetAxisRaw("Horizontal"); // A/D eller vänster/höger
        float v = Input.GetAxisRaw("Vertical");   // W/S eller upp/ner

        movementInput = new Vector3(h, v, 0f).normalized;

        if (movementInput != Vector3.zero)
        {
            MoveWithKeyboard();
        }
    }
    

    void MoveWithKeyboard()
    {
        // Bestäm ny position baserat på input
        Vector3 targetPosition = transform.position + movementInput;

        NavMeshHit hit;
        // Kontrollera om positionen är på navmesh
        if (NavMesh.SamplePosition(targetPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
