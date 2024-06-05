using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody2D rbPlayer;

    public float dashForce = 10f;
    private Vector2 dashDirection;



    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        float angle = Vector2.Angle(rbPlayer.velocity.normalized, dashDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformDash(angle);
        }
    }

    private void PerformDash(float angle)
    {
        float speedFactor = angle > 150.0f ? 0.3f : rbPlayer.velocity.magnitude;
        speedFactor = angle < 10.0f ? dashForce : rbPlayer.velocity.magnitude;
        speedFactor = Mathf.Max(speedFactor, 0.3f);

        rbPlayer.AddForce(dashDirection * dashForce / speedFactor, ForceMode2D.Impulse);
    }
}
