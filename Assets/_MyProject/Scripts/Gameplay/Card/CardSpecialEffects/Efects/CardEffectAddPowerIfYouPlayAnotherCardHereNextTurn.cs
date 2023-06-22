using UnityEngine;

public class CardEffectAddPowerIfYouPlayAnotherCardHereNextTurn : CardEffectBase
{
    [SerializeField] int PowerToAdd;
    [SerializeField] Color colorEffect;

    bool shoudlDestroy = false;


    public override void Subscribe()
    {
        GameplayManager.Instance.HighlihtWholeLocation(cardObject.LaneLocation, cardObject.IsMy, colorEffect);
        GameplayManager.UpdatedGameState += SubscribeForEventsOnNextRound;
    }

    void SubscribeForEventsOnNextRound()
    {
        switch (GameplayManager.Instance.GameplayState)
        {
            case GameplayState.ResolvingBeginingOfRound:
                if (shoudlDestroy)
                {
                    GameplayManager.UpdatedGameState -= SubscribeForEventsOnNextRound;
                    TableHandler.OnRevealdCard -= CheckPlayedCard;
                    GameplayManager.Instance.HideHighlihtWholeLocation(cardObject.LaneLocation, cardObject.IsMy, colorEffect);
                    Destroy(gameObject);
                }
                else
                {
                    TableHandler.OnRevealdCard += CheckPlayedCard;
                    shoudlDestroy = true;
                }
                break;
            default:
                break;
        }
    }

    private void CheckPlayedCard(CardObject _cardObject)
    {
        if (_cardObject.IsMy != cardObject.IsMy)
        {
            return;
        }
        if (_cardObject.LaneLocation == cardObject.LaneLocation)
        {
            for (int i = 0; i < GameplayManager.Instance.Lanes[(int)_cardObject.LaneLocation].LaneSpecifics.AmountOfRevealEffects; i++)
            {
                cardObject.Stats.Power += PowerToAdd;
            }
            TableHandler.OnRevealdCard -= CheckPlayedCard;
        }
    }
}
