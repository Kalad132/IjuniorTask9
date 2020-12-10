using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health _health;
    private Slider _slider;
    private float _currentBarPosition;
    private float _barChangeStartingSpeed = 2f;
    private Coroutine _barChanging;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health = GetComponent<Health>();
        _currentBarPosition = _health.GetCurrentHealth();
        _slider.value = _currentBarPosition;
    }

    public void OnHealthChanged()
    {
        if (_barChanging !=null)
            StopCoroutine(_barChanging);
        _barChanging = StartCoroutine(StartChangingHandlePosition(_health.GetCurrentHealth()));
    }

    private void ChangeHandlePosition(float position)
    {
        float barChange = _barChangeStartingSpeed * (position - _currentBarPosition) * Time.deltaTime;
        _currentBarPosition = Mathf.Clamp(_currentBarPosition + barChange, 0f, 1f);
        _slider.value = _currentBarPosition;
    }

    private IEnumerator StartChangingHandlePosition(float position)
    {
       while (position != _currentBarPosition)
        {
            ChangeHandlePosition(position);
            yield return null;
        }
    }
}
