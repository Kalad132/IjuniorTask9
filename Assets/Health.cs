﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health = 50;
    private float _maxHealth = 100;
    private float _heal = 10;
    private float _damage = 10;

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health - _damage, 0, _maxHealth);
    }

    public void Heal()
    {
        _health = Mathf.Clamp(_health + _heal, 0, _maxHealth);
    }
    public float GetCurrentHealth()
    {
        return _health / _maxHealth;
    }
}