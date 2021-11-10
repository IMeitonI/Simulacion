using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTween : MonoBehaviour {
    [SerializeField] [Range(0, 1)] float t;
    [SerializeField] float time;
    [SerializeField] Transform target;
    float accu;
    bool isPlaying;
    Vector2 startPos;
    Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) MyStart();
        if (!isPlaying) return;
        if(t>= 1) {
            isPlaying = true;
            return;
        }
        t = accu / time;
        transform.position = Vector2.Lerp(startPos, endPos, t);
        accu += Time.deltaTime;
    }
    void MyStart() {
        startPos = transform.position;
        endPos = target.position;
        accu =0;
        t = 0;
        isPlaying = true;
    }
}
