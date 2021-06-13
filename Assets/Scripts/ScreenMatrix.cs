using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenMatrix : MonoBehaviour
{
    public static ScreenMatrix me;
    [SerializeField]
    public List<Sprite> sprites=new List<Sprite>();
    public List<string> spritesName=new List<string>();
    [SerializeField]
    private Sprite higlightImage;
    [SerializeField]
    public Image SourceRoom;
    private int numberWidth;
    private int numberHeight;
    public int[,] spaces;
    public Image[,] images;
    public static Sprite highlightImage;
    public GameObject staticGameImage;

    // Start is called before the first frame update
    void Start()
    {
        me = this;
        highlightImage = sprites[0];
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i] == null)
                continue;
            string s = sprites[i].name;
            spritesName.Add(s);
        }
        SourceRoom = transform.parent.GetComponent<Image>();
        staticGameImage = new GameObject("gameobjectStatic");
        RectTransform rectTransformTemp = staticGameImage.AddComponent<RectTransform>();
        rectTransformTemp.anchorMin = new Vector2(0, 1);
        rectTransformTemp.anchorMax = new Vector2(0, 1);
        rectTransformTemp.pivot = new Vector2(0.5f, 0.5f);
        rectTransformTemp.sizeDelta = new Vector2(higlightImage.bounds.size.x * 100, higlightImage.bounds.size.y * 100);
        Image tempImage = staticGameImage.AddComponent<Image>();
        staticGameImage.transform.parent = SourceRoom.transform;
        numberWidth = (int)(SourceRoom.rectTransform.sizeDelta.x / higlightImage.rect.width);
        numberHeight = (int)(SourceRoom.rectTransform.sizeDelta.y / higlightImage.rect.height);
        print(numberWidth + " " + numberHeight);
        spaces = new int[numberWidth, numberHeight];
        images = new Image[numberWidth, numberHeight];
        int x = (int)SourceRoom.rectTransform.position.x;
        int y = (int)SourceRoom.rectTransform.position.y;
        InitializeMatrix();
    }

    public void InitializeMatrix()
    {
        for (int i = 1; i <= numberHeight; i++)
        {
            for (int j = 0; j < numberWidth; j++)
            {
                spaces[j, i - 1] = 0;
                GameObject go = new GameObject("gameobject");
                HighligthOnImaageEnter temp = go.AddComponent<HighligthOnImaageEnter>();
                temp.x = j;
                temp.y = i - 1;
                RectTransform rectTransform = go.AddComponent<RectTransform>();
                rectTransform.anchorMin = new Vector2(0, 1);
                rectTransform.anchorMax = new Vector2(0, 1);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
                rectTransform.sizeDelta = new Vector2(higlightImage.bounds.size.x * 100, higlightImage.bounds.size.y * 100);
                rectTransform.transform.parent = SourceRoom.transform;

                Image image = go.gameObject.AddComponent<Image>();
                image.sprite = higlightImage;
                images[j, i - 1] = image;
                go.GetComponent<RectTransform>().anchoredPosition = new Vector3(higlightImage.bounds.size.x * 100 / 2 + j * higlightImage.bounds.size.x * 100,
                higlightImage.bounds.size.y * 100 / 2 + -1 * higlightImage.bounds.size.y * 100 * i, 0);

            }
        }
    }
    public void clearMatrix(){
        foreach(Image i in images){
            Destroy(i.gameObject);
        }
        images=new Image[numberWidth, numberHeight];
    }
    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < numberHeight; j++)
        {
            for (int i = 0;i < numberWidth; i++)
            {
                images[i,j].sprite = sprites[spaces[i,j]]; 
            }
        }
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     string test ="";
        //     test+="/************************\n";
        //     for (int j = 0; j < numberHeight; j++)
        //     {
        //         for (int i = 0;i < numberWidth; i++)
        //         {
        //             images[i,j].sprite = sprites[spaces[i,j]]; 
        //             if(spaces[i,j]==1)
        //                 print(i+" "+j+" "+spaces[i,j]+" "+sprites[spaces[i,j]].name);
        //             test+=spaces[i,j];
        //         }
        //         test+="\n";
        //     }
        //     print(test);
        // }
        
    }
}
