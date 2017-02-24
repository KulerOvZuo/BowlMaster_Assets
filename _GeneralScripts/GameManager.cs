using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {	

    private List<int> bowls = new List<int> ();

    private PinSetter pinSetter;
    private Ball ball;
    // Use this for self-initialization
	void Awake() {
	
	}
	
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}
	
    public void Bowl (int pinFall){
        bowls.Add(pinFall);

        ActionMaster.Action action = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(action);
        ball.Reinstantiate();
    }
    public void Ball_isLaunched(bool state){
        ball.isLaunched = state;
    }
}
