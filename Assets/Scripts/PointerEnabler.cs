using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEnabler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform imgRectTransform;
    [SerializeField]
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
        if(pointerIsInside())cursor.SetActive(true);
        else cursor.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.SetActive(true);
    }

    // ...and the mesh finally turns white when the mouse moves away.
    public void OnPointerExit(PointerEventData eventData)
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
