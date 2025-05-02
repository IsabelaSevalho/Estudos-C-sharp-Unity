using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerInputs inputActions;

    // Start is called before the first frame update
    //Awake � chamado antes do start
    void Awake()
    {
        //Debug.Log("Awake est� funcionando");
        inputActions = new PlayerInputs();
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
        transform.position += Time.deltaTime * new Vector3(moveInputs.x, 0, 0);
    }
}
