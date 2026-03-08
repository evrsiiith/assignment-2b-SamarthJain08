using UnityEngine;

public class TempSliderController : MonoBehaviour
{
    Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        if (!GameState.Instance.acOn) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                float scroll = Input.mouseScrollDelta.y;

                if (scroll > 0)
                    GameState.Instance.temperature++;

                if (scroll < 0)
                    GameState.Instance.temperature--;

                GameState.Instance.temperature =
                    Mathf.Clamp(
                        GameState.Instance.temperature,
                        GameState.TEMP_MIN,
                        GameState.TEMP_MAX
                    );

                UpdateColor();
            }
        }
    }

    void UpdateColor()
    {
        float t = Mathf.InverseLerp(
            GameState.TEMP_MIN,
            GameState.TEMP_MAX,
            GameState.Instance.temperature);

        Color c = Color.Lerp(
            new Color(0.2f, 0.6f, 1f),
            new Color(1f, 0.2f, 0.2f),
            t);

        r.material.color = c;
    }
}