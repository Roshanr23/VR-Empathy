using TMPro;
using UnityEngine;

public class VRKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject keyboardCanvas;

    void Start()
    {
        keyboardCanvas.SetActive(false);
    }    
    
    public void OnKeyPress(string key)
    {
        if (inputField != null)
        {
            inputField.text += key;
            inputField.MoveTextEnd(false); // Deselect all, move caret to end
        }
    }



public void OnBackspace()
    {
        if (inputField != null && inputField.text.Length > 0)
        {
            // Remove the last character from the inputField
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            inputField.caretPosition = inputField.text.Length;
        }
    }


    public void ShowKeyboard(TMP_InputField target)
    {
        inputField = target;
        keyboardCanvas.SetActive(true);
        inputField.ActivateInputField();
    }
}
