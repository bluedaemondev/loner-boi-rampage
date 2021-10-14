using System;
using System.Collections;

/// <summary>
/// Shooter entity addon
/// </summary>
public interface IGunner
{
    void SubscribeToOnShoot(Action method);
    //void SetGunshotInterval(float time);
    void StartFire();
    void HaltFire();
    IEnumerator FireLoop();

}
