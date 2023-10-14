using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Attribute
{
    Ancient,
    Terror,
    Exile,
    Death,
    Cursed,
    Blood,
    Frore,
    Elysium,
    Fever,
    Primeval,
    Regime,
    Saevusfort
}

struct EffectTypes
{
    public const string DestroyEffect = "Destroy Creatures";
    public const string GraveyardEffect = "Graveyard Summon";
    public const string PermanentBuffEffect = "Permanent Buff";
}

[Serializable]
public class Card : Interactable
{
    public Sprite cardSprite;
    //public Race race;
    public string associatedCamp;
    public int killPoints;
    public int soulPoints;
    public string fieldEffect;
    public string sacrificeEffect;
    public Attribute attribute1, attribute2, attribute3;
    public int player;
    public int bonus;
    public string effect;
    public bool usedEffect;


    public Card(CardData _card)
    {
        this.cardSprite = _card.cardSprite;
        //this.race = _card.raceCard;
        this.associatedCamp = _card.associatedCamp;
        this.killPoints = _card.killPoints;
        this.soulPoints = _card.soulPoints;
        this.fieldEffect = _card.fieldEffect;
        this.effect = _card.effect;
        this.sacrificeEffect = _card.sacrificeEffect;
        this.attribute1 = _card.attribute1;
        this.attribute2 = _card.attribute2;
        this.attribute3 = _card.attribute3;
    }

    public int Player => player;
}