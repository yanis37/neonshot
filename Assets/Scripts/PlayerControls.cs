using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbCross;
    public float speed = 6000.0f; // seems to be a good speed
    public float rotationSpeed = 10.0f; // [5 - 15]

    // private Vector2 initialOffset;

    void Start()
    {
        // rbPlayer and rbCross should be assigned via the Inspector or by finding the specific child components
        rbPlayer = GetComponent<Rigidbody2D>();

        // // Assuming rbCross is a child of the player, you should assign it correctly
        // rbCross = transform.Find("Cross").GetComponent<Rigidbody2D>();

        // initialOffset = rbCross.position - rbPlayer.position;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rbPlayer.AddForce(movement * speed * Time.fixedDeltaTime); // Use Time.fixedDeltaTime for FixedUpdate

        float mouseX = Input.GetAxis("Mouse X") * 100;

        if (Mathf.Abs(mouseX) > 1f)
        {
            rbPlayer.MoveRotation(rbPlayer.rotation - mouseX * rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rbPlayer.angularVelocity = 0;
        }

        // Vector2 newCrossPosition = rbPlayer.position + (Vector2)(Quaternion.Euler(0, 0, rbPlayer.rotation) * initialOffset);

        // // Ensure the cross follows the player (parent) like in kinematic mode
        // rbCross.MovePosition(newCrossPosition);
        // rbCross.MoveRotation(rbPlayer.rotation);
    }
}