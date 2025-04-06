using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed, minX, maxX;
    private float cameraPosX;

    void Start()
    {
        cameraPosX = transform.position.x;
    }

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < Screen.width * 0.1f)
        {
            cameraPosX -= moveSpeed * Time.deltaTime;
        }
        
        else if (mousePos.x > Screen.width * 0.9f)
        {
            cameraPosX += moveSpeed * Time.deltaTime;
        }

        cameraPosX = Mathf.Clamp(cameraPosX, minX, maxX);

        transform.position = new Vector3(cameraPosX, transform.position.y, transform.position.z);
    }
}