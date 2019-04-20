using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    public GameManager GameManager;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector2 vSpeed;
    public bool flgMove;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.name = "block";
        startPosition = new Vector3(8.0f, -4.3f, 0.0f);
        endPosition = new Vector3(-8.0f, -4.3f, 0.0f);
        speed = -4.0f;
        vSpeed = new Vector2(speed, 0);
        flgMove = false;
        ChkStart();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void ChkStart()
    {

        ShowSlide();
    }

    void ShowSlide()
    {// 動き始める処理

        this.GetComponent<Rigidbody2D>().velocity = vSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {// なんかぶつかった時の処理
        GameObject obj = collision.gameObject;
        switch (obj.name)
        {
            case "Daruma"   : Destroy(obj); break;
            case "DeadLine" : SwapPosition(); break;
        }
    }
    void SwapPosition()
    {// 指定位置に移動
        this.GetComponent<Transform>().position = startPosition;
    }
}
