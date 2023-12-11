using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
	/*El m�todo consiste en que si le da en 
	 * el bot�n de: Creditos, entonces 
     * lo enviara a la escena de Creditos.*/
	public void Creditos()
    {
        LevelManager.Instance.LastScene();
    }


    public void IniciarJuego()
    {
        LevelManager.Instance.NextScene();
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Ambiente");
    }
}
