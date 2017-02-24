using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {	
    
    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];
    private int bowl = 1;

    private Action Bowl(int pins){
        if(pins<0 || pins>10) throw new UnityException ("Wrong number of pins");

        bowls[bowl-1] = pins;
        #region last cases
        if(bowl == 21) //last
            return Action.EndGame;
        if(bowl == 19){ 
            if(!Bowl21Awarded()){ //19 not strike
                bowl++;
                return Action.Tidy;
            } else { //19 strike
                bowl++;
                return Action.Reset;
            }
        }
        if(bowl == 20){
            if(!Bowl21Awarded()){ //19 + 20 <10
                return Action.EndGame;
            } else {
                if(bowls[19-1] == 10){ //was 10 pins
                    if(pins == 10){ //19 strike, 20 strike
                        bowl++;
                        return Action.Reset;
                    }
                    bowl++;
                    return Action.Tidy;
                }
                bowl++;
                return Action.Reset;
            }
        }
        #endregion
        if(bowl %2 == 0) { //end of frame 1-9
            bowl++;
            return Action.EndTurn;
        } else if(bowl %2 != 0){//if first bowl of frame 1-9
            if(pins == 10){ //strike
                bowl += 2;
                return Action.EndTurn;
            } else{
                bowl++;
                return Action.Tidy;
            }
        }        

        throw new UnityException ("Not sure what action to return!");
    }
    private bool Bowl21Awarded(){
        return ((bowls[19-1] + bowls[20-1]) >= 10);
    }

    public static Action NextAction (List<int> pinFalls){
        ActionMaster am = new ActionMaster();  
        Action currentAction = new Action();

        foreach(int pinFall in pinFalls){
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }
}
