using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float scrollSpeed = 100f;
    private float minY = -6f;
    private float maxY = 6f;

    private void Update()
    {
        float scroll = Mouse.current.scroll.ReadValue().y;

        transform.Translate(0, (scroll * scrollSpeed) * Time.deltaTime, 0);

        if (transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        else if (transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
    }
}