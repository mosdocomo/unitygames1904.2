using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daruma : MonoBehaviour
{
    public GameObject obj;
    bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        this.name = "Daruma";
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Jump();
            CtrlRotation();
        }
    }
    void Jump()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 200.0f));
    }
    void CtrlRotation()
    {
        float radius;
        Vector2 v = this.GetComponent<Rigidbody2D>().velocity;
        float vy = v.y;
        radius = (vy / 8.0f) * 85.0f;
        if (radius > 85.0f) radius = 85.0f;
        if (radius < -85.0f) radius = -85.0f;
        transform.localRotation = Quaternion.Euler(0.0f,0.0f, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Line")
        {
            alive = false;
            //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            obj.SetActive(true);
        }
    }
}
