using UnityEngine;

public class AddCardToHandOnRound : CardSpecialEffectBase
{
    [SerializeField] int round;
    public int Round => round;

    public override void Subscribe()
    {
        //nothing to do here :)
    }
}