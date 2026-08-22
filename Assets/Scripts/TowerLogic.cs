using System.Collections;
using UnityEngine;

public class TowerLogic : MonoBehaviour
{
    public GameObject projectile;

    private void Start()
    {
        StartCoroutine(LaunchProjectile());
    }

    IEnumerator LaunchProjectile()
    {
        while (true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}