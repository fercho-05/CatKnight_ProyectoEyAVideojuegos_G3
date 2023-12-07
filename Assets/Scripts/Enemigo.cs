using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Rendering.DebugUI;

public class Enemigo : MonoBehaviour
{
	/*Esto es para poder hacer un reseteo inicial en -
	 la barra de mejora con ayuda del cubo de color rojo (nivel #1) -
	 y azul (nivel #2). */
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.Instance.EliminarMejora();
		}
	}
}


