﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float damage;

    [SerializeField] protected float speed;
    [SerializeField] protected float maxDistance;

    protected float _currentDistance;

    [SerializeField] protected TrailRenderer trail;

    protected virtual void Update()
    {
        var distanceToTravel = speed * Time.deltaTime;

        transform.position += transform.forward * distanceToTravel;
        _currentDistance += distanceToTravel;

        if (_currentDistance > maxDistance)
        {
            BulletFactory.Instance.ReturnBullet(this);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        var entity = other.GetComponent<Entity>();
        Blood blood;
        if (entity != null)
        {
            entity.TakeDamage(damage);
            blood = BloodFactory.Instance.pool.GetObject();
            blood.transform.position = entity.transform.position;

            FindObjectOfType<CameraShake>().ShakeCameraNormal(Random.Range(5,9), 0.22f);
            SoundManager.instance.PlayEffect("damaged_entity");
        }
        else
        {
            var closestPoint = other.ClosestPoint(this.transform.position);

            blood = BloodFactory.Instance.pool.GetObject();
            blood.transform.position = closestPoint;
            blood.transform.forward = (transform.position - closestPoint).normalized;

            blood.GetComponent<ParticleSystem>().startColor = Color.yellow;
        }

        BulletFactory.Instance.ReturnBullet(this);
    }
    //protected virtual void OnCollisionEnter(Collision collision)
    //{
    //    BulletFactory.Instance.ReturnBullet(this);

    //}

    private void Reset()
    {
        _currentDistance = 0;
        trail.Clear();
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
