using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [SerializeField] private Orb _orbPrefab;

    private Orb[] _arrayOfOrbs;
    private int _sizeOfArray = 5;
    private float _fieldSize = 9f;
    private Vector3 _centerOfTheField = new Vector3(-5.0f, 0.0f, -10.0f);
    
    private bool _isActive;
    void Start()
    {
        InitializeArrayOfOrbs();
    }

    // Update is called once per frame
    void Update()
    {
        KeepOneOrbInTheField();
    }

    private void KeepOneOrbInTheField()
    {
        if (!_isActive) return;
        if (NoActiveOrbInTheField())
        {
            SpawnANewOrb();
        }
    }

    private void SpawnANewOrb()
    {
        var orbPosition = GetAvailableOrb();
        if (orbPosition < 0) return;
        float x = Random.Range(-_fieldSize, _fieldSize);
        float y = Random.Range(-_fieldSize, _fieldSize);
        Vector3 newPos = new Vector3(_centerOfTheField.x + x, 0.55f, _centerOfTheField.z + y);
        _arrayOfOrbs[orbPosition].transform.position = newPos;
        _arrayOfOrbs[orbPosition].Summon();
    }

    private int GetAvailableOrb()
    {
        for (int i = 0; i < _sizeOfArray; i++)
        {
            if (!_arrayOfOrbs[i].gameObject.activeInHierarchy)
            {
                return i;
            }
        }

        return -1;
    }

    private bool NoActiveOrbInTheField()
    {
        for (int i = 0; i < _sizeOfArray; i++)
        {
            if (_arrayOfOrbs[i].ParticleActive())
            {
                return false;
            }
        }
        return true;
    }

    public void StartOrbManager()
    {
        _isActive = true;
    }
    private void InitializeArrayOfOrbs()
    {
        _arrayOfOrbs = new Orb[_sizeOfArray];
        for (int i = 0; i < _sizeOfArray; i++)
        {
            var temp = Instantiate(_orbPrefab);
            temp.gameObject.SetActive(false);
            temp.SetOrbManager(this);
            _arrayOfOrbs[i] = temp;
        }
    }
}
