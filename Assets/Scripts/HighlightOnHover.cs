using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour{

    Color startcolor;
    Color lighterHue;
    MeshRenderer _renderer;
    float tintFactor = 0.4f;

    void Start(){
       _renderer = GetComponent<MeshRenderer>();
       startcolor = _renderer.material.color;
       lighterHue = new Color((startcolor.r * 255 + (255 - startcolor.r * 255) * tintFactor) / 255,
                                             (startcolor.g * 255 + (255 - startcolor.g * 255) * tintFactor) / 255,
                                             (startcolor.b * 255 + (255 - startcolor.b * 255) * tintFactor) / 255);
    }

    void OnMouseEnter(){
        _renderer.material.color = lighterHue;
    }
 
    void OnMouseExit(){
        _renderer.material.color = startcolor;
    }
}
