using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    public float timeoutSeconds=30;
    private float timeout=0;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeout+=Time.deltaTime;
        text.text=""+(timeoutSeconds-timeout);
        if(timeout>=timeoutSeconds){
            timeout=0;
            bool won=WinAndResetScript.me.CheckIfVitory();
            if (won)
            {
                WinAndResetScript.me.win();
                WinAndResetScript.me.reset();
            } else {
                WinAndResetScript.me.lose();
                WinAndResetScript.me.reset();
            }
        }
    }
}
