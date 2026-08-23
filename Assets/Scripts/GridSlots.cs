using UnityEngine;

public class GridSlots : MonoBehaviour
{
    public GameObject currentTower;
    public GameObject layer;

    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;
    }

    public void SetTowerType(GameObject towerType)
    {
        if (currentTower != null && serviceHub.GameManager.currentTowerTypeIndex != 3)
        {
            Debug.Log("A tower is already placed. Remove it before placing a new one.");
            return;
        }

        currentTower = Instantiate(towerType, transform.position, Quaternion.identity);

        TowerLogic towerLogic = currentTower.GetComponent<TowerLogic>();

        if (towerLogic != null)
        {
            towerLogic.Initialize(layer);
        }
    }

    public void DeleteTower()
    {
        if (currentTower != null)
        {
            Destroy(currentTower);
            currentTower = null;
        }
        else
        {
            Debug.Log("No tower to delete.");
        }
    }
}