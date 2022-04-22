using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private ParticleSystem _beamPS;
    [SerializeField] private ParticleSystem _particlesPS;
    [SerializeField] private ParticleSystem _smokePS;
    [SerializeField] private float _secondsToVanish = 3f;
    private OrbManager _orbManagerRef;

private bool _isVanishing = false;
    private void Vanish()
    {
        if (_isVanishing) return;
        _isVanishing = true;
        _beamPS.Stop();
        _particlesPS.Stop();
        _smokePS.Stop();
        StartCoroutine(WaitForVanishAndDisableAfterSeconds(_secondsToVanish));
    }

    IEnumerator WaitForVanishAndDisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
    public void Summon()
    {
        _isVanishing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vanish();
        }
    }

    public void SetOrbManager(OrbManager orbManager)
    {
        _orbManagerRef = orbManager;
    }
}
