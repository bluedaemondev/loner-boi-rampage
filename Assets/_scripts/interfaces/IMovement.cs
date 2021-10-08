using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move();
    void SubscribeToEndCoroutine(System.Action handler);
}
