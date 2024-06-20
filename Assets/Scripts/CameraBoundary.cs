using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Transform boundaryTop;
    public Transform boundaryBottom;
    public Transform boundaryLeft;
    public Transform boundaryRight;

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;

        // Batasi posisi kamera agar tidak melewati batas atas dan bawah
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, boundaryBottom.position.y, boundaryTop.position.y);

        // Batasi posisi kamera agar tidak melewati batas kiri dan kanan
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, boundaryLeft.position.x, boundaryRight.position.x);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}