using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/New Character")]
public class SOCharacter : ScriptableObject
{
  public GameObject Prefab;
  public int Building;
  public int OffsetX;
  public int OffsetY;
  public bool IsPlayer;
}
