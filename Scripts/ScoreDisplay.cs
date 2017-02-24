using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {	

    public Text[] rolls; //= new Text[21];
    public Text[] scores; //= new Text[10];
    // Use this for self-initialization
	void Awake() {
        foreach(Text t in rolls){
            t.text = "";
        }
        foreach(Text t in scores){
            t.text = "";
        }
	}
	
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void FillRollCard(List<int> rolls){
        rolls[-1] = 1;
    }
}
