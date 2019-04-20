using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject top;
    public GameObject bot;
    public GameObject line;
    public bool nextOb;
    public Vector2 vSpeed;
    public bool flgMove;
    public float speed;
    public float gatePositionMax;
    public float gatePositionMin;
    public float gatePosition;
    public float gateTall;
    // Start is called before the first frame update
    void Start()
    {
        gatePositionMax = 3.0f;
        gatePositionMin = 1.0f;

        speed = -4.0f;
        gateTall = 0.0f;
        gatePosition = 5 - Random.Range(gatePositionMax, gatePositionMin);
        vSpeed = new Vector2(speed, 0);
        flgMove = false;
        ChkStart();
        nextOb = false;

        SetGate();
    }

    // Update is called once per frame
    void Update()
    {
        NextInstance();
        
    }
    void NextInstance()
    {
        float x = GetComponent<Transform>().position.x;
        if(!nextOb && x < 0.0f)
        {
            nextOb = true;
            GameObject obj = Instantiate(obstaclePrefab) as GameObject;
            obj.GetComponent<Transform>().position = new Vector3(5.0f, 0.0f, 0.0f);
        }
    }
    void ChkStart()
    {

        ShowSlide();
    }

    void ShowSlide()
    {// 動き始める処理

        this.GetComponent<Rigidbody2D>().velocity = vSpeed;
    }

    void SetGate()
    {
        float a = 5.0f - gatePosition;
        float b = 5.0f - a - gateTall;
        Vector2 tv2 = top.GetComponent<SpriteRenderer>().size;
        tv2.y = a;
        Vector2 bv2 = top.GetComponent<SpriteRenderer>().size;
        bv2.y = b;
        Vector3 lv3 = line.GetComponent<Transform>().position;
        lv3.y = -2.0f + 1.45f * gatePosition ;
        top.GetComponent<SpriteRenderer>().size = tv2;
        bot.GetComponent<SpriteRenderer>().size = bv2;
        line.GetComponent<Transform>().position = lv3;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {// なんかぶつかった時の処理
        GameObject obj = collision.gameObject;
        switch (obj.name)
        {
            case "DeadLine": Destroy(this.gameObject); break;
        }
    }
}
