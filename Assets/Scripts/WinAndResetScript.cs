using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndResetScript : MonoBehaviour
{
    public static WinAndResetScript me;

    void Start(){
        me=this;
    }
    public void OnSubmitScreen()
    {
        bool won = CheckIfVitory(); 
        if (won)
        {
            win();
            reset();
        }
    }

    public void win()
    {
        print("You Won!");
        SceneManager.LoadScene("won");
    }
     public void lose()
    {
        print("You Lost!");
    }

    public  bool CheckIfVitory()
    {
        return InitializeResult.me.Solve(ScreenMatrix.me.images, ScreenMatrix.me.spaces);
    }

    public void reset(){
        ScreenMatrix.me.clearMatrix();
        ScreenMatrix.me.InitializeMatrix();
        InitializeResult.me.clearResults();
        InitializeResult.me.InitializeResults();
    }
}
