using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{

	void Start()
	{
		/*Llama a este método después de 15 segundos de espera: */
		Invoke("WaitToMap", 15);
	}

	/*Espera un cierto tiempo y después lo regresa 
	* al mapa inicial.*/
	public void WaitToMap()
	{
		SceneManager.LoadScene("Mapa inicial");
	}
	
	/*Método que lleva al mapa inicial: */
	public void Menu()
	{
		SceneManager.LoadScene("Mapa inicial");
	}
}
