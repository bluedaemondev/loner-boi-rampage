using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private CinemachineVirtualCamera vCam;

    private float shakeTimerTotal;
    private float shakeTimer;
    private float startingIntensity;

    CinemachineBasicMultiChannelPerlin cmPerlin;

    // Start is called before the first frame update
    void Awake()
    {
        this.vCam = this.GetComponent<CinemachineVirtualCamera>();
        cmPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCameraNormal(float intensity, float time)
    {
        cmPerlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;

    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.unscaledDeltaTime;
            cmPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, shakeTimer / shakeTimerTotal);
        }
        else if (cmPerlin.m_AmplitudeGain != 0)
        {
            CinemachineBasicMultiChannelPerlin cmPerlin =
                    vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cmPerlin.m_AmplitudeGain = 0;
        }

    }

}
