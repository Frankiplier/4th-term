using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed, minX, maxX;
    private float cameraPosX;
    public bool allowMovement = true;

    void Start()
    {
        cameraPosX = transform.position.x;
    }

    void Update()
    {
        if (allowMovement)
            MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < Screen.width * 0.1f || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            cameraPosX -= moveSpeed * Time.deltaTime;
        }
        else if (mousePos.x > Screen.width * 0.9f || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            cameraPosX += moveSpeed * Time.deltaTime;
        }

        cameraPosX = Mathf.Clamp(cameraPosX, minX, maxX);

        transform.position = new Vector3(cameraPosX, transform.position.y, transform.position.z);
    }

    public void SetCameraX(float x)
    {
        cameraPosX = Mathf.Clamp(x, minX, maxX);
    }
}