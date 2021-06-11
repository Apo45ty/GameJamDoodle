using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEnabler : MonoBehaviour
{
    RectTransform imgRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        imgRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool pointerIsInside(){
        Vector2 localMousePosition = imgRectTransform.InverseTransformPoint(Input.mousePosition);
        if (imgRectTransform.rect.Contains(localMousePosition))
        {
            return true;
        } else {
            return false;
        }
    }
}
