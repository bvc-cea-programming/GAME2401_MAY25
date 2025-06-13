using System;
using TMPro;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    [SerializeField] private TMP_Text hitText;
    [SerializeField] private ParticleSystem hitParticle;

    [SerializeField] private HealthController healthController;

    void OnEnable()
    {
        healthController.OnHealthUpdated += UpdateHealthBar;
    }

    void OnDisable()
    {
        healthController.OnHealthUpdated -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float damage, float fullHealth, float currentHealth)
    {
        hitText.text = "-"+(int)Math.Round(damage);
        hitParticle.Play();
    }
}
