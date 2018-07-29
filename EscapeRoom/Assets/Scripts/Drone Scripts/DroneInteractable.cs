using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInteractable : MonoBehaviour {
    Renderer rend;
    Shader oldShader;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select(bool Selected)
    {
        if (Selected)
        {
            //oldShader = rend.material.shader;
            //rend.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
            rend.material.shader = Shader.Find("SelectedImageEffectShader");
        }
        else
        {
            //rend.material.shader = oldShader;
            rend.material.shader = Shader.Find("Diffuse");
        }
    }
}
