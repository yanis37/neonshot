using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
  
    private Vector3 offset = new Vector3(0, 0, -10);
    private float smoothSpeed = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;


    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
