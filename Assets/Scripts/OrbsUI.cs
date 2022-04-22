using System;
using TMPro;
using UnityEngine;

public class OrbsUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = GameStats.OrbsCollected.ToString();
    }
}
