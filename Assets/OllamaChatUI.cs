using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class OllamaChatUI : MonoBehaviour
{
    public OllamaClient ollamaClient;  // Assign in inspector
    public TMP_InputField inputField;
    public TMP_Text responseText;
    public Button sendButton;           // Assign in inspector

    void Start()
    {
        sendButton.onClick.AddListener(OnSendClicked);
        // Send initial AI message on scene start
        string prompt = "You are a friendly school counselor. Say hello to the player and ask if they need any advice. 20 words max for all responses.";
        StartCoroutine(SendPromptAndShowResponse(prompt));
    
    }

    void OnSendClicked()
    {
        string prompt = inputField.text.Trim();
        if (!string.IsNullOrEmpty(prompt))
        {
            responseText.text = "Thinking...";
            StartCoroutine(SendPromptAndShowResponse(prompt));
        }
    }

    IEnumerator SendPromptAndShowResponse(string prompt)
    {
        bool done = false;
        string aiReply = null;

        ollamaClient.SendPromptWithCallback(prompt, (reply) =>
        {
            aiReply = reply;
            done = true;
        });

        while (!done)
            yield return null;

        responseText.text = aiReply;
    }
}
