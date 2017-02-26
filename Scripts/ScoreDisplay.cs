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
	
    
    public void FillRolls(List<int> rolls){
        string scoreString = FormatRolls(rolls);
        for(int i=0; i<scoreString.Length; i++){
            this.rolls[i].text = scoreString[i].ToString();
        }
    }
    public void FillFrames(List<int> frames){
        for(int i=0; i<frames.Count; i++){
            scores[i].text = frames[i].ToString();
        }
    }
    public static string FormatRolls(List<int> rolls){
        string output = "";
        for(int i=0; i<rolls.Count; i++){
            int val1 = rolls[i];
            if(val1 == 10){ //strike
                output += "X";
                if(output.Length<19)
                    output += " ";
            }
            else{
                output += ConvertIntToString(val1);
                if(i+1 < rolls.Count){
                    if(val1 + rolls[i+1] == 10){//spare
                        output += "/";
                        i++;
                    } else {
                        output += ConvertIntToString(rolls[i+1]);
                        i++;
                    }
                }
            }
        }
        return output;
    }
    private static string ConvertIntToString(int value){
        if(value == 0)
            return "-";
        else
            return value.ToString();
    }
}
