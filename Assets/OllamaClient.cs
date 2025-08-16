using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class OllamaResponse
{
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
}

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}

public class OllamaClient : MonoBehaviour
{
    private string apiUrl = "http://localhost:11434/v1/chat/completions";

    // Sends a prompt without callback (optional)
    public void SendPrompt(string prompt)
    {
        StartCoroutine(SendPromptCoroutine(prompt));
    }

    // Sends prompt with callback to return AI reply
    public void SendPromptWithCallback(string prompt, Action<string> callback)
    {
        StartCoroutine(SendPromptCoroutineCallback(prompt, callback));
    }

    private IEnumerator SendPromptCoroutine(string prompt)
    {
        string systemMessage = "You are a school counselor in a VR game. You talk to students who are getting bullied. Be kind, never mean. Use short and helpful responses.";

string json = "{\"model\":\"mistral\",\"messages\":[" +
              "{\"role\":\"system\",\"content\":\"" + systemMessage.Replace("\"", "\\\"") + "\"}," +
              "{\"role\":\"user\",\"content\":\"" + prompt.Replace("\"", "\\\"") + "\"}" +
              "]}";


        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error + "\n" + request.downloadHandler.text);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                OllamaResponse response = JsonUtility.FromJson<OllamaResponse>(jsonResponse);

                if (response != null && response.choices.Length > 0)
                {
                    string aiReply = response.choices[0].message.content;
                    Debug.Log("AI Reply: " + aiReply);
                }
                else
                {
                    Debug.LogWarning("No choices returned in response");
                }
            }
        }
    }

    private IEnumerator SendPromptCoroutineCallback(string prompt, Action<string> callback)
    {
        string systemMessage = "You are a school counselor in a VR game. You talk to students who are getting bullied. Be kind, never mean. Use short and helpful responses.";

string json = "{\"model\":\"mistral\",\"messages\":[" +
              "{\"role\":\"system\",\"content\":\"" + systemMessage.Replace("\"", "\\\"") + "\"}," +
              "{\"role\":\"user\",\"content\":\"" + prompt.Replace("\"", "\\\"") + "\"}" +
              "]}";

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error + "\n" + request.downloadHandler.text);
                callback?.Invoke("Error: " + request.error);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                OllamaResponse response = JsonUtility.FromJson<OllamaResponse>(jsonResponse);

                if (response != null && response.choices.Length > 0)
                {
                    string aiReply = response.choices[0].message.content;
                    callback?.Invoke(aiReply);
                }
                else
                {
                    callback?.Invoke("No response from AI.");
                }
            }
        }
    }
}
