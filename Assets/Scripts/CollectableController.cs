using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
	[SerializeField]
    public CollectableTypes collectableType;

	[SerializeField]
	public float value2;


	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
		{ 
			InventoryController.Instance.Add(collectableType, value2);

			/*Agrega un punto de pila de mejora en la barra de mejora:  */
			GameManager.Instance.AgregarMejora();
			Destroy(gameObject);
        }
    }

}
