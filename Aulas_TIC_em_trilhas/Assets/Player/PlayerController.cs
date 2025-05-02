using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerInputs inputActions;

    // Start is called before the first frame update
    //Awake é chamado antes do start
    void Awake()
    {
        //Debug.Log("Awake está funcionando");
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
        //Debug.Log("Update está funcionando");

        //verifica o valor do botão que está clicando
        var moveInputs = inputActions.Player_Map.Movement.ReadValue<Vector2>();

        //considera o botão selecionado
        //Time.deltaTime para movimentar de forma mais fluida, num tempo constante
        transform.position += Time.deltaTime * new Vector3(moveInputs.x, 0, 0);
    }
}
