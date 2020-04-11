using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RattleEffect : MonoBehaviour
{
    private AudioSource Audio;
    private Rigidbody Body;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (/*Body.velocity.magnitude >= 0.1 &&*/ !Audio.isPlaying)
        {
            Audio.Play();
        }
    }
}
