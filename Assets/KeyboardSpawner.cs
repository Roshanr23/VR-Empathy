using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardSpawner : MonoBehaviour
{
    public GameObject keyPrefab;        // Your key button prefab
    public Transform keyboardPanel;     // Panel with Vertical Layout Group (parent of rows)
    public VRKeyboard keyboardScript;   // Script that handles keyboard input

    private string[] rows = new string[] {
        "QWERTYUIOP",
        "ASDFGHJKL",
        "ZXCVBNM",
    };

    void Start()
    {
        // Add layout components if missing
        var vLayout = keyboardPanel.GetComponent<VerticalLayoutGroup>();
        if (vLayout == null)
        {
            vLayout = keyboardPanel.gameObject.AddComponent<VerticalLayoutGroup>();
            vLayout.childControlHeight = true;
            vLayout.childControlWidth = true;
            vLayout.childForceExpandHeight = false;
            vLayout.childForceExpandWidth = false;
            vLayout.spacing = 10;
            vLayout.childAlignment = TextAnchor.UpperCenter;
        }

        var fitter = keyboardPanel.GetComponent<ContentSizeFitter>();
        if (fitter == null)
        {
            fitter = keyboardPanel.gameObject.AddComponent<ContentSizeFitter>();
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

        // Clear existing keys
        foreach (Transform child in keyboardPanel)
            Destroy(child.gameObject);

        // Build rows and keys
        foreach (string row in rows)
        {
            GameObject rowGO = new GameObject("Row", typeof(RectTransform));
            rowGO.transform.SetParent(keyboardPanel);
            rowGO.transform.localScale = Vector3.one;

            var hLayout = rowGO.AddComponent<HorizontalLayoutGroup>();
            hLayout.spacing = 10;
            hLayout.childForceExpandHeight = false;
            hLayout.childForceExpandWidth = false;
            hLayout.childControlHeight = true;
            hLayout.childControlWidth = true;
            hLayout.childAlignment = TextAnchor.MiddleCenter;

            var rowFitter = rowGO.AddComponent<ContentSizeFitter>();
            rowFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            rowFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            RectTransform rowRT = rowGO.GetComponent<RectTransform>();
            rowRT.pivot = new Vector2(0.5f, 0.5f);
            rowRT.anchorMin = new Vector2(0.5f, 0.5f);
            rowRT.anchorMax = new Vector2(0.5f, 0.5f);
            rowRT.anchoredPosition3D = Vector3.zero;
            rowRT.localScale = Vector3.one;
            rowRT.localRotation = Quaternion.Euler(0f, 180f, 0f); // flip 180 if needed

            foreach (char c in row)
            {

                GameObject key = Instantiate(keyPrefab, rowGO.transform, false);
                key.GetComponentInChildren<TMP_Text>().text = c.ToString();

                var keyBtn = key.GetComponent<VRKeyButton>();
                keyBtn.keyLabel = key.GetComponentInChildren<TMP_Text>();
                keyBtn.keyboard = keyboardScript;

                var layoutElement = key.GetComponent<LayoutElement>();
                if (layoutElement == null) layoutElement = key.AddComponent<LayoutElement>();
                layoutElement.preferredWidth = 60;
                layoutElement.preferredHeight = 60;
            }

            
            // Add backspace to last row
            if (row == "ZXCVBNM")
            {
                GameObject backspaceKey = Instantiate(keyPrefab, rowGO.transform, false);
                
                // Set label
                TMP_Text label = backspaceKey.GetComponentInChildren<TMP_Text>();
                label.text = "⌫";

                // REMOVE the VRKeyButton to stop it from calling OnKeyPress
                DestroyImmediate(backspaceKey.GetComponent<VRKeyButton>());

                // Add onClick for backspace
                var button = backspaceKey.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => keyboardScript.OnBackspace());

                // Set size
                var layoutElement = backspaceKey.GetComponent<LayoutElement>();
                if (layoutElement == null) layoutElement = backspaceKey.AddComponent<LayoutElement>();
                layoutElement.preferredWidth = 90;
                layoutElement.preferredHeight = 60;
            }

        }

        // Fix keyboard panel layout
        RectTransform panelRT = keyboardPanel.GetComponent<RectTransform>();
        panelRT.pivot = new Vector2(0.5f, 0.5f);
        panelRT.anchorMin = new Vector2(0.5f, 0.5f);
        panelRT.anchorMax = new Vector2(0.5f, 0.5f);
        panelRT.anchoredPosition3D = Vector3.zero;
        panelRT.localScale = Vector3.one;
    }
}
