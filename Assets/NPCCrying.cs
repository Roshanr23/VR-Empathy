using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCCrying : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    public GameObject person;
    Boolean already = false;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(true);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
    }
    public void DoneYet() {
        already = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (already)
        {
            person.transform.Rotate(0, 180, 0);
            Vector3 x = new Vector3(-7f, 0f, 11f);
            person.transform.position = x;
            already = false;
        }
    }
}
