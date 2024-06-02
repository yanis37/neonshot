using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 6000.0f; // seems to be a good speed
    public float rotationSpeed = 10.0f; // [5 - 15]

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.AddForce(movement * speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * 100;

        if (Mathf.Abs(mouseX) > 1f)
        {
            rb.MoveRotation(rb.rotation - mouseX * rotationSpeed * Time.deltaTime);
        } else
        {
            rb.angularVelocity = 0;
        }

    }
}
