using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    float _currentDistance;


    void Update()
    {
        var distanceToTravel = speed * Time.deltaTime;

        transform.position += transform.forward * distanceToTravel;
        _currentDistance += distanceToTravel;

        if (_currentDistance > maxDistance)
        {
            BulletFactory.Instance.ReturnBullet(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }


    public static void TurnOn(Bullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
    }
}
