using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool open = false;

    public BoxCollider doorCollider;

    public void Interact()
    {
        open = !open;

        if (open)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            doorCollider.enabled = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            doorCollider.enabled = true;
        }

        GameState.Instance.doorOpen = open;
    }
}