using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSwaper : MonoBehaviour
{
    [SerializeField]
    private Sprite swapImage;
    private Image imageHolder;
    // Start is called before the first frame update
    void Start()
    {
        imageHolder= GameObject.FindGameObjectWithTag("Cursor").GetComponent<Image>();
    }

    public void ButtonClicked(){
        imageHolder.sprite = swapImage;
    }
}
