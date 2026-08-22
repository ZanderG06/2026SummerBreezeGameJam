using UnityEngine;

public class GridSlots : MonoBehaviour
{
    public GameObject currentTower;

    public void SetTowerType(GameObject towerType)
    {
        if (currentTower != null)
        {
            Debug.Log("A tower is already placed. Remove it before placing a new one.");
            return;
        }

        currentTower = Instantiate(towerType, transform.position, Quaternion.identity);
    }
}