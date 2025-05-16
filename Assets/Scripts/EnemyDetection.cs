
using UnityEngine;



public class EnemyDetection : MonoBehaviour

{

    public Transform player; 

    public float detectionRadius = 35f;

    public float moveSpeed = 5f; 



    private Vector3 originalPosition; 

    private bool isPlayerDetected = false; 



    private void Start()

    {

       

        originalPosition = transform.position;

    }



    private void Update()

    {

        Vector3 targetPosition = isPlayerDetected ? player.position : originalPosition;

        MoveToPosition(targetPosition);

    }



    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.transform == player)

        {

            Debug.Log("Player detected!");

            isPlayerDetected = true;

        }

    }



    private void OnTriggerExit2D(Collider2D other)

    {

        if (other.transform == player)

        {

            Debug.Log("Player escaped!");

            isPlayerDetected = false;

        }

    }



    private void MoveToPosition(Vector3 targetPosition)

    {


        Vector3 direction = (targetPosition - transform.position).normalized;




        float step = moveSpeed * Time.deltaTime; 

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);



    }



    private void OnDrawGizmos()

    {


        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }

}