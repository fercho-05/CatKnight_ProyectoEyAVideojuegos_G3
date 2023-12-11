using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float damage = 10.0F;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))//si el colisionador con el que choque es igual a "player", significa que choco con el player
        {
            Vector2 contactPoint = collision.GetContact(0).normal;

            if (contactPoint.y < -0.9F)
            {
                Character2DController.Instance.Rebound(); //rebote 
                Destroy(gameObject); //mata al enemigo
            }
            else
            {
                HealthController controller = collision.collider.GetComponent<HealthController>(); //entonces busque el health bar
                controller.TakeDamage(damage, contactPoint);
            }

        }
    }


}
