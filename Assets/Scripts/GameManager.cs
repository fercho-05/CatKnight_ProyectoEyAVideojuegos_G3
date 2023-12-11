using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
	/*Instancia para usar GameManager:  */
	public static GameManager Instance { get; private set; }


	/*Variable para poder instanciar el script de HUD: */
	public HUD hud;


	/* Variable entera que contiene las 7 -
	 * im�genes de la barra de mejora:  */
	public int value = -1;


	/*M�todo Awake que contiene una condici�n en el cual nos ayudara -
	 * a evitar excepciones o errores de instancias de objetos.*/
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.Log("Hay de un Gamemanager");
		}
	}


	/*Este m�todo nos permite eliminar una mejora: */
	public void EliminarMejora()
	{
		/* Contador para poder obtener la cantidad
		 * de los enemigos bajados: */
		value -= 1;

		/* Para verificar el contador en la consola-
		 * adem�s de servir como una gu�a para el jugador:  
		
		   Nota:
				value tiene que llegar a -1, esto es para que haga la transici�n de -
				las im�genes en orden, porque si no entonces se salta la imagen: Mejora#1 -
				y coloca la imagen siguiente: Mejora#2.

		 */
		Debug.Log(value);

		hud.DesactivarMejora(value);
	}


	/*Este m�todo nos permite agregar una mejora: */
	public void AgregarMejora()
	{
		/* Contador para poder obtener la cantidad
		 * de los enemigos bajados: */
		value += 1;

		/* Para verificar el contador en la consola-
		 * adem�s de servir como una gu�a para el jugador:  */
		Debug.Log(value);

		hud.ActivarMejora(value);

	}

}


