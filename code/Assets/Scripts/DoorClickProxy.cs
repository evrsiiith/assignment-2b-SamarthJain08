using UnityEngine;

public class DoorClickProxy : MonoBehaviour
{
    public DoorController hinge;

    public void Interact()
    {
        hinge.Interact();
    }
}