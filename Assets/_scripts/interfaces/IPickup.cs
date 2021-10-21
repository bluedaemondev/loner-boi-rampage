using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup 
{
    void OnGrabPickup();
    void SetGrabber(GameObject other = null);
}
