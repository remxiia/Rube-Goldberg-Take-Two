using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBallBehavior : MonoBehaviour
{
    SpriteRenderer myRenderer;
    public Color floorColor;
    public Color gateColor;

    Rigidbody2D myBody;

    public float power;
    
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "floor"){
            //myRenderer.color = floorColor;
            Debug.Log("Hit floor");
        }
    }
    // when objects overlap vs. above when they collide
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "gate"){
            myRenderer.color = gateColor;
            Debug.Log("Hit gate, changed color");
        }
    }
}
