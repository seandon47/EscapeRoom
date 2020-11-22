using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScripting : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "HandColliderLeft(Clone)" || collision.gameObject.name == "HandColliderRight(Clone)" collision.gameObject.name == "BodyCollider")
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    }
}
