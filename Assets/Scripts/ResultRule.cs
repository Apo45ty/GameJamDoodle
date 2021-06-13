using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultRule : MonoBehaviour
{
    public Vector3 TempRotation;
    public int count;
    public int replaceValue;
    void Start(){
        intialize();
    }

    public bool solve(Image[,] images,int[,] board){
        switch(type){
            case RuleType.hardcoded:
            case RuleType.hardcodeSubstitution:
                return firstIsInSecond(hardcodeSpace,board,numberWidth,numberHeight,images,TempRotation);
            case RuleType.count:
                return compareCount(count,replaceValue,board,numberWidth,numberHeight,images,TempRotation);
        }
        return false;
    }

    private static bool compareCount(int count, int replaceValue, int[,] board,int numberWidth,int numberHeight,Image[,] images,Vector3 TempRotation)
    {
        int resultCount = 0;
        for(int i=0;i<numberWidth;i++){
            for(int j=0;j<numberHeight;j++){
                if(board[i, j] == replaceValue
                    && images[i, j].rectTransform.eulerAngles == TempRotation){
                    resultCount++;
                }
            }
        }
        print(resultCount+" Exp:"+count);
        return resultCount==count;
    }

    private static bool firstIsInSecond(int[,] hardcodeSpace, int[,] board,int numberWidth,int numberHeight,Image[,] images,Vector3 TempRotation)
    {
        // string sBoard = "/***B\n";
        // string sHSpace = "/***H\n";
        for(int i=0;i<numberWidth;i++){
            for(int j=0;j<numberHeight;j++){
                // sBoard+=""+board[i,j];
                // sHSpace+=""+hardcodeSpace[i,j];
                if(hardcodeSpace[i,j]!=0){
                    if(hardcodeSpace[i,j]!=board[i,j]||images[i, j].rectTransform.eulerAngles != TempRotation)
                        return false;
                }
            }
            // sBoard+="\n";
            // sHSpace+="\n";
        }
        // print(sBoard);
        // print(sHSpace);
        print("match");
        return true;
    }

    public void intialize()
    {
        numberWidth = (int)(ScreenMatrix.me.SourceRoom.rectTransform.sizeDelta.x/ScreenMatrix.highlightImage.rect.width);
        numberHeight = (int)(ScreenMatrix.me.SourceRoom.rectTransform.sizeDelta.y/ScreenMatrix.highlightImage.rect.height);
        joinSprites();
        hardcodeSpace = new int[numberWidth,numberHeight];
        switch(type){
            case RuleType.hardcoded:
                parseHardcodeSpace();
                break;
            case RuleType.hardcodeSubstitution:
                parseSubHardcodeSpace();
                break;
        }
    }

    private void parseSubHardcodeSpace()
    {
        for(int i=0;i<resultSet.Length;i++){
            string s = resultSet[i];
            if(s.Length==0)continue;
            for(int j=0;j<s.Length;j++){
                if(s[j].Equals('1'))
                    hardcodeSpace[j,i]=replaceValue;
                else 
                    hardcodeSpace[j,i]=0;       
            }
        }
    }

    private void parseHardcodeSpace()
    {
        for(int i=0;i<resultSet.Length;i++){
            string s = resultSet[i];
            for(int j=0;j<s.Length;j++){
                hardcodeSpace[i,j]=int.Parse(""+s[j]);
            }
        }
    }

    void Update(){
        //  if(Input.GetKeyDown(KeyCode.Space)){
        //     string test ="";
        //     test+="/************************\n";
        //     for (int j = 0; j < numberHeight; j++)
        //     {
        //         for (int i = 0;i < numberWidth; i++)
        //         {
        //             test+=hardcodeSpace[i,j];
        //         }
        //         test+="\n";
        //     }
        //     print(test);
        // }
    }
    public Sprite jointSprite;
    [SerializeField]
    public RuleType type = RuleType.hardcoded;
    [SerializeField]
    public string[] resultSet;
    [SerializeField]
    public Sprite[] images;
    private int numberWidth;
    private int numberHeight;
    private int[,] hardcodeSpace;

    public void joinSprites(){
        Texture2D mainTex=new Texture2D(660,600);
        for(int x = 0; x < mainTex.width; x++)
        {
            for(int y = 0; y < mainTex.height; y++)
            {
                mainTex.SetPixel(x,y,Color.white);
            }
        }
        foreach(Sprite s in images){
            for(int x = 0; x < s.rect.width; x++)
             {
                   for(int y = 0; y < s.rect.height; y++)
                   {
                        Color c =s.texture.GetPixel(x,y);
                        if(c.a>0)
                            mainTex.SetPixel(x,y,c);
                   }
             }
        }
        
        mainTex.Apply();
        jointSprite = Sprite.Create(mainTex, new Rect(0,0,mainTex.width,mainTex.height), Vector2.zero);
    }
}
public enum RuleType{
    hardcoded,
    count,
    hardcodeSubstitution
}