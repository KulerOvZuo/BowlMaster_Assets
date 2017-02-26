using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {	

    private List<int> rolls = new List<int> ();

    private PinSetter pinSetter;
    private ScoreDisplay scoreDisplay;
    private Ball ball;
    // Use this for self-initialization
	void Awake() {
	
	}
	
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
    public void Bowl (int pinFall){
        try{
            rolls.Add(pinFall);
            ActionMaster.Action action = ActionMaster.NextAction(rolls);
            pinSetter.PerformAction(action);
            try{
                
                scoreDisplay.FillRolls(rolls);
                scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
            } catch {
                Debug.LogWarning("Wrong roll card - FillRollCard fail");
            }
            ball.Reinstantiate();
       } catch { Debug.LogWarning("Something went wrong in Bowl()");}
    }
    public void Ball_isLaunched(bool state){
        ball.isLaunched = state;
    }
}
