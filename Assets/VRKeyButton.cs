using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VRKeyButton : MonoBehaviour
{
    public TMP_Text keyLabel;
    public VRKeyboard keyboard; // Assign in Inspector

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            string key = keyLabel.text;

            if (key == "⌫" || key.ToLower() == "backspace")
            {
                keyboard.OnBackspace();
            }
            else
            {
                keyboard.OnKeyPress(key);
            }
        });
    }
}
