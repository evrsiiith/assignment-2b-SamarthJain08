using UnityEngine;

public class ACSwitchController : MonoBehaviour
{
    Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    public void Interact()
    {
        GameState.Instance.acOn = !GameState.Instance.acOn;

        r.material.color =
            GameState.Instance.acOn ? Color.cyan : Color.gray;
    }
}