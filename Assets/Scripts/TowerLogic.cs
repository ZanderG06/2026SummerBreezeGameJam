using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLogic : MonoBehaviour
{
    public GameObject projectile;
    private List<Transform> bulletSpawners = new List<Transform>();

    private void Start()
    {
        foreach (Transform child in transform) bulletSpawners.Add(child);

        StartCoroutine(LaunchProjectile());
    }

    IEnumerator LaunchProjectile()
    {
        while (true)
        {
            foreach (Transform spawner in bulletSpawners)
            {
                Instantiate(projectile, spawner.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}