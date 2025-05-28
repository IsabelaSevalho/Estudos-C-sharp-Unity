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

    //para transicionar animações
    public Animator animator;
    public string[] animationNames;

    void Start()
    {
        animator = GetComponent<Animator>();
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

        if (reply.Contains("Hi") || reply.Contains("Hello"))
            PlayAnimationByIndex(1); // wave

        else if (reply.Contains("Bye") || reply.Contains("See you later"))
            PlayAnimationByIndex(2); //walk

        else
            PlayAnimationByIndex(0);
    }

    void ReplyCompleted() //opcional, chamado quando a resposta está completa
    {
        Debug.Log("Resposta completa!");
    }

    //animação
    public void PlayAnimationByIndex(int index)
    {
        if (index >= 0 && index < animationNames.Length)
        {
            animator.Play(animationNames[index]);
        }
    }
}
