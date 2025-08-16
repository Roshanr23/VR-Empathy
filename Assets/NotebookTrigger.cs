using UnityEngine;

public class NotebookTrigger : MonoBehaviour
{
    public GameObject firstPanel; // Assign the NPC dialogue UI panel or object to activate
    public GameObject secondPanel;
    public ChangeHealth ch;
    void Start()
    {
        secondPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Notebook"))
        {
            Debug.Log("Notebook placed on desk!");
            firstPanel.SetActive(false);
            secondPanel.SetActive(true);
            ch.UpperHealth();
            other.gameObject.SetActive(false);
        }
    }
}
