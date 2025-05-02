using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerInputs inputActions;

    public float speed = 2.7f; //public para poder ser acessada e alterada no unity

    SpriteRenderer spriteRenderer; //refer�ncia para o sprite renderer para poder flipar

    // Start is called before the first frame update
    //Awake � chamado antes do start
    void Awake()
    {
        //Debug.Log("Awake est� funcionando");
        inputActions = new PlayerInputs();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //procura o sprite renderer dos componentes no game object
    }

    private void OnEnable()
    {
        //inicializar
        inputActions.Enable();
    }

    private void OnDisable()
    {
        //desativar
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update est� funcionando");

        //verifica o valor do bot�o que est� clicando
        var moveInputs = inputActions.Player_Map.Movement.ReadValue<Vector2>();

        //considera o bot�o selecionado
        //Time.deltaTime para movimentar de forma mais fluida, num tempo constante
        //multiplica a velocidade (speed) com o deltaTime e com a dire��o
        transform.position += speed * Time.deltaTime * new Vector3(moveInputs.x, 0, 0);

        if (moveInputs.x != 0) //para n�o mudar toda hora
        {
            spriteRenderer.flipX = moveInputs.x < 0; //se for para a esquerda
        }
    }
}
