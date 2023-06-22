using System.Collections.Generic;
using UnityEngine;

public class CardEffectAddPowerIfOpponentPlayedOnSameLocation : CardEffectBase
{
    [SerializeField] int powerToAdd;

    public override void Subscribe()
    {
        CheckIfOpponentPlayedOnSameLocation();
        GameplayManager.UpdatedGameState += Destroy;
    }

    void Destroy()
    {
        switch (GameplayManager.Instance.GameplayState)
        {
            case GameplayState.ResolvingBeginingOfRound:
                GameplayManager.UpdatedGameState -= Destroy;
                Destroy(gameObject);
                break;
            case GameplayState.Playing:
                break;
            case GameplayState.Waiting:
                break;
            case GameplayState.ResolvingEndOfRound:
                break;
            default:
                break;
        }
    }

    private void CheckIfOpponentPlayedOnSameLocation()
    {
        List<PlaceCommand> _commandsThisRound = cardObject.IsMy ? GameplayManager.Instance.CommandsHandler.OpponentCommands : GameplayManager.Instance.CommandsHandler.MyCommands;

        foreach (var _command in _commandsThisRound)
        {
            if (_command.Card.LaneLocation == cardObject.LaneLocation)
            {
                for (int i = 0; i < GameplayManager.Instance.Lanes[(int)cardObject.LaneLocation].LaneSpecifics.AmountOfRevealEffects; i++)
                {
                    cardObject.Stats.Power += powerToAdd;
                }
                LanePlaceIdentifier _placeIdentifier = _command.Card.GetComponentInParent<LanePlaceIdentifier>();
                GameplayManager.Instance.FlashLocation(_placeIdentifier.Id, new Color(0, 0, 0, 0), 2);
                break;
            }
        }
    }
}
