using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
	/*Arreglo que contendr� por posiciones las -
	 7 imagenes colocadas para demostrar la mejora: */
	public GameObject[] Mejoras;


	/*M�todo que sirve para poder desactivar la mejora:  */
	public void DesactivarMejora(int indice)
	{
		Mejoras[indice].SetActive(false);
	}


	/*M�todo que sirve para poder activar la mejora:  */
	public void ActivarMejora(int indice)
	{
		Mejoras[indice].SetActive(true);
	}
}
