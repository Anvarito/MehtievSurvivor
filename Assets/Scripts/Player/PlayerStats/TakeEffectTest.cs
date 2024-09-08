using Items;
using UnityEngine;

public class TakeEffectTest : MonoBehaviour
{
    public Inventory inventory;
    public int Heal;
    public int Speed;
    public int Wisdom;
    public int Stregth;
    private void Awake()
    {
        inventory.OnItemClick += TakeEffect;
    }

    private void TakeEffect(ItemConfig item)
    {
        if(!item)
            return;
        
        int currentStat = 0;
        switch (item.itemType)
        {
            case EItemType.Wisdom:
                Wisdom += item.EffectAmount;
                currentStat = Wisdom;
                break;
            case EItemType.Speed:
                Speed += item.EffectAmount;
                currentStat = Speed;
                break;
            case EItemType.Strength:
                Stregth += item.EffectAmount;
                currentStat = Stregth;
                break;
            case EItemType.Heal:
                Heal += item.EffectAmount;
                currentStat = Heal;
                break;
        }

        Debug.LogFormat("Picked up a {0} it increased {1} by {2}, now it's {3}", item.Name,item.itemType.ToString(), item.EffectAmount,
            currentStat);
    }
}