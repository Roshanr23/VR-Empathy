using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBathroomCrying : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    Boolean already = false;
    public GameObject person;
    // Start is called before the first frame update
    void Start()
    {
        UI1.SetActive(true);
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
            person.transform.Rotate(0, 90, 0);
            Vector3 x = new Vector3(-7f, 0f, 13f);
            person.transform.position = x;
            already = false;
        }
    }
}
