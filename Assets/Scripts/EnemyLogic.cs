using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public List<Transform> startPoint;
    public float moveSpeed;
    public int health;

    private Rigidbody rb;
    private List<Vector3> waypoints = new List<Vector3>();
    private string currentRow = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        int startingLocation = Random.Range(0, startPoint.Count);

        transform.position = startPoint[startingLocation].position;
        currentRow = startPoint[startingLocation].name;

        foreach (Transform childTransform in startPoint[startingLocation].transform) waypoints.Add(childTransform.position);

        StartCoroutine(MoveBetweenWaypoints());
    }

    IEnumerator MoveBetweenWaypoints()
    {
        while (true)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                while (Vector3.Distance(rb.position, waypoints[i]) > .001f)
                {
                    rb.MovePosition(Vector3.MoveTowards(rb.position, waypoints[i], moveSpeed * Time.deltaTime));

                    yield return null;
                }
                yield return new WaitForSecondsRealtime(.1f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            health--;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if(other.CompareTag("EndPoint"))
        {
            Destroy(gameObject);
            //PUT CODE HERE TO END GAME OR TAKE AWAY PLAYER HEALTH
        }
        if(other.CompareTag("StateChange"))
        {
            
        }
    }
}