using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinkable : MonoBehaviour
{
    public bool IsShrunk { get; private set; }
    public Vector3 OriginalScale;
    public float ShrinkSpeed;
    public float ShrinkToSize;
    private bool IsShrinking;
    private bool IsGrowing;

    // Start is called before the first frame update
    void Start()
    {
        IsShrinking = false;
        IsGrowing = false;
        IsShrunk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShrinking)
            Shrink();
        else if (IsGrowing)
            Grow();
        
    }

    public void ShrinkObject()
    {
        IsShrinking = true;
    }

    public void GrowObject()
    {
        IsGrowing = true;
    }

    private void Grow()
    {
        transform.localScale += new Vector3(ShrinkSpeed, ShrinkSpeed,ShrinkSpeed) * 1;
        if (transform.localScale.x >= OriginalScale.x)
        {
            transform.localScale = OriginalScale;
            IsGrowing = false;
            IsShrunk = false;
        }            
    }

    private void Shrink()
    {
        transform.localScale += new Vector3(ShrinkSpeed, ShrinkSpeed, ShrinkSpeed) * -1;
        if (transform.localScale.x <= ShrinkToSize)
        {
            transform.localScale = new Vector3(0, 0, 0);
            IsShrinking = false;
            IsShrunk = true;
        }
    }
}
