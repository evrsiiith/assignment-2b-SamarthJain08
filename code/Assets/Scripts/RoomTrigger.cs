using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Light light1;
    public Light light2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            light1.enabled = true;
            light2.enabled = true;

            GameState.Instance.lightsOn = true;
        }
    }
}