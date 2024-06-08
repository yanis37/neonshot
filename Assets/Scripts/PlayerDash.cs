using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody2D rbPlayer;

    public float dashForce = 0.05f;
    private Vector2 dashDirection;

    private bool _isDashing = false;
    public bool IsDashing { get { return _isDashing; } }
    public float dashCooldown = 0.1f;

    private float speed;

    PlayerStamina playerStamina;

    
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerStamina = GetComponent<PlayerStamina>();
    }

    void FixedUpdate()
    {
        speed = rbPlayer.velocity.magnitude;

        dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        float angle = Vector2.Angle(rbPlayer.velocity.normalized, dashDirection);

        if (Input.GetKeyDown(KeyCode.Space) && !_isDashing && playerStamina.CurrentStamina > 3.0f)
        {
            PerformDash(angle);
            _isDashing = true;
            Invoke("ResetDash", dashCooldown);
        } 
    }

    private void PerformDash(float angle)
    {
        if (angle < 0.5f)
        {
            angle = (1 / speed) * 50;
            print("angle: " + angle);
        }
        rbPlayer.AddForce(dashDirection * dashForce * angle, ForceMode2D.Impulse);
    }

    private void ResetDash()
    {
        _isDashing = false;
    }
}
