using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    float shakeTimer;
    float shakeTimerTotal;
    float startinIntensity;

    private CinemachineVirtualCamera cinemachineCam;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCam(float intensity, float timer) 
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startinIntensity = intensity;
        shakeTimer = timer;
        shakeTimerTotal = timer;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;


            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();


            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
            Mathf.Lerp(startinIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));

        }
    }
}
