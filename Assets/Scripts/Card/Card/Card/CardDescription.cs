using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardDescription
{
    protected string comment;
    
    public abstract string GetDescription();
}

public class BattleCardDescription : CardDescription
{
    public BattleCardDescription(BattleCardData data) {
        comment = "~ ī�� ���� ~";
    }

    public override string GetDescription() {
        return comment;
    }
}
