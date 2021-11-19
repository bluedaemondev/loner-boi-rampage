using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    private Bullet currBullet;
    public bool firstShot = true;

    public override void Fire()
    {

        currBullet = BulletFactory.Instance.pool.GetObject();

        currBullet.transform.position = gunpointPivot.transform.position;
        currBullet.transform.forward = this.transform.forward;

        if (firstShot)
        {
            firstShot = false;
            Debug.Log(currBullet.transform.localScale);
            currBullet.transform.localScale = Vector3.one * 0.4f * 2;
        }

        if (shootSound != null)
        {
            SoundManager.instance.PlayEffect(shootSound);
        }
    }
}
