﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    private List<Transform> aditionalGunpoints;
    private List<Bullet> currentBullets;

    public override void Fire()
    {
        currentBullets = BulletFactory.Instance.pool.GetObject(aditionalGunpoints.Count);
        int selectedGP = 0;

        foreach (var currBullet in currentBullets)
        {
            selectedGP = Random.Range(0, aditionalGunpoints.Count);

            if (selectedGP == 0)
            {
                currBullet.transform.position = gunpointPivot.transform.position;
                currBullet.transform.forward = gunpointPivot.forward;

            }
            else
            {
                currBullet.transform.position = aditionalGunpoints[selectedGP].transform.position;
                currBullet.transform.forward = aditionalGunpoints[selectedGP].forward;
            }
        }

        if (shootSound != null)
        {
            SoundManager.instance.PlayEffect(shootSound);
        }
    }
}
