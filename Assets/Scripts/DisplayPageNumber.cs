using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPageNumber : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(text){
            text.text="Page "+(InitializeResult.me.rulesIndex+1)+" out of "+(InitializeResult.me.rules.Length);
        }
    }
}
