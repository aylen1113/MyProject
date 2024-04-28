using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera25D : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private void LateUpdate()
    {
        Vector3 cameraPosition = _mainCamera.transform.position;
        cameraPosition.y = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, 90f, 0f);
    }
}
