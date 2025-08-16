using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC2Interaction : MonoBehaviour
{
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    public GameObject bully;
    public GameObject bullied;
    Boolean already = false;

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
            Vector3 x = new Vector3(3f, 0f, 8f);
            bully.transform.position = x;
            Animator bulliedAnimator = bullied.GetComponent<Animator>();
            if (bulliedAnimator != null)
            {
                bulliedAnimator.Play("Idle", 0, 0f); // This will play the Idle animation from the start
                bulliedAnimator.speed = 1; // Ensure the animation runs at normal speed
            }
            already = false;
            Finale.bully3 = true;
            Debug.Log("3");
        }
    }
    
    
}
