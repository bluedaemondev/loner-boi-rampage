using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleProp : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 5;
    [SerializeField]
    private int dropCount = 2;
    [SerializeField]
    private ParticleSystem particlesDamage;
    [SerializeField]
    private GameObject piecePrefab;

    Coroutine explodeCoroutine;

    [SerializeField]
    bool _destroy = false;

    public IEnumerator OnExplode()
    {

        for (int i = 0; i < dropCount; i++)
        {
            var lDrop = DropFactory.Instance.pool.GetObject();
            lDrop.SetPickupStrategy(new CashPickup(Constants.CASH_DEFAULT_PICKUP), PickupType.Cash);

            lDrop.transform.position = transform.position + Random.insideUnitSphere * Random.Range(-2, 2);
            lDrop.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            yield return null;

            //Instantiate(piecePrefab, transform.position + Random.insideUnitSphere * Random.Range(-2, 2), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }

        FindObjectOfType<CameraShake>().ShakeCameraNormal(4, 1f);
        SoundManager.instance.PlayEffect("fall_down");
        yield return null;
        
        if (_destroy)
            Destroy(this.gameObject);
    }

    public void OnTakeDamage(float ammount)
    {
        health -= 1;
        Debug.Log("safe " + health);

        if (health <= 0)
        {
            if (explodeCoroutine == null)
                explodeCoroutine = StartCoroutine(OnExplode());
        }
    }

    void IDamageable.OnExplode()
    {
        throw new System.NotImplementedException();
    }
}
