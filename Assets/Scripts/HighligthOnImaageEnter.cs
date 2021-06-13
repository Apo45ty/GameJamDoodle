using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighligthOnImaageEnter : MonoBehaviour
{
    public int x,y;
    private Image tempImage;
    private RectTransform imgRectTransform;
    private ScreenMatrix spacesContainer;
    private KeyCode RotateKey = KeyCode.R;

    // Start is called before the first frame update
    void Start()
    {
        tempImage=GetComponent<Image>();
        imgRectTransform=GetComponent<RectTransform>();
        spacesContainer= GameObject.FindGameObjectWithTag("ScreenMatrix").GetComponent<ScreenMatrix>();
    }

    
        void Update()
    {
        
        if(pointerIsInside()){
            RectTransform basic = GetComponent<RectTransform>();
            tempImage.enabled=true;
            GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().selectedTile=gameObject;
            ScreenMatrix.me.staticGameImage.GetComponent<Image>().sprite = ScreenMatrix.highlightImage;
            ScreenMatrix.me.staticGameImage.GetComponent<RectTransform>().position=this.GetComponent<RectTransform>().position;
            if(Input.GetMouseButton(0)){
                ScreenMatrix.me.spaces[x,y]=GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().tileNumber;
            }
            if(Input.GetKeyDown(RotateKey)){
                basic.eulerAngles+=new Vector3(0,0,90);
            }
            GameObject.FindGameObjectWithTag("Cursor").GetComponent<RectTransform>().rotation=basic.rotation;
        }else if(spacesContainer.spaces[x,y]==0){
            tempImage.enabled=false;
        }


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
