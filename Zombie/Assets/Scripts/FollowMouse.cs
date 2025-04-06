using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = transform.position.z;
        transform.position = worldMousePos;
    }
}