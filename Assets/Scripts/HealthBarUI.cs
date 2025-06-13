using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    [SerializeField] private Image healthBarImage;

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
        healthBarImage.fillAmount = currentHealth/fullHealth;
    }

    
}
