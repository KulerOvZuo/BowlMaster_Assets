using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {	

    private Ball ball;
    private Vector3 startPos;
    private float startTime;
    // Use this for self-initialization
	void Awake() {
        ball = GetComponent<Ball>();
	}
	
    public void DragStart(){
        startPos = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd(){
        Vector3 launchVector = (Input.mousePosition - startPos);
        float timeDiff = Time.time - startTime;
        launchVector /= timeDiff;
        launchVector = new Vector3(Mathf.Clamp(launchVector.x/5f,-100f,100f),0,Mathf.Clamp(launchVector.y,0f,800f));
        ball.Launch(launchVector);
    }
}
