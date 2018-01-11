using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIconScript : MonoBehaviour {

    public float UIScaleModifier;

    // If mouse is over UI icon, enlarge
    public void Enlarge()
    {
        transform.localScale = new Vector3(UIScaleModifier, UIScaleModifier, 1.0f);
    }
    
    // Reduce size when cursor leaves
    public void Reduce()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
