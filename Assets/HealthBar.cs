using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health _health;
    private Slider _slider;
    private float _currentBarPosition;
    private float _barChangeStartingSpeed = 1f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health = GetComponent<Health>();
        _currentBarPosition = _health.GetCurrentHealth();
        _slider.value = _currentBarPosition;
    }

    private void Update()
    {
        if (_currentBarPosition != _health.GetCurrentHealth())
            ChangeHandlePosition();
    }

    private void ChangeHandlePosition()
    {
        float barChange = _barChangeStartingSpeed * (_health.GetCurrentHealth() - _currentBarPosition) * Time.deltaTime;
        _currentBarPosition = Mathf.Clamp(_currentBarPosition + barChange, 0f, 1f);
        _slider.value = _currentBarPosition;
    }
}
