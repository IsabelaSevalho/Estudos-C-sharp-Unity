using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //para usar a interface

public class PlayerContactHandler : MonoBehaviour //é o player
{
    public Image itemImage;//pegando uma referência da image (ovo superior esquerdo)
    bool canWinLevel = false;

    private void OnCollisionEnter2D(Collision2D collision) //função que detecta uma colisão de colliders ("corpo" de um item)
    {
        //Collision2D collision é o outro corpo que encostou no player

        if (collision.gameObject.CompareTag("Enemy"))//if que verifica se a tag do objeto que encostou é a que queremos
        { 
            
        }
    }

    /*Em Unity, um "trigger" (ou gatilho) é um tipo especial
        de collider que, ao ser intersado, não causa uma colisão física,
        mas sim aciona um evento*/

    private void OnTriggerEnter2D(Collider2D collision) //verifica se o player encostou no ovo
    {
        if (collision.gameObject.CompareTag("Item"))//if que verifica se a tag do objeto que encostou é a que queremos
        {
            //item deve sumir quando encosta
            Destroy(collision.gameObject); //destruindo
            itemImage.color = Color.white; //deixa o ovo com sua cor original
            canWinLevel = true;
        }

        if (collision.gameObject.CompareTag("FinalPoint"))//verificando se encostou no ninho para ser ganho de fase
        {
            if (canWinLevel) //verificando se passou de fase
            {

            }
            else
            {
                
            }
        }
    }
}
