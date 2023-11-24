using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    //
    void Start()
    {
		/*Llama a este método después de 118 segundos
         * (1:55 minutos)*/
		Invoke("WaitToEnd", 118);
    }


    //
    void Update()
    {
		/*Si le da en la tecla Escape, entonces 
         lo enviara a la escena del menú principal.*/
		if (Input.GetKey(KeyCode.Escape))
        {
			SceneManager.LoadScene("Menu Principal");
		}
        
    }


    /*Espera un cierto tiempo y después lo regresa 
     * al menú principal.*/
    public void WaitToEnd()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
