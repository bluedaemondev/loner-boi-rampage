using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public GameObject followCursor;

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            followCursor.transform.position = Camera.main.cameraToWorldMatrix * (Input.mousePosition - Vector3.back*5);
        }
    }
}
