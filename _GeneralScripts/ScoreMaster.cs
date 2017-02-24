using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {	

    public static List<int> ScoreCumulative(List<int> rolls){
        List<int> cumulativeScore = new List<int> ();

        int runningTotal = 0;
        foreach(int frameScore in ScoreFrames(rolls)){
            runningTotal += frameScore;
            cumulativeScore.Add(runningTotal);
        }
        return cumulativeScore;
    }
    public static List<int> ScoreFrames(List<int> rolls){
        List<int> frameList = new List<int>();

        int length = rolls.Count;
        int[] frameArray = rolls.ToArray();
        for(int i=0; i<length; i++){
            if(frameList.Count == 10) //end
                break;
            int value = frameArray[i];
            if(value == 10){//strike - search next 2
                if(i+2 < length){
                    value += frameArray[i+1] + frameArray[i+2];
                    frameList.Add(value);
                }
                //no i++ - next empty
            } else { 
                if(i+1 < length){ //second in frame exists
                    value += frameArray[i+1];
                    if(value < 10){//not spare - end
                        frameList.Add(value);
                    }else{
                        if(i+2 < length){//spare - search next 1
                            value += frameArray[i+2];
                            frameList.Add(value);
                        }
                    }
                    i++;//move to next first roll in frame
                }
            }
        }               
        return frameList;
    }
}
