using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnableDisable : MonoBehaviour
{
    [SerializeField]
    public static ButtonEnableDisable me;
    [SerializeField]
    private GameObject gObject;
    [SerializeField]
    private GameObject gObject2;
    bool isActiveGObj = false;
    private Image image;

    void Start(){
        me=this;
        isActiveGObj = gObject.active;
        ButtonClicked();
    }
    public void ButtonClicked(){
        isActiveGObj=!isActiveGObj;
        gObject.SetActive(isActiveGObj);
        gObject2.SetActive(!isActiveGObj);
        image = gObject.GetComponentInChildren<Image>();
        InitializeResult.me.RefreshImage();
        updateImage();

    }

    public void updateImage()
    {
        if(image)
            image.sprite=GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().currentDoodleSprite;
    }
}
