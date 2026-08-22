using System.Collections;
using UnityEngine;

public class CurveBullet : MonoBehaviour
{
    public float amplitude;
    public float curveFrequency;

    private void Start()
    {
        StartCoroutine(MoveBullet());
    }

    IEnumerator MoveBullet()
    {
        float time = 0f;

        while (true)
        {
            time += Time.deltaTime;

            float x = -10f * Time.deltaTime;
            float y = Mathf.Sin(time * curveFrequency) * amplitude * Time.deltaTime;

            transform.Translate(new Vector3(x, y, 0f));

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("DestroyBullet"))
        {
            Destroy(gameObject);
        }
    }
}