using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BuildAreaRingController : MonoBehaviour
{
    #region Properties

    [SerializeField] float thickness = 0.2f;
    
    [SerializeField] SphereCollider collider;

    MaterialPropertyBlock mpb;
    public MaterialPropertyBlock Mpb
    {
        get
        {
            if (mpb == null)
                mpb = new MaterialPropertyBlock();
            return mpb;
        }
    }

    Renderer renderer;

    #endregion
    
    #region Visuals
    
    float CalculateRadius() 
    {
        // No collider assigned
        if (collider == null) {
            return 1f;
        }

        return collider.radius;
    }

    #endregion

    void OnValidate() {
        if (!renderer) {
            renderer = GetComponent<Renderer>();
        }
    }

    void Start()
    {
        if (!renderer)
        {
            renderer = GetComponent<Renderer>();
        }
    }

    void Update() {
        if (renderer) {
            renderer.GetPropertyBlock(Mpb, 0);
        
            Mpb.SetVector("_Position", transform.parent ? transform.parent.position : transform.position);
            Mpb.SetFloat("_Radius", CalculateRadius());
            Mpb.SetFloat("_RingThickness", thickness);

            renderer.SetPropertyBlock(Mpb, 0);
        }
        
    }
}
