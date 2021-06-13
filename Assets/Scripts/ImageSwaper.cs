using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSwaper : MonoBehaviour
{
    [SerializeField]
    private Sprite swapImage;
    private Image imageHolder;
    private static int setValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        imageHolder= GameObject.FindGameObjectWithTag("Cursor").GetComponent<Image>();
        setValue = 1;
        GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().tileNumber=setValue;
    }

    public void ButtonClicked(){
        if(swapImage==null)return;
        imageHolder.sprite = swapImage;
        for(int i=0;i<ScreenMatrix.me.sprites.Count;i++){
            if(ScreenMatrix.me.sprites[i]==null)return;
            if(swapImage.name.Equals(ScreenMatrix.me.sprites[i].name)){
                setValue=i;
                GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().tileNumber=setValue;
            }
        }
    }
    
}
