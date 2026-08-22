using System.Collections;
using UnityEngine;

public class StandardBullet : MonoBehaviour
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
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if(other.CompareTag("DestroyBullet"))
        {
            Destroy(gameObject);
        }
    }
}