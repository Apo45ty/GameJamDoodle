using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursorImage : MonoBehaviour
{
    private RectTransform trans;

    void Start(){
        trans = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("CacheGO").GetComponent<CacheObjects>().selectedTile.transform.position;
    }
}
