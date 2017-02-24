using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;


[TestFixture]
public class ActionMaster_Test
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    private List<int> pinFalls;

    [SetUp]
    public void Setup(){
        pinFalls = new List<int>();
    }

    [Test]
    public void T00_PassingTest(){
        Assert.AreEqual(1,1);
    }
    [Test]
    public void T01_OneStrikeReturnsEndTurn(){
        pinFalls.Add(10);
        Assert.AreEqual(endTurn,ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T02_Bowl8ReturnsTidy(){
        pinFalls.Add(8);
        Assert.AreEqual(tidy,ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T03_Bowl82ReturnsEndTurn(){
        pinFalls.Add(8);
        pinFalls.Add(2);
        Assert.AreEqual(endTurn,ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T04_CheckResetAtStrikeAtLast(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10};
        //19th bowl
        Assert.AreEqual(reset,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T05_CheckResetAtSpareAtLast(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
        //20th bowl
        Assert.AreEqual(reset,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T06_CheckResetNotSpareAtLast(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,5};
        //20th bowl
        Assert.AreEqual(endGame,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T07_YouTubeRollsEndInEndGame(){
        int[] rolls = {8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2, 9};
        //21th bowl
        Assert.AreEqual(endGame,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T08_Daryl20bowltest(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5};
        //20th bowl
        Assert.AreEqual(tidy,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T08b_Daryl20bowltest(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0};
        //20th bowl
        Assert.AreEqual(tidy,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T09_19thBowlnotStrike(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 5};
        //19th
        Assert.AreEqual(tidy,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T10_StrikeAsSecond(){
        int[] rolls = {0,10,5, 1};
        //19th
        Assert.AreEqual(endTurn,ActionMaster.NextAction(rolls.ToList()));       
    }
    [Test]
    public void T11_Dondi10thFrameTurkey(){
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
        pinFalls = rolls.ToList();
        Assert.AreEqual(reset,ActionMaster.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(reset,ActionMaster.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(endGame,ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T12_01_GivesEndTurn(){
        int[] rolls = {0, 1};
        Assert.AreEqual(endTurn,ActionMaster.NextAction(rolls.ToList()));
    }

}
