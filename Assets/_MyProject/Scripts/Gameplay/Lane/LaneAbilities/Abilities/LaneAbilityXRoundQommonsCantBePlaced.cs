using System.Collections.Generic;
using UnityEngine;

public class LaneAbilityXRoundQommonsCantBePlaced : LaneAbilityBase
{
    [SerializeField] List<int> rounds;

    public override void Subscribe()
    {
        foreach (var _round in rounds)
        {
            laneDisplay.LaneSpecifics.CantPlaceCommonsOnRound.Add(_round);
        }
    }
}