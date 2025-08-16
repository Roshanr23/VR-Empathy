using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogTrigger : MonoBehaviour
{
    public GameObject firstPanel; // Assign the NPC dialogue UI panel or object to activate
    public GameObject secondPanel;
    public ChangeHealth ch;
    private Boolean already = false;
    // Start is called before the first frame update
    void Start()
    {
        secondPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!already && other.CompareTag("Hotdog"))
        {
            Debug.Log("Hotdog given!");
            firstPanel.SetActive(false);
            secondPanel.SetActive(true);
            ch.UpperHealth();
            other.gameObject.SetActive(false);
            already = true;
        }
    }
}
