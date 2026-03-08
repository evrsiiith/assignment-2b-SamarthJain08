using UnityEngine;

public class TVController : MonoBehaviour
{
    Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    void Update()
    {
        bool tempHigh =
            GameState.Instance.temperature > GameState.TEMP_ALERT;

        bool doorOpen =
            GameState.Instance.doorOpen;

        if (tempHigh && doorOpen && GameState.Instance.acOn)
            r.material.color = new Color(1f,0.5f,0f); // orange
        else if (tempHigh && GameState.Instance.acOn)
            r.material.color = Color.red;
        else if (doorOpen && GameState.Instance.acOn)
            r.material.color = Color.yellow;
        else
            r.material.color = new Color(0.75f,0.75f,0.8f);
    }
}