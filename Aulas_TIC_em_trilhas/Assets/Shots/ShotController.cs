using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script para verificar se o ovo tocou o inimigo
public class ShotController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            Destroy(collision.gameObject); //destruindo o inimigo
            Destroy(gameObject); //destruindo a si mesmo
        }
    }
}
