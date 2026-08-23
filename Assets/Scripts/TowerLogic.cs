using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLogic : MonoBehaviour
{
    public GameObject projectile;
    private GameObject layer;
    private List<Transform> bulletSpawners = new List<Transform>();

    private void Start()
    {
        foreach (Transform child in transform) bulletSpawners.Add(child);

        if(layer.name == "Layer2")
        {
            if (name == "tow3_fih(Clone)") transform.rotation = Quaternion.Euler(-90, 0, 180);
            else transform.rotation = Quaternion.Euler(-90, 0, 270);
        }
        else
        {
            if (name == "tow3_fih(Clone)") transform.rotation = Quaternion.Euler(-90, 0, 0);
            else transform.rotation = Quaternion.Euler(-90, 0, 90);
        }

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