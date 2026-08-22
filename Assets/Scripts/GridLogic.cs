using UnityEngine;
using UnityEngine.InputSystem;

public class GridLogic : MonoBehaviour
{
    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform != null)
                {
                    Debug.Log("YO this is working!");
                }
            }
        }
    }
}