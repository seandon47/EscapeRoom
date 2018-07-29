using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInteractable : MonoBehaviour {
    protected Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Select(bool Selected)
    {
        if (Selected)
        {
            //oldShader = rend.material.shader;
            //rend.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
            rend.material.shader = Shader.Find("SelectedImageEffectShader");

            //oldColor = rend.material.color;
            //rend.material.color = Color.green;
        }
        else
        {
            //rend.material.shader = oldShader;
            rend.material.shader = Shader.Find("Diffuse");

            //rend.material.color = Color.white;
        }
    }

    public virtual void Activated()
    {

    }
}
