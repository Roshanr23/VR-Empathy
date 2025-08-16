using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class ChangeHealth : MonoBehaviour
{
    //public GameObject healthBar;
    // Start is called before the first frame update
    public Volume postProcessingVolume;
    public ColorAdjustments colorAdjustments;
    public double health;
    public GameObject BlackUI;
    void Start()
    {
        this.health = 1;
        if (postProcessingVolume != null && postProcessingVolume.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.saturation.value = 100f; // Full color at start
        }
        BlackUI.SetActive(false);
    }

    public void LowerHealth()
    {
        this.gameObject.transform.localScale -= new Vector3(.25f, 0f, 0f);
        this.health -= .25;
        if (this.health > .5 && this.health <= .75 && colorAdjustments != null)
        {
            colorAdjustments.saturation.value = 0f;
            //make screen grayer
        }
        else if (this.health <= .5 && colorAdjustments != null)
        {
            colorAdjustments.saturation.value = -100f;
        }
        if (this.health == 0)
        {
            BlackUI.SetActive(true);
            StartCoroutine(QuitAfterDelay(10f));
            //end game
        }
    }

    private IEnumerator QuitAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
}

    public void UpperHealth()
    {
        this.gameObject.transform.localScale += new Vector3(.25f, 0f, 0f);
        if (this.health != 2)
        {
            this.health += .25;
        }
        if (this.health == .75 && colorAdjustments != null)
        {
            colorAdjustments.saturation.value = 0f;
        }
        else if (this.health >= 1 && colorAdjustments != null)
        {
            colorAdjustments.saturation.value = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
