using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class blank2 : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector2 moveInput;
    private Vector2 screenBoundary;

    private PlayerHide playerHide;

    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotationSpeed = 720f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        playerHide = GetComponent<PlayerHide>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        bool canWalk = playerHide != null ? playerHide.CanMove() : true;

        if (canWalk && moveInput != Vector2.zero)
        {
            MoveWithKeyboard();
        }

        // Clamp position inside screen bounds
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(transform.position.x, -screenBoundary.x, screenBoundary.x),
            Mathf.Clamp(transform.position.y, -screenBoundary.y, screenBoundary.y),
            transform.position.z
        );
        transform.position = clampedPos;
    }

    void MoveWithKeyboard()
    {
        // Create movement vector for NavMesh (X/Y plane for 2D top-down)
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f).normalized * moveSpeed;
        Vector3 targetPosition = transform.position + movement * Time.deltaTime;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, 0.3f, NavMesh.AllAreas))
        {
            agent.Move(movement * Time.deltaTime);
        }

        // Smooth rotation toward movement direction
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(moveInput.x, moveInput.y, 0f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
