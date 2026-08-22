using UnityEngine;
using UnityEngine.InputSystem;

public class GridLogic : MonoBehaviour
{
    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;
    }

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform != null)
                {
                    Debug.Log("Hit: " + raycastHit.transform.name);
                }
                if(raycastHit.transform.CompareTag("GridSlot"))
                {
                    GridSlots gridSlot = raycastHit.transform.GetComponent<GridSlots>();
                    if (gridSlot != null)
                    {
                        if(serviceHub.GameManager.currentTowerTypeIndex != 3)
                        {
                            GameObject towerPrefab = serviceHub.GameManager.towerTypes[0];
                            gridSlot.SetTowerType(serviceHub.GameManager.towerTypes[serviceHub.GameManager.currentTowerTypeIndex]);
                            return;
                        }
                        gridSlot.DeleteTower();
                    }
                }
            }
        }
    }
}