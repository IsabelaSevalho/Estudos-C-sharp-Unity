using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{

    public float speed = 5f;
    public Transform[] destinations; //array para guadar os waypoints

    int currentIndex=0; //para controlar para que ponto vai no momento
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (destinations.Length==0) //não tem para onde ir
        {
            animator.SetBool("b_isWalking", false);
            return;
        }
        animator.SetBool("b_isWalking", true);

        var currentDestination = destinations[currentIndex]; //destino atual

        //se move até uma determinada posição: posição atual, posição que quer chegar e velocidade
        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, speed * Time.deltaTime);

        spriteRenderer.flipX = transform.position.x > currentDestination.position.x; //se posição x for maior que a que preciso ir == indo p esquerda

        //quando chegar em um waypoint, vai p outro
        if (Vector3.Distance(transform.position, currentDestination.position) <= 0.1f) 
        { 
            //se a distancia atual até onde quer chegar for menor que isso, é pq chegou onde deveria
            currentIndex = (currentIndex+1) % destinations.Length; //método matematico de conseguir resultados 0 e 1 com indices

        }

    }
}
