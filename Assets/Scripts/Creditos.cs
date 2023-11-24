using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    //
    void Start()
    {
		/*Llama a este m�todo despu�s de 118 segundos
         * (1:55 minutos)*/
		Invoke("WaitToEnd", 118);
    }


    //
    void Update()
    {
		/*Si le da en la tecla Escape, entonces 
         lo enviara a la escena del men� principal.*/
		if (Input.GetKey(KeyCode.Escape))
        {
			SceneManager.LoadScene("Menu Principal");
		}
        
    }


    /*Espera un cierto tiempo y despu�s lo regresa 
     * al men� principal.*/
    public void WaitToEnd()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
