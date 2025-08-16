using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBullyBathroom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    public GameObject UI5;
    public GameObject bully;
    Boolean already = false;
    void Start()
    {
        UI1.SetActive(true);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
        UI5.SetActive(false);
    }
    public void DoneYet() {
        already = true;
    }

    public void changeDirection()
    {
        if (bully != null)
        {
            bully.transform.Rotate(0, 180, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (already)
        {
            bully.transform.Rotate(0, 180, 0);
            Vector3 x = new Vector3(3f, 0f, 12f);
            bully.transform.position = x;
            Finale.bully1 = true;
            Debug.Log("1");
            already = false;
        }
    }
}
