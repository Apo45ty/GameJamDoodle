using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeResult : MonoBehaviour
{
    public static InitializeResult me;
    [SerializeField]
    private randomLevel1Architive level1Rulz;
    [SerializeField]
    private randomLevel2Architive level2Rulz;

    void Start()
    {
        me = this;
        InitializeResults();
    }

    public void InitializeResults()
    {
        rules = new ResultRule[3];
        rules[0] = level1Rulz.generateLevel1Rule();
        int RuleLevel2MaxNumber1 = Random.Range(1, 8);
        int RuleLevel2MaxNumber2 = 9 - RuleLevel2MaxNumber1;
        int[] noNotInclude1={
            rules[0].replaceValue-1
        };
        rules[1] = level2Rulz.generateLevel2Rule(RuleLevel2MaxNumber1,noNotInclude1);
        int[] noNotInclude2={
            rules[0].replaceValue-1,
            rules[1].replaceValue-1
        };
        rules[2] = level2Rulz.generateLevel2Rule(RuleLevel2MaxNumber2,noNotInclude2);
    }
    public void clearResults(){
        foreach(ResultRule r in rules){
            Destroy(r.gameObject);
        }
    }
    [SerializeField]
    public ResultRule[] rules;
    public int rulesIndex = 0;

    public void nextImage(){
        rulesIndex=Mathf.Min(++rulesIndex,rules.Length-1);
        RefreshImage();
     }
    public void prevImage(){
        rulesIndex=Mathf.Max(--rulesIndex,0);
        RefreshImage();
    }
    public void RefreshImage(){
        GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().currentDoodleSprite=rules.Length>0?rules[rulesIndex].jointSprite:null;
        ButtonEnableDisable.me.updateImage();
    }   
    public bool Solve(Image[,] images,int[,] board){
        foreach(ResultRule r in rules){
            if(!r.solve(images,board))return false;
        }
        return true;
    }
    
}