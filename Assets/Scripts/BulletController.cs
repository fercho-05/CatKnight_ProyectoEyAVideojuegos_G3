using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0F;

    [SerializeField]
    float lifeTime = 3.0F;

    Rigidbody2D rb;

    [SerializeField]
    float damageJefe = 20.0F;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);


            Vector2 contactPoint = other.GetContact(0).normal;


            //Recibir DAÑO actualizar barra de vida
            HealthController controller = other.collider.GetComponent<HealthController>(); //entonces busque el health bar
            if (controller != null)
            {
                controller.TakeDamage(damageJefe, contactPoint);
            }

        }
    }


}
