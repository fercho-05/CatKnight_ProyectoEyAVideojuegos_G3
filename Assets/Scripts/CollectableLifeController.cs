using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLifeController : MonoBehaviour
{
    [SerializeField]
    public CollectableTypesLife CollectableTypesLife;

    [SerializeField]
    public bool isHealhtt;

    [SerializeField]
    public float value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryController.Instance.AddOne(CollectableTypesLife, value, isHealhtt);
            Destroy(gameObject);
        }
    }

}