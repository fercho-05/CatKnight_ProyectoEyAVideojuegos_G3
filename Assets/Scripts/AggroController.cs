using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroController : Monostate<AggroController>
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float speed;

    [SerializeField]
    float awakeDistance;

    [SerializeField]
    float stopDistance;

    [SerializeField]
    float shootDistance;

    [SerializeField]
    bool isFacingRigth;

    float _distance;

    bool _isChasing;

    Vector2 _position;

    Animator _animator;

    [Header("Combat")]
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform[] shootPoints;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        _position = transform.position;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _distance = Vector2.Distance(transform.position, player.position);

        if (_distance <= awakeDistance && !_isChasing)
        {
            _isChasing = true;
            _animator.SetFloat("speed", 1.0F);
        }
        else if (_distance <= stopDistance && _isChasing && _distance >= shootDistance)
        {
            //Me detengo y disparo
            _isChasing = false;
            _animator.SetFloat("speed", 0.0F);
            //Llamar a disparo
            _animator.SetTrigger("shoot");
            Disparar();
        }
        else if (_distance >= stopDistance && _isChasing)
        {
            //Me detengo
            _isChasing = false;
            _animator.SetFloat("speed", 0.0F);
        }

        Vector2 lookAt = Vector2.zero;

        if (_isChasing)
        {
            Vector2 position = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
            lookAt = position;
        }

        if (lookAt.x > transform.position.x)
        {
            if (!isFacingRigth)
            {
                isFacingRigth = true;
                transform.Rotate(0.0F, 180.0F, 0.0F);
            }
        }
        else
        {
            if (isFacingRigth)
            {
                isFacingRigth = false;
                transform.Rotate(0.0F, 180.0F, 0.0F);
            }
        }
    }

    void Disparar()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            if (isFacingRigth)
            {
                shootPoint.rotation = Quaternion.Euler(new Vector3(0.0F, 0.0F, -90.0F));
            }
            else
            {
                shootPoint.rotation = Quaternion.Euler(new Vector3(0.0F, 0.0F, 90.0F));
            }
            
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
