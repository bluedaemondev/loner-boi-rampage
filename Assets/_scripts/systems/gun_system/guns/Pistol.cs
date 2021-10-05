using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    private Bullet currBullet;

    protected override void Fire()
    {
        currBullet = BulletFactory.Instance.pool.GetObject();

        currBullet.transform.position = gunpointPivot.transform.position;
        currBullet.transform.forward = this.transform.forward;
        
        if (shootSound != null)
        {
            SoundManager.instance.PlayEffect(shootSound);
        }
    }
}
