using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFlyweight 
{
    public float speed;
}
public class IAEntityFlyweight : EntityFlyweight
{
    public float viewDistance;
    public float timeAim;

}
