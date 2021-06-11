using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEnabler : MonoBehaviour
{
    RectTransform imgRectTransform;
    private GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        imgRectTransform = GetComponent<RectTransform>();
        cursor = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        cursor.SetActive(true);
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        cursor.SetActive(false);
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
