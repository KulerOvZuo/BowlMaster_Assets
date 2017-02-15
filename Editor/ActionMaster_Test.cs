using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[TestFixture]
public class ActionMaster_Test
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    private ActionMaster AC;

    [SetUp]
    public void Setup(){
        AC = new ActionMaster();
    }

    [Test]
    public void T00_PassingTest(){
        Assert.AreEqual(1,1);
    }

    [Test]
    public void T01_OneStrikeReturnsEndTurn(){
        Assert.AreEqual(endTurn,AC.Bowl(10));
    }
    [Test]
    public void T02_Bowl8ReturnsTidy(){
        Assert.AreEqual(tidy,AC.Bowl(8));
    }
    [Test]
    public void T03_Bowl82ReturnsEndTurn(){
        AC.Bowl(8);
        Assert.AreEqual(endTurn,AC.Bowl(2));
    }
    [Test]
    public void T04_CheckResetAtStrikeAtLast(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        //19th bowl
        Assert.AreEqual(reset,AC.Bowl(10));       
    }
    [Test]
    public void T05_CheckResetAtSpareAtLast(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        AC.Bowl(1);
        //20th bowl
        Assert.AreEqual(reset,AC.Bowl(9));       
    }
    [Test]
    public void T06_CheckResetNotSpareAtLast(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        AC.Bowl(1);
        //20th bowl
        Assert.AreEqual(endGame,AC.Bowl(5));       
    }
    [Test]
    public void T07_YouTubeRollsEndInEndGame(){
        int[] rolls = {8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        //21th bowl
        Assert.AreEqual(endGame,AC.Bowl(9));       
    }
    [Test]
    public void T08_Daryl20bowltest(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        AC.Bowl(10);
        //20th bowl
        Assert.AreEqual(tidy,AC.Bowl(5));       
    }
    [Test]
    public void T08b_Daryl20bowltest(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        AC.Bowl(10);
        //20th bowl
        Assert.AreEqual(tidy,AC.Bowl(0));       
    }
    [Test]
    public void T09_19thBowlnotStrike(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        //19th
        Assert.AreEqual(tidy,AC.Bowl(5));       
    }
    [Test]
    public void T10_StrikeAsSecond(){
        int[] rolls = {0,10,5};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        //19th
        Assert.AreEqual(endTurn,AC.Bowl(1));       
    }
    [Test]
    public void T11_Dondi10thFrameTurkey(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        foreach(int roll in rolls){
            AC.Bowl(roll);
        }
        Assert.AreEqual(reset,AC.Bowl(10));
        Assert.AreEqual(reset,AC.Bowl(10));
        Assert.AreEqual(endGame,AC.Bowl(10));
    }

}
