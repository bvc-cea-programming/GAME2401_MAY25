using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float fullHealth;

    private float _health;

    // health update event
    public event Action<float, float, float> OnHealthUpdated; // damage taken, full health, current health

    void Start()
    {
        _health = fullHealth;
    }

    public void GetDamage(float damage)
    {
        _health -= damage; // reduce damage from health
        OnHealthUpdated?.Invoke(damage, fullHealth, _health);
    }
}
