using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    //Mensaje para control de niveles
    [SerializeField]
    TextMeshProUGUI mensajeText;

    //Tiempo visible mensaje de estado
    float tiempoVisible = 5.0F;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //Metodo para entrar a los distintos niveles
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Level 1")
        {
            //Validacion de niveles, el estado del nivel se cambia a true si ya se ha completado
            //Este estado se cambia una vez que se obtiene la gema del nivel
            if (StateManager.Instance.getLevel1() == false)
            {
                LevelManager.Instance.SceneName("Level 1");  
            }
            else
            {
                mensajeText.text = "El nivel ya ha sido completado";
                //Borrar mensaje
                Invoke("BorrarMensaje", tiempoVisible);
            }
            
        }else if (other.gameObject.tag == "Level 2")
        {
            if (StateManager.Instance.getLevel1() != true)
            {
                mensajeText.text = "Debe completar el nivel 1 antes de avanzar";
                //Borrar mensaje
                Invoke("BorrarMensaje", tiempoVisible);
            }
            else if (StateManager.Instance.getLevel2() == false && StateManager.Instance.getLevel1() == true)
            {
                LevelManager.Instance.SceneName("Level 2");
            }else if (StateManager.Instance.getLevel2() == true)
            {
                mensajeText.text = "El nivel ya ha sido completado";
                //Borrar mensaje
                Invoke("BorrarMensaje", tiempoVisible);
            }
        }
        else if(other.gameObject.tag == "Final Boss")
        {
            if (StateManager.Instance.getLevel2() != true)
            {
                mensajeText.text = "Debe completar el nivel 2 antes de avanzar";
                //Borrar mensaje
                Invoke("BorrarMensaje", tiempoVisible);
            }
            else if (StateManager.Instance.getFinalBoss() == false && StateManager.Instance.getLevel1() == true && StateManager.Instance.getLevel2() == true)
            {
                LevelManager.Instance.SceneName("Final Boss");
            }
            else if (StateManager.Instance.getFinalBoss() == true)
            {
                mensajeText.text = "Ya ha completado el juego";
                //Borrar mensaje
                Invoke("BorrarMensaje", tiempoVisible);
            }  
        }

        //NOTA: El codigo está completo para una mejor comprensión, la cadena de IFS se puede simplificar más adelante.
    }

    //Metodo para borrar mensaje
    void BorrarMensaje()
    {
        mensajeText.text = "";
    }

}

