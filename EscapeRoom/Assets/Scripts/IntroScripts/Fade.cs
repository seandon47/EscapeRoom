using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public GameObject block;
    bool transparent = false, waitCompleted;

	// Use this for initialization
	void Start ()
    {
        if(!transparent)
            StartCoroutine(FadeToBlackCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transparent)
        {
            transparent = false;
            StartCoroutine(Wait());
        }

        if(waitCompleted)
        {
            waitCompleted = false;
            StartCoroutine(FadeToWhiteCoroutine());
        }
    }

    private IEnumerator FadeToBlackCoroutine()
    {
        for (float alpha = 1.0f; alpha > 0f; alpha -= Time.deltaTime/3)
        {
            block.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        transparent = true;

    }

    private IEnumerator FadeToWhiteCoroutine()
    {
        for (float alpha = 0f; alpha < 1.0f; alpha += Time.deltaTime / 3)
        {
            block.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        waitCompleted = true;
    }

}
