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
    Animator _animator;


    [SerializeField]
    bool _destroy = false;


    private void Awake()
    {
        if (GetComponent<Animator>())
        {
            _animator = this.GetComponent<Animator>();
        }
    }

    public IEnumerator OnExplode()
    {

        for (int i = 0; i < dropCount; i++)
        {
            var lDrop = DropFactory.Instance.pool.GetObject();
            lDrop.SetPickupStrategy(new CashPickup(Constants.CASH_DEFAULT_PICKUP), PickupType.Cash);

            lDrop.transform.position = transform.position - transform.forward * 1.5f + Random.insideUnitSphere * Random.Range(-1.5f, 1.5f);
            lDrop.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            yield return null;

            //Instantiate(piecePrefab, transform.position + Random.insideUnitSphere * Random.Range(-2, 2), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }

        FindObjectOfType<CameraShake>().ShakeCameraNormal(4, 1f);

        _animator?.SetTrigger("fall_down");
        yield return null;
        SoundManager.instance.PlayEffect("fall_down");

        if (_destroy)
            Destroy(this.gameObject);
    }

    public void OnTakeDamage(float ammount)
    {
        if (health <= 0)
        {
            if (explodeCoroutine == null)
                explodeCoroutine = StartCoroutine(OnExplode());
        }
        else
        {
            health -= 1;

            _animator?.Play("damaged");
            Debug.Log("safe " + health);
        }
    }

    void IDamageable.OnExplode()
    {
        throw new System.NotImplementedException();
    }
}
