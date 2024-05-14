using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Card")]
public class CardConfig : ScriptableObject
{
    // TODO use private set properties for public fields which are set in the inspector better
    // example. [field: SerializeField] public Sprite MoneyIcon { get; private set; }
    public Sprite logoSprite;
    public int activityPoints;
    public int currentAmount;
    public int maxAmount;
    public string cardTitle;
    public bool isClaimable;
}
