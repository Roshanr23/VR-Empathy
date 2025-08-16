using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogUI;
    public GameObject dialogUI2;
    public GameObject dialogUI3;
    public GameObject dialogUI4;
    private bool conversationCompleted = false;
    private void Start()
    {
        if (dialogUI != null)
        {
            dialogUI.SetActive(false);
            dialogUI2.SetActive(false);
            dialogUI3.SetActive(false);
            dialogUI4.SetActive(false);
            Debug.Log("UI reset to inactive at start.");
        }
        else
        {
            Debug.LogError("dialogUI is not assigned at Start!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with: " + other.name);

        if ((other.CompareTag("MainCamera")||other.CompareTag("Player"))&&!conversationCompleted)
        {
            Debug.Log("Player detected, showing UI");
            if (dialogUI != null) dialogUI.SetActive(true);
        }
    }

    private void OllisionEnter(Collision collision)
    {
        Debug.Log("HI");
    }
    
    public void converstationComplete()
    {
        this.conversationCompleted = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player"))
        {
            Debug.Log("Player left, hiding UI");
            if (dialogUI != null) dialogUI.SetActive(false);
        }
    }
}
