using UnityEngine;

public class TestOllama : MonoBehaviour
{
    public OllamaClient ollamaClient;

    void Start()
    {
        if (ollamaClient != null)
        {
            ollamaClient.SendPrompt("Hello Ollama! Can you respond?");
        }
        else
        {
            Debug.LogError("OllamaClient reference not set!");
        }
    }
}
