using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //private Camera _cfirstCamera;
    public Camera m_MainCamera; //sets the first main camera
    public Camera m_CameraTwo; //sets the second camera

    SpriteRenderer myRenderer;
    public Color floorColor;
    public Color gateColor;

    Rigidbody2D myBody;

    public float power;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting");
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBody = gameObject.GetComponent<Rigidbody2D>();

        m_MainCamera = Camera.main; //grabs the main camera 
        m_MainCamera.enabled = true; //sets the main camera to true
        m_CameraTwo.enabled = false; //sets the second camera to false

        //lines 31-33: this was what I initially had to set the first and second cameras
        //_cfirstCamera = GameObject.Find("firstCamera").GetComponentInChildren<Camera>(); //pt. 1 -----------------
        //GetComponent<Camera>().enabled = false;
        //_cfirstCamera.enabled = true; // pt. 2-----------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            myBody.AddForce(new Vector3(1, 0, 0) * power);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "floor"){
            Debug.Log("Hit floor");
        }

        if(other.gameObject.name == "hit domino"){ //if the ball hits the first domino,
            if(m_MainCamera.enabled){ //and as long as the first camera is enabled,
                m_CameraTwo.enabled = true; //the second camera is enabled, and
                m_MainCamera.enabled = false; //the first camera is disabled.
            }
        }
        //lines 61 - 66: this was a much more complicated way of doing the above
        //if(other.gameObject.name == "hit domino"){
        //    Debug.Log("hit the domino");
        //    _cfirstCamera.enabled = false;
        //    GetComponent<Camera>().enabled = true;
        //    Debug.Log("you hit the domino. huzzah"); //
        //}    
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