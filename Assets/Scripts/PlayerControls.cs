using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbCross;
    public float speed = 6000.0f; // seems to be a good speed
    public float rotationSpeed = 10.0f; // [5 - 15]

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rbPlayer.AddForce(movement * speed * Time.fixedDeltaTime);

        float mouseX = Input.GetAxis("Mouse X") * 100;

        if (Mathf.Abs(mouseX) > 1f)
        {
            rbPlayer.MoveRotation(rbPlayer.rotation - mouseX * rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rbPlayer.angularVelocity = 0;
        }

    }
}