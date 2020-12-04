using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private int _health = 50;
    private int _maxHealth = 100;
    private int _heal = 10;
    private int _damage = 10;
    private float _currentBarPosition;
    private float _barChangeStartingSpeed = 1f;

    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
        _currentBarPosition = GetCurrentHealth();
        _slider.value = _currentBarPosition;
    }

    private void Update()
    {
        if (_currentBarPosition != GetCurrentHealth())
            ChangeHandlePosition();
    }

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health - _damage, 0 , _maxHealth);
    }

    public void Heal()
    {
        _health = Mathf.Clamp(_health + _heal, 0, _maxHealth);
    }

    private void ChangeHandlePosition()
    {
        float barChange = _barChangeStartingSpeed * (GetCurrentHealth() - _currentBarPosition) * Time.deltaTime;
        _currentBarPosition = Mathf.Clamp(_currentBarPosition + barChange, 0f, 1f);
        _slider.value = _currentBarPosition;
    }

    private float GetCurrentHealth()
    {
        return 1f * _health / _maxHealth;
    }
}
