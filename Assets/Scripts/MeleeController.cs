using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    float damage = 1000.0F;

    [SerializeField]
    int attackRate = 1;

    float _attackTime;

    void Update()
    {
        _attackTime -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (_attackTime <= 0.0F)
            {
                CharacterPlataformerController.Instance.Attack(damage);
                _attackTime = 1.0F / attackRate;
            }
        }
    }
}