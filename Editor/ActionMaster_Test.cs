using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[TestFixture]
public class ActionMaster_Test
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    [Test]
    public void T00_PassingTest(){
        Assert.AreEqual(1,1);
    }

    [Test]
    public void T01_OneStrikeReturnsEndTurn(){
        ActionMaster AC = new ActionMaster();
        Assert.AreEqual(endTurn,AC.Bowl(10));
    }
}
