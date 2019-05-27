using System;
using UnityEngine;

public delegate void WeaponChangedEventHandler(PC.WEAPON_TYPE weapon);

[Serializable]
public class PC : BaseCharacter
{
  public enum SHOULDER_PAD
  {
    none = 0,
    SP01 = 1,
    SP02 = 2,
    SP03 = 3,
    SP04 = 4
  };

  public enum BODY_TYPE { normal = 1, BT01 = 2, BT02 = 3 };

  // Shoulder Pad
  [SerializeField]
  private SHOULDER_PAD selectedShoulderPad = SHOULDER_PAD.none;
  public SHOULDER_PAD SELECTED_SHOULDER_PAD
  {
    get { return this.selectedShoulderPad; }
    set { this.selectedShoulderPad = value; }
  }

  [SerializeField]
  private BODY_TYPE selectedBodyType = BODY_TYPE.normal;
  public BODY_TYPE SELECTED_BODY_TYPE
  {
    get { return this.selectedBodyType; }
    set { this.selectedBodyType = value; }
  }

  // Do we have a knee pad?
  private bool kneePad = false;
  public bool KNEE_PAD
  {
    get { return this.kneePad; }
    set { this.kneePad = value; }
  }

  // Do we have a leg plate?
  private bool legPlate = false;
  public bool LEG_PLATE
  {
    get { return this.legPlate; }
    set { this.legPlate = value; }
  }

  public enum WEAPON_TYPE
  {
    none = 0,
    axe1 = 1,
    axe2 = 2,
    club1 = 3,
    club2 = 4,
    falchion = 5,
    gladius = 6,
    mace = 7,
    maul = 8,
    scimitar = 9,
    spear = 10,
    sword1 = 11,
    sword2 = 12,
    sword3 = 13
  };

  // Store the selected weapon. In the future we might want to create a
  // event handler to raise an even when the weapon is being changed in the setter
  [SerializeField]
  private WEAPON_TYPE selectedWeapon = WEAPON_TYPE.none;
  public WEAPON_TYPE SELECTED_WEAPON
  {
    get { return this.selectedWeapon; }
    set
    {
      this.selectedWeapon = value;
    }
  }


  public enum HELMET_TYPE { none = 0, HL01 = 1, HL02 = 2, HL03 = 3, HL04 = 4 };

  // do we have any helmet? Which one is selected if any?
  [SerializeField]
  private HELMET_TYPE selectedHelmet = HELMET_TYPE.none;
  public HELMET_TYPE SELECTED_HELMET
  {
    get { return this.selectedHelmet; }
    set { this.selectedHelmet = value; }
  }

  public enum SHIELD_TYPE { none = 0, SL01 = 1, SL02 = 2 };

  // Do we have a shield on? Which shiled is active?
  [SerializeField]
  private SHIELD_TYPE selectedShield = SHIELD_TYPE.none;
  public SHIELD_TYPE SELECTED_SHIELD
  {
    get { return this.selectedShield; }
    set { this.selectedShield = value; }
  }

  public int SKIN_ID = 1;

  public enum BOOT_TYPE { none = 0, BT01 = 1, BT02 = 2 };

  [SerializeField]
  private BOOT_TYPE selectedBoot = BOOT_TYPE.none;
  public BOOT_TYPE SELECTED_BOOT
  {
    get { return this.selectedBoot; }
    set { this.selectedBoot = value; }
  }

  [SerializeField]
  private InventoryItem selectedArmour;
  public InventoryItem SELECTED_ARMOUR
  {
    get { return this.selectedArmour; }
    set { this.selectedArmour = value; }
  }
}
