using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
