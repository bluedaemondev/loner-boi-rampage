using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    private List<Transform> aditionalGunpoints;
    private List<Bullet> currentBullets = new List<Bullet>();

    public override void Fire()
    {
        int selectedGP = 0;

        for (int i = 0; i < aditionalGunpoints.Count; i++)
            currentBullets.Add(BulletFactory.Instance.pool.GetObject());

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

        currentBullets.Clear();

        if (shootSound != null)
        {
            SoundManager.instance.PlayEffect(shootSound);
        }
    }
}
