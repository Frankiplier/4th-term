using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float followSpeed;
    private Vector3 targetPosition;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        
        targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}