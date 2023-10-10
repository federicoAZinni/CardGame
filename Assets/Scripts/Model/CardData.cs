using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Cards",menuName ="card")]
public class CardData : ScriptableObject
{
    public Sprite cardSprite;
    //public Race raceCard;
    public string associatedCamp;
    public int killPoints;
    public int soulPoints;
    public string fieldEffect;
    public string sacrificeEffect;
    public Attribute attribute1, attribute2, attribute3;

}

