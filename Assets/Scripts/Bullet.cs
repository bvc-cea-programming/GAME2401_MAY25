
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Vector2 bulletDamage;

    void OnCollisionEnter(Collision col)
    {
        var healthController = col.gameObject.GetComponent<HealthController>();
        if(healthController != null)
        {
            healthController.GetDamage(UnityEngine.Random.Range(bulletDamage.x, bulletDamage.y));
        }
    }
}
