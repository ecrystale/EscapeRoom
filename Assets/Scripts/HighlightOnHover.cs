using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour{

    Color startcolor;
    MeshRenderer _renderer;
    float tintFactor = 0.4f;

    void Start(){
       _renderer = GetComponent<MeshRenderer>();
    }

    void OnMouseEnter(){
        startcolor = _renderer.material.color;
        _renderer.material.color = new Color((startcolor.r * 255 + (255 - startcolor.r * 255) * tintFactor) / 255,
                                             (startcolor.g * 255 + (255 - startcolor.g * 255) * tintFactor) / 255,
                                             (startcolor.b * 255 + (255 - startcolor.b * 255) * tintFactor) / 255);
    }
 
    void OnMouseExit(){
        _renderer.material.color = startcolor;
    }
}
