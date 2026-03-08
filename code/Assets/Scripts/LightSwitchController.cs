using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public Light light1;
    public Light light2;

    Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    public void Interact()
    {
        bool newState = !GameState.Instance.lightsOn;

        light1.enabled = newState;
        light2.enabled = newState;

        GameState.Instance.lightsOn = newState;

        r.material.color = newState ? Color.yellow : Color.gray;
    }
}