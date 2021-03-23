using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform oyuncu;
    private Vector3 offset;
    public float smootSpeed = 0;
    void Start()
    {
        offset = transform.position - oyuncu.transform.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = oyuncu.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smootSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
