using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float turnSpeed = 120f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");

        Vector3 move =
            transform.forward * forward +
            transform.right * side;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}