using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finale : MonoBehaviour
{
    public static Boolean haskey = false;
    public ChangeHealth healthBar;
    public static Boolean bully1 = false;
    public static Boolean bully2 = false;
    public static Boolean bully3 = false;

    public GameObject hiddenBoss;
    public GameObject UIBoss;
    // Start is called before the first frame update
    void Start()
    {
        // Initialization code here
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.health >=1 && haskey&& bully1 && bully2 && bully3)
        {
            PlayerTeleport.finished = true;
            hiddenBoss.transform.Rotate(0, -90, 0);
            Vector3 x = new Vector3(-.4f, 0f, 10f);
            hiddenBoss.transform.position = x;
            UIBoss.SetActive(false);
            haskey = false;
        }
    }
}
