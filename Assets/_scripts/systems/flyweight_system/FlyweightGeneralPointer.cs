using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightGeneralPointer 
{
    #region ENTITIES

    public static readonly IAEntityFlyweight Cop = new IAEntityFlyweight
    {
        speed = 4.20f,
        timeAim = 1f,
        viewDistance = 6f
    };
    
    public static readonly IAEntityFlyweight ShotgunCop = new IAEntityFlyweight
    {
        speed = 4.20f,
        timeAim = 2f,
        viewDistance = 7f
    };


    #endregion


    #region GUN_SYSTEM
    public static readonly GunFlyweight Pistol = new GunFlyweight
    {
        timeBetweenShots = 0.22f,
        shootSound = SoundLibrary.GetByName("pistol_shoot", GameManager.Instance.GameSounds)
    };

    public static readonly GunFlyweight Shotgun = new GunFlyweight
    {
        timeBetweenShots = 0.47f,
        shootSound = SoundLibrary.GetByName("shotgun_shoot", GameManager.Instance.GameSounds)
    };
    #endregion


}
