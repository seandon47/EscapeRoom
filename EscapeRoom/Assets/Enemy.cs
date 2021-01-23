﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int DamagePlayer;

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
        DroneCollider PC = collision.gameObject.GetComponent<DroneCollider>();

        if (PC != null)
        {
            PC.CollideWithEnemy(this);
        }
    }
}
