using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public GameObject block;
    public Scene JonsButt;
    bool transparent = false;

	// Use this for initialization
	void Start ()
    {
        if(!transparent)
            StartCoroutine(FadeToBlackCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private IEnumerator FadeToBlackCoroutine()
    {
        transparent = true;

        for (float alpha = 1.0f; alpha > 0f; alpha -= Time.deltaTime/3)
        {
            block.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        SceneManager.LoadScene("Level1", LoadSceneMode.Single);

    }

}
