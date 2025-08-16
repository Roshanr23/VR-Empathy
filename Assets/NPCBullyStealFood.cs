using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCBullyStealFood : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject person;
    Boolean already = false;
    // Start is called before the first frame update
    void Start()
    {
        UI1.SetActive(true);
        UI2.SetActive(false);
        UI3.SetActive(false);
    }

    public void DoneYet() {
        already = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (already)
        {
            Vector3 x = new Vector3(4.266287f, 0f, 10.48f);
            person.transform.position = x;
            Finale.bully2 = true;
            Debug.Log("2");
            already = false;
        }
    }
}
