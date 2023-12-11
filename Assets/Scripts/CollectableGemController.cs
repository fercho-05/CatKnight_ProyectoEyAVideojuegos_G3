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

			//Control de niveles
            if (StateManager.Instance.getLevel1() == false)
            {
				StateManager.Instance.setLevel1(true);
                LevelManager.Instance.SceneName("Mapa Inicial");
                //Se podria agregar un mensaje que indique que el nivel ha sido completado y que ha desbloqueado el 2
            }
            else if(StateManager.Instance.getLevel1() == true && StateManager.Instance.getLevel2() == false)
            {
                StateManager.Instance.setLevel2(true);
                LevelManager.Instance.SceneName("Mapa Inicial");
                //Se podria agregar un mensaje que indique que el nivel ha sido completado y que ha desbloqueado el FinalBoss
            }
            else
            {
                StateManager.Instance.setFinalBoss(true);
                //Se envia a la pantalla de WIN
                //Se puede hacer que el jefe suele una ultima gema y con esta se gane el juego
                LevelManager.Instance.SceneName("Win");
            }
        }
    }

}
