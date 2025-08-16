using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFinal : MonoBehaviour
{
    public GameObject UI;
    public GameObject UI2;
    public GameObject UI3;
public GameObject UI4;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(true);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
    }

    public void finish()
    {
        StartCoroutine(QuitAfterDelay(10f));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
