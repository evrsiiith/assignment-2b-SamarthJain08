using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public bool doorOpen = false;
    public bool lightsOn = false;
    public bool acOn = false;

    public float temperature = 24;

    public const float TEMP_MIN = 16;
    public const float TEMP_MAX = 34;
    public const float TEMP_ALERT = 28;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetColor("TVFrame", Color.black);
        SetColor("AC", new Color(0.75f,0.75f,0.8f));    // light gray
        SetColor("Door", new Color(0.45f,0.28f,0.18f)); // wood
    }

    void SetColor(string objName, Color c)
    {
        GameObject obj = GameObject.Find(objName);
        if(obj == null) return;

        Renderer r = obj.GetComponent<Renderer>();
        if(r != null)
            r.material.color = c;
    }
}