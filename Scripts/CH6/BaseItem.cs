﻿using System;
using UnityEngine;
using System.Collections;


[Serializable]
public class BaseItem
{
  public enum ItemCatrgory
  {
    WEAPON = 0,
    ARMOUR = 1,
    CLOTHING = 2,
    HEALTH = 3,
    POTION = 4
  }

  [SerializeField]
  private string name;
  [SerializeField]
  private string description;

  public string NAME
  {
    get { return this.name; }
    set { this.name = value; }
  }

  public string DESCRIPTION
  {
    get { return this.description; }
    set { this.description = value; }
  }

}
