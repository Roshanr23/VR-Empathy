using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InputFieldClick : MonoBehaviour, IPointerClickHandler
{
    public VRKeyboard keyboard;

    public void OnPointerClick(PointerEventData eventData)
    {
        keyboard.ShowKeyboard(GetComponent<TMP_InputField>());
    }
}
