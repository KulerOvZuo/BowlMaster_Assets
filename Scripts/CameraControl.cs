using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {	

    private GameObject ball;

    private Vector3 offset;
    // Use this for self-initialization
	void Awake() {
	
	}
	
	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
        offset = gameObject.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float zValue = ball.transform.position.z + offset.z;
        if(zValue < 1700)
        {   transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x,-40,40),transform.position.y, zValue);
            }	
	}
}
