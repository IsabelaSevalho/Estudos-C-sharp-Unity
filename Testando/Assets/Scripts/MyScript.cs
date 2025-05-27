using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necessário para o Button
using TMPro; // Necessário para TMP_InputField
using LLMUnity;

public class MyScript : MonoBehaviour
{
    public LLMCharacter llmCharacter;
    public TMP_InputField inputField;
    public Button sendButton;
    public TextMeshProUGUI responseText;

    void Start()
    {
        // Liga o botão à função de envio
        sendButton.onClick.AddListener(OnSendButtonClick);

        responseText.text = "";
    }

    void OnSendButtonClick()
    {
        string message = inputField.text; //texto do usuário
        if (!string.IsNullOrEmpty(message))
        {
            _ = llmCharacter.Chat(message, HandleReply, ReplyCompleted);
            inputField.text = ""; // Limpa o campo de entrada
        }
    }

    void HandleReply(string reply) //resposta do modelo
    {
        // Mostra a resposta no console
        responseText.text = "Bot: " + reply;
        Debug.Log("Resposta do modelo: " + reply);
    }

    void ReplyCompleted() //opcional, chamado quando a resposta está completa
    {
        Debug.Log("Resposta completa!");
    }
}
