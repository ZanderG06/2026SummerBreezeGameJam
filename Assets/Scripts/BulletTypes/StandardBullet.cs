using System.Collections;
using UnityEngine;

public class StandardBullet : MonoBehaviour
{
    public void StartBulletCoroutine(GameObject layer)
    {
        if(layer.name != "Layer2") StartCoroutine(MoveBullet(10f));
        else StartCoroutine(MoveBullet(-10f));
    }

    IEnumerator MoveBullet(float direction)
    {
        while (true)
        {
            transform.Translate(direction * Time.deltaTime * Vector3.left);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(name == "Bullet") Destroy(gameObject);
        }
        if(other.CompareTag("DestroyBullet"))
        {
            Destroy(gameObject);
        }
    }
}