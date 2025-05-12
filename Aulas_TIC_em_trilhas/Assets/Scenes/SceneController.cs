using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string goToScene = "HomeScene";//usaremos os nomes para a troca de tela


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //se clicou no espaço
        {
            //scene manager serve para trocar de cenas
            SceneManager.LoadScene(goToScene); //recebe nome ou índice da cena
        }
    }
}
