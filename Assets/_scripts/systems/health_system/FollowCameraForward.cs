using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraForward : MonoBehaviour
{
    void Update()
    {
        transform.forward = transform.position - GameManager.Instance.mainCamera.transform.position;
    }
}
