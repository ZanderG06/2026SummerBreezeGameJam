using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public List<Transform> startPoint;
    public float moveSpeed;

    private Rigidbody rb;
    private List<Vector3> waypoints = new List<Vector3>();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        int startingLocation = Random.Range(0, startPoint.Count);

        transform.position = startPoint[startingLocation].position;

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
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }
}