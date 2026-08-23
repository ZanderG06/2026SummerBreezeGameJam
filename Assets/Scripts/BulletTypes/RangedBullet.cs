using System.Collections;
using UnityEngine;

public class RangedBullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveBullet());
    }

    IEnumerator MoveBullet()
    {
        while (true)
        {
            transform.Translate(10f * Time.deltaTime * Vector3.left);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyBullet"))
        {
            Destroy(gameObject);
        }
    }
}