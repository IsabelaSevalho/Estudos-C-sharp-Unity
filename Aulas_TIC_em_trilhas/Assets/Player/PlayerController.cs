using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerInputs inputActions;

    public float speed = 2.7f; //public para poder ser acessada e alterada no unity
    public float jumpForce = 5f;

    bool canJump = true;//para impedir pulos duplos/triplos e etc

    SpriteRenderer spriteRenderer; //refer�ncia para o sprite renderer para poder flipar
    Animator animator;
    Rigidbody2D body;

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
        animator= GetComponent<Animator>(); //pega os componentes do animator (nesse caso � o bool de is Walking)
        body= GetComponent<Rigidbody2D>(); //pega componentes desse tipo (corpo do player)
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
    void Update() //chamada 60 vezes por segundo
    {
        //Debug.Log("Update est� funcionando");

        //verifica o valor do bot�o que est� clicando - Movimento
        var moveInputs = inputActions.Player_Map.Movement.ReadValue<Vector2>();

        //considera o bot�o selecionado
        //Time.deltaTime para movimentar de forma mais fluida, num tempo constante
        //multiplica a velocidade (speed) com o deltaTime e com a dire��o
        transform.position += speed * Time.deltaTime * new Vector3(moveInputs.x, 0, 0);

        //saber se est� andando ou n�o e atribuir valor ao meu componente, id e valor
        animator.SetBool("b_isWalking", moveInputs.x!=0); //=0 � parado

        if (moveInputs.x != 0) //para n�o mudar toda hora
        {
            spriteRenderer.flipX = moveInputs.x < 0; //se for para a esquerda
        }

        //verifica se avelocidade em y � pequena (negativa), provavelmente no ch�o
        canJump = Mathf.Abs(body.velocity.y) <= 0.001f;//se tiver caindo/subindo em uma grande velocidade, n�o pode pular

        HandlerJumpAction();
    }

    //verifica se o botao de pulo foi pressionado
    void HandlerJumpAction()
    {
        var jumpPressed = inputActions.Player_Map.Jump.IsPressed();

        if (canJump && jumpPressed)
        {
            body.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);//aplica for�a, pode ser p cima, p baixo e p lados
            //ForceMode2D.Impulse � for�a de impulso, existe o de for�a tbm 
            //impulso vai de uma vez s�, de for�a � gradativo (tipo aqueles jogos que s� pula se gritar algo e tal)
        }
    }
}
