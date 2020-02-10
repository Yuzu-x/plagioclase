using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName ="PowerUp")]
public class PowerUpBase : ScriptableObject
{
    public float healthEffect;
    public float boostEffect;
    public Sprite powerUpSprite;
    public GameObject pUGameObject;
    public SpriteRenderer pUFace;
}
