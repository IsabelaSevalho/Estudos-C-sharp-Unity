using UnityEngine;
using UnityEngine.UI; // Necessário para o Button
using TMPro; // Necessário para TMP_InputField
using LLMUnity;

public class LLMChat : MonoBehaviour
{
    public LLMCharacter llmCharacter;
    public TMP_InputField inputField;
    public Button sendButton;
    public TextMeshProUGUI responseText;

    public AnimatorRobot animadorPersonagem; // Referência externa

    void Start()
    {
        // Liga o botão à função de envio
        sendButton.onClick.AddListener(OnSendButtonClick);

        responseText.text = "Olá, qual é sua dúvida hoje?";

        if (animadorPersonagem != null)
            animadorPersonagem.TriggerAnimation("Wave");
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

        if (animadorPersonagem == null) return;

        if (reply.Contains("Hi") || reply.Contains("Hello") || reply.Contains("Olá") || reply.Contains("Oi") || reply.Contains("Hey"))
            animadorPersonagem.TriggerAnimation("Wave"); // wave

        else if (reply.Contains("Bye") || reply.Contains("See you later") || reply.Contains("Tchau") || reply.Contains("Até logo"))
            animadorPersonagem.TriggerAnimation("Walk"); // walk

        else
            animadorPersonagem.TriggerAnimation("Idle"); // idle
    }

    void ReplyCompleted() //opcional, chamado quando a resposta está completa
    {
        Debug.Log("Resposta completa!");
    }
}
