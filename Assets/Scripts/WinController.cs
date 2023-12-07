using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{

	void Start()
	{
		/*Llama a este m�todo despu�s de 15 segundos de espera: */
		Invoke("WaitToMap", 15);
	}

	/*Espera un cierto tiempo y despu�s lo regresa 
	* al mapa inicial.*/
	public void WaitToMap()
	{
		SceneManager.LoadScene("Mapa inicial");
	}
	
	/*M�todo que lleva al mapa inicial: */
	public void Menu()
	{
		SceneManager.LoadScene("Mapa inicial");
	}
}
