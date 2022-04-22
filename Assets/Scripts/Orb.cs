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
    private bool _isActive = false;
    private void Vanish()
    {
        if (_isVanishing) return;
        _isActive = false;
        _isVanishing = true;
        StopParticles();
        StartCoroutine(WaitForVanishAndDisableAfterSeconds(_secondsToVanish));
    }

    IEnumerator WaitForVanishAndDisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
    public void Summon()
    {
        _isActive = true;
        _isVanishing = false;
        gameObject.SetActive(true);
        PlayParticles();
    }

    private void PlayParticles()
    {
        _beamPS.Play();
        _particlesPS.Play();
        _smokePS.Play();
    }

    public bool ParticleActive()
    {
        return _isActive;
    }
    private void StopParticles()
    {
        _beamPS.Stop();
        _particlesPS.Stop();
        _smokePS.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vanish();
            GameStats.OrbsCollected += 1;
        }
    }

    public void SetOrbManager(OrbManager orbManager)
    {
        _orbManagerRef = orbManager;
    }
}
