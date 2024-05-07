using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera25D : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] float sensitivity = 5f;
    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        float additionalRotationY = mouseX * sensitivity;

        float newYRotation = transform.rotation.eulerAngles.y + additionalRotationY;

        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, newYRotation, transform.rotation.eulerAngles.z);

        transform.rotation = newRotation;

        Vector3 cameraPosition = _mainCamera.transform.position;
        cameraPosition.y = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, -180f, 0f);
    }
}
