using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class randomLevel2Architive : MonoBehaviour
{
   [SerializeField]
   private Sprite[] Number;
   [SerializeField]
   private Sprite[] doodles;
   
    [SerializeField]
    public Sprite[] Rotations;

    internal ResultRule generateLevel2Rule(int ruleLevel2MaxNumber1,int[] doNotInclude)
    {
        if(Number.Length==0||doodles.Length==0||Rotations.Length==0)return null;
        GameObject gObj = new GameObject();
        ResultRule result = gObj.AddComponent<ResultRule>();
        int randomDoodleIndex = 0;
        bool done = false;
        while(!done){
            randomDoodleIndex = UnityEngine.Random.Range(0,doodles.Length);
            done=true;
            foreach(int i in doNotInclude){
                if(i==randomDoodleIndex){
                    done = false;
                    break;
                }
            }
        }
        int randomNumberIndex = ruleLevel2MaxNumber1-1;
        int randomRotationssIndex = UnityEngine.Random.Range(0,Rotations.Length);
        Sprite[] sprites = new Sprite[3];
        sprites[0]=doodles[randomDoodleIndex];
        sprites[1]=Number[randomNumberIndex];
        sprites[2]=Rotations[randomRotationssIndex];
        result.images=sprites;
        result.count=ruleLevel2MaxNumber1;
        result.replaceValue=randomDoodleIndex+1;
        result.type=RuleType.count;
        switch(randomRotationssIndex){
            case 0:
                result.TempRotation=new Vector3(0,0,180);
            break;
            case 1:
                result.TempRotation=new Vector3(0,0,90);
            break;
            case 2:
                result.TempRotation=new Vector3(0,0,270);
            break;
            case 3:
                result.TempRotation=new Vector3(0,0,0);
            break;
        }
        result.intialize();
        return result;
    }
}
