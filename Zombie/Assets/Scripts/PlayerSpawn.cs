using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("targetDoorID: " + DoorTransitionData.targetDoorID);

        string targetID = DoorTransitionData.targetDoorID;

        if (!string.IsNullOrEmpty(targetID))
        {
            Door[] doors = FindObjectsOfType<Door>();

            foreach (Door door in doors)
            {
                if (door.doorID == targetID)
                {
                    Vector3 newCamPosition = (Vector2)door.transform.position + door.spawnOffset;
                    newCamPosition.z = Camera.main.transform.position.z;
                    Camera.main.transform.position = newCamPosition;

                    CameraController controller = Camera.main.GetComponent<CameraController>();
                    
                    if (controller != null)
                    {
                        controller.SetCameraX(newCamPosition.x);
                    }

                    Debug.Log("New camera position: " + Camera.main.transform.position);
                    Debug.Log("Door position: " + door.transform.position);
                    Debug.Log("Spawn offset: " + door.spawnOffset);
                    Debug.Log("Camera moved to door with ID: " + door.doorID);

                    break;
                }
            }

            DoorTransitionData.targetDoorID = null;
        }
    }
}