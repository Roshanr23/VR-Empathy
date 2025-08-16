using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyCheck : MonoBehaviour
{
    public GameObject keyObject;
    // Start is called before the first frame update
    void Start()
    {
        // Initialization code here
    }

    void OnEnable()
    {
        if (keyObject != null)
        {
            var grabInteractable = keyObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnKeyGrabbed);
            }
        }
    }

    void OnDisable()
    {
        if (keyObject != null)
        {
            var grabInteractable = keyObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.RemoveListener(OnKeyGrabbed);
            }
        }
    }

    private void OnKeyGrabbed(SelectEnterEventArgs args)
    {
        keyObject.SetActive(false);
        if (keyObject.CompareTag("key"))
        {
           Finale.haskey = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Per-frame logic here
    }
}
