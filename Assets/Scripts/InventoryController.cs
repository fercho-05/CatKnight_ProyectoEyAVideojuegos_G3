using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class InventoryController : Monostate<InventoryController>
{
	Dictionary<CollectableTypes, float> _inventory;

	protected override void Awake()
	{
		base.Awake();
		_inventory = new Dictionary<CollectableTypes, float>();
	}

	public void Add(CollectableTypes collectableType, float value2)
	{
		if (_inventory.ContainsKey(collectableType))
		{
			_inventory[collectableType] = value2;
		}
		else
		{
			_inventory.Add(collectableType, value2);
		}
	}

	/*Si recoge la gema, entonces quiere decir que gano el nivel:  */
	public void AddGem(CollectableTypes collectableType, float value2)
	{
		if (_inventory.ContainsKey(collectableType))
		{
			_inventory[collectableType] = value2;
		}
		else
		{
			_inventory.Add(collectableType, value2);
		}
		Win();
	}


	/*Método en el cual se llama la escena: Win.*/
	public void Win()
	{
		SceneManager.LoadScene("Win");
	}
}
