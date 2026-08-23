using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TowerLogic : MonoBehaviour
{
    public GameObject projectile;
    private GameObject layer;
    private List<Transform> bulletSpawners = new List<Transform>();

    private void Start()
    {
        foreach (Transform child in transform) bulletSpawners.Add(child);

        StartCoroutine(LaunchProjectile());
    }

    public void Initialize(GameObject layerObject)
    {
        layer = layerObject;
    }

    IEnumerator LaunchProjectile()
    {
        while (true)
        {
            foreach (Transform spawner in bulletSpawners)
            {
                GameObject bulletObject = Instantiate(projectile, spawner.position, Quaternion.identity);

                StandardBullet bullet = bulletObject.GetComponent<StandardBullet>();
                bullet.StartBulletCoroutine(layer);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}