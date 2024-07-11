using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrake : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public float brakeForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rbPlayer.AddForce(-rbPlayer.velocity * brakeForce, ForceMode2D.Force);
        }
    }
}
