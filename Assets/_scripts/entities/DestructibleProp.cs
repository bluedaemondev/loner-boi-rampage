using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleProp : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 5;
    [SerializeField]
    private ParticleSystem particlesDamage;
    [SerializeField]
    private GameObject wallPiecePrefab;

    public void OnExplode()
    {

        for (int i = 0; i < health; i++)
        {
            Instantiate(wallPiecePrefab, transform.position + Random.insideUnitSphere * Random.Range(-2, 2), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }

        FindObjectOfType<CameraShake>().ShakeCameraNormal(4, 1f);
        SoundManager.instance.PlayEffect("fall_down");
        Destroy(this.gameObject);
    }

    public void OnTakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0)
        {
            OnExplode();
        }
    }

}
