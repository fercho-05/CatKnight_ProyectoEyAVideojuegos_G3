using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGemController : MonoBehaviour
{
	[SerializeField]
    public CollectableTypes collectableType;

	[SerializeField]
	public float value2;

	/*Si choca con la gema y tiene el tag de Player, entonces -
	 * procederá a llamar el método: AddGem.*/
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			InventoryController.Instance.AddGem(collectableType, value2);
			Destroy(gameObject);
		}
    }

}
