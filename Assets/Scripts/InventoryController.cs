using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class InventoryController : Monostate<InventoryController>
{
    Dictionary<CollectableTypes, float> _inventory;
    Dictionary<CollectableTypesLife, float> _inventory2;
    HealthController _healthController;

    protected override void Awake()
    {
        base.Awake();
        _healthController = GetComponent<HealthController>();
        _inventory = new Dictionary<CollectableTypes, float>();
        _inventory2 = new Dictionary<CollectableTypesLife, float>();
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

    public void AddOne(CollectableTypesLife collectableTypes, float value, bool isHealth)
    {
        if (isHealth)
        {
            _healthController.Heal(value);
        }
        else
        {
            if (_inventory2.ContainsKey(collectableTypes))
            {
                _inventory2[collectableTypes] = value;
            }
            else
            {
                _inventory2.Add(collectableTypes, value);
            }
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
		//SE ENVIARÁ AL WIN DESDE OTRA VENTANA, AL DERROTAR AL JEFE
		//Win();
	}


	/*Método en el cual se llama la escena: Win.*/
	//public void Win()
	//{
	//	SceneManager.LoadScene("Win");
	//}
}
