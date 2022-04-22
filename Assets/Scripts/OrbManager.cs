using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [SerializeField] private Orb _orbPrefab;

    private Orb[] _arrayOfOrbs;
    private int _sizeOfArray = 5;
    void Start()
    {
        InitializeArrayOfOrbs();
    }

    // Update is called once per frame
    void Update()
    {
        
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
