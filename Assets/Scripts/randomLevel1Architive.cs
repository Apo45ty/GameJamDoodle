using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class randomLevel1Architive : MonoBehaviour
{
    [SerializeField]
    public Sprite[] Dirrections;
    [SerializeField]
    public Sprite[] doodles;
    [SerializeField]
    public Sprite[] Rotations;
    [SerializeField]
    public resultSet[] resultSets;
    internal ResultRule generateLevel1Rule()
    {
        if(Dirrections.Length==0||doodles.Length==0||Rotations.Length==0)return null;
        GameObject gObj = new GameObject();
        ResultRule result = gObj.AddComponent<ResultRule>();
        int randomDoodleIndex = UnityEngine.Random.Range(0,doodles.Length);
        int randomDirrectionsIndex = UnityEngine.Random.Range(0,Dirrections.Length);
        int randomRotationssIndex = UnityEngine.Random.Range(0,Rotations.Length);
        Sprite[] sprites = new Sprite[3];
        sprites[0]=doodles[randomDoodleIndex];
        sprites[1]=Dirrections[randomDirrectionsIndex];
        sprites[2]=Rotations[randomRotationssIndex];
        result.images=sprites;
        result.resultSet=getResultStringFromImageName(Dirrections[randomDirrectionsIndex].name);
        result.replaceValue=randomDoodleIndex+1;
        result.type=RuleType.hardcodeSubstitution;
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

    private string[] getResultStringFromImageName(string name)
    {
        if(name==null)return  null;
        foreach(resultSet result in resultSets){
            if(result.name.Equals(name)){
                return result.results;
            }
        }
        return null;
    }
}
