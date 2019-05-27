using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class CharacterCustomization : MonoBehaviour
{
  // reference to PC Game Object
  public GameObject PLAYER_CHARACTER;

  // variable used to hold the PC Customization
  public PC PC_CC;

  public Material[] PLAYER_SKIN;

  public GameObject CLOTH_01LOD0;
  public GameObject CLOTH_01LOD0_SKIN;
  public GameObject CLOTH_02LOD0;
  public GameObject CLOTH_02LOD0_SKIN;
  public GameObject CLOTH_03LOD0;
  public GameObject CLOTH_03LOD0_SKIN;
  public GameObject CLOTH_03LOD0_FAT;

  public GameObject BELT_LOD0;

  public GameObject SKN_LOD0;
  public GameObject FAT_LOD0;
  public GameObject RGL_LOD0;

  public GameObject HAIR_LOD0;

  public GameObject BOW_LOD0;

  // Head Equipment
  public GameObject GLADIATOR_01LOD0;
  public GameObject HELMET_01LOD0;
  public GameObject HELMET_02LOD0;
  public GameObject HELMET_03LOD0;
  public GameObject HELMET_04LOD0;

  // Shoulder Pad - Right Arm / Left Arm
  public GameObject SHOULDER_PAD_R_01LOD0;
  public GameObject SHOULDER_PAD_R_02LOD0;
  public GameObject SHOULDER_PAD_R_03LOD0;
  public GameObject SHOULDER_PAD_R_04LOD0;

  public GameObject SHOULDER_PAD_L_01LOD0;
  public GameObject SHOULDER_PAD_L_02LOD0;
  public GameObject SHOULDER_PAD_L_03LOD0;
  public GameObject SHOULDER_PAD_L_04LOD0;

  // Fore Arm - Right / Left Plates
  public GameObject ARM_PLATE_R_1LOD0;
  public GameObject ARM_PLATE_R_2LOD0;

  public GameObject ARM_PLATE_L_1LOD0;
  public GameObject ARM_PLATE_L_2LOD0;

  // Player Character Weapons
  public GameObject AXE_01LOD0;
  public GameObject AXE_02LOD0;
  public GameObject CLUB_01LOD0;
  public GameObject CLUB_02LOD0;
  public GameObject FALCHION_LOD0;
  public GameObject GLADIUS_LOD0;
  public GameObject MACE_LOD0;
  public GameObject MAUL_LOD0;
  public GameObject SCIMITAR_LOD0;
  public GameObject SPEAR_LOD0;
  public GameObject SWORD_BASTARD_LOD0;
  public GameObject SWORD_BOARD_01LOD0;
  public GameObject SWORD_SHORT_LOD0;

  // Player Character Defense Weapons
  public GameObject SHIELD_01LOD0;
  public GameObject SHIELD_02LOD0;

  public GameObject QUIVER_LOD0;
  public GameObject BOW_01_LOD0;

  // Player Character Calf - Right / Left
  public GameObject KNEE_PAD_R_LOD0;
  public GameObject LEG_PLATE_R_LOD0;

  public GameObject KNEE_PAD_L_LOD0;
  public GameObject LEG_PLATE_L_LOD0;

  public GameObject BOOT_01LOD0;
  public GameObject BOOT_02LOD0;

  // Use this for initialization
  void Start()
  {
    this.PC_CC = this.PLAYER_CHARACTER.GetComponent<PlayerAgent>().playerCharacterData;
  }

  public bool ROTATE_MODEL = false;
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyUp(KeyCode.R))
    {
      this.ROTATE_MODEL = !this.ROTATE_MODEL;
    }

    if (this.ROTATE_MODEL)
    {
      this.PLAYER_CHARACTER.transform.Rotate(new Vector3(0, 1, 0), 33.0f * Time.deltaTime);
    }

    if (Input.GetKeyUp(KeyCode.L))
    {

      Debug.Log(PlayerPrefs.GetString("NAME"));
    }

  }


  public void SetShoulderPad(Toggle id)
  {

    try
    {
      PC.SHOULDER_PAD name = (PC.SHOULDER_PAD)Enum.Parse(typeof(PC.SHOULDER_PAD), id.name, true);
      if(id.isOn)
      {
        this.PC_CC.SELECTED_SHOULDER_PAD = name;
        Debug.Log(string.Format("{0} was turned on", name));
      }
      else
      {
        this.PC_CC.SELECTED_SHOULDER_PAD = PC.SHOULDER_PAD.none;
        Debug.Log(string.Format("{0} was turned off", name));
      }
    }
    catch
    {
      // if the value passed is not in the enumeration set it to none
      this.PC_CC.SELECTED_SHOULDER_PAD = PC.SHOULDER_PAD.none;
      Debug.Log("Shoulder Pad Enumeration Not Found!");
    }

    switch (id.name)
    {
      case "SP01":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(id.isOn);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(id.isOn);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);

          break;
        }
      case "SP02":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(id.isOn);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(id.isOn);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);

          break;
        }
      case "SP03":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(id.isOn);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(id.isOn);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);

          break;
        }
      case "SP04":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(id.isOn);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(id.isOn);

          break;
        }
      default:
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetShoulderPad(PC.SHOULDER_PAD id)
  {
    switch (id.ToString())
    {
      case "SP01":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(true);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(true);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);

          break;
        }
      case "SP02":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(true);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(true);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);

          break;
        }
      case "SP03":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(true);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(true);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);

          break;
        }
      case "SP04":
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(true);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(true);

          break;
        }
      default:
        {
          this.SHOULDER_PAD_R_01LOD0.SetActive(false);
          this.SHOULDER_PAD_R_02LOD0.SetActive(false);
          this.SHOULDER_PAD_R_03LOD0.SetActive(false);
          this.SHOULDER_PAD_R_04LOD0.SetActive(false);

          this.SHOULDER_PAD_L_01LOD0.SetActive(false);
          this.SHOULDER_PAD_L_02LOD0.SetActive(false);
          this.SHOULDER_PAD_L_03LOD0.SetActive(false);
          this.SHOULDER_PAD_L_04LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetBodyType(Toggle id)
  {
    try
    {
      PC.BODY_TYPE name = (PC.BODY_TYPE)Enum.Parse(typeof(PC.BODY_TYPE), id.name, true);
      if(id.isOn)
      {
        this.PC_CC.SELECTED_BODY_TYPE = name;
        Debug.Log(string.Format("{0} was turned on", name));
      }
      else
      {
        this.PC_CC.SELECTED_BODY_TYPE = PC.BODY_TYPE.normal;
        Debug.Log(string.Format("{0} was turned off", name));
      }
    }
    catch
    {
      // if the value passed is not in the enumeration set it to none
      this.PC_CC.SELECTED_BODY_TYPE = PC.BODY_TYPE.normal;
      Debug.Log("Body Type Enumeration Not Found!");
    }

    switch (id.name)
    {
      case "BT01":
        {
          this.RGL_LOD0.SetActive(id.isOn);
          this.FAT_LOD0.SetActive(false);
          break;
        }
      case "BT02":
        {
          this.RGL_LOD0.SetActive(false);
          this.FAT_LOD0.SetActive(id.isOn);
          break;
        }
      default:
        {
          this.RGL_LOD0.SetActive(false);
          this.FAT_LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetBodyType(PC.BODY_TYPE id)
  {
    switch (id.ToString())
    {
      case "BT01":
        {
          this.RGL_LOD0.SetActive(true);
          this.FAT_LOD0.SetActive(false);
          break;
        }
      case "BT02":
        {
          this.RGL_LOD0.SetActive(false);
          this.FAT_LOD0.SetActive(true);
          break;
        }
      default:
        {
          this.RGL_LOD0.SetActive(false);
          this.FAT_LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetKneePad(Toggle id)
  {
    this.KNEE_PAD_R_LOD0.SetActive(id.isOn);
    this.KNEE_PAD_L_LOD0.SetActive(id.isOn);
  }

  public void SetLegPlate(Toggle id)
  {
    this.LEG_PLATE_R_LOD0.SetActive(id.isOn);
    this.LEG_PLATE_L_LOD0.SetActive(id.isOn);
  }

  public void SetWeaponType(Slider id)
  {
    try
    {
      PC.WEAPON_TYPE weapon = (PC.WEAPON_TYPE)System.Convert.ToInt32(id.value);

      this.PC_CC.SELECTED_WEAPON = weapon;
      Debug.Log(string.Format("Weapon selected: {0}", weapon.ToString()));
    }
    catch
    {
      this.PC_CC.SELECTED_WEAPON = PC.WEAPON_TYPE.none;
    }

    switch (System.Convert.ToInt32(id.value))
    {
      case 0:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 1:
        {
          this.AXE_01LOD0.SetActive(true);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 2:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(true);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 3:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(true);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 4:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(true);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 5:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(true);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 6:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(true);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 7:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(true);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 8:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(true);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 9:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(true);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 10:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(true);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 11:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(true);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 12:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(true);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 13:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(true);
          break;
        }

    }
  }

  public void SetWeaponType(PC.WEAPON_TYPE id)
  {
    switch (System.Convert.ToInt32(id))
    {
      case 0:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 1:
        {
          this.AXE_01LOD0.SetActive(true);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 2:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(true);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 3:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(true);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 4:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(true);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 5:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(true);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 6:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(true);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 7:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(true);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 8:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(true);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 9:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(true);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 10:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(true);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 11:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(true);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 12:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(true);
          this.SWORD_SHORT_LOD0.SetActive(false);
          break;
        }
      case 13:
        {
          this.AXE_01LOD0.SetActive(false);
          this.AXE_02LOD0.SetActive(false);
          this.CLUB_01LOD0.SetActive(false);
          this.CLUB_02LOD0.SetActive(false);
          this.FALCHION_LOD0.SetActive(false);
          this.GLADIUS_LOD0.SetActive(false);
          this.MACE_LOD0.SetActive(false);
          this.MAUL_LOD0.SetActive(false);
          this.SCIMITAR_LOD0.SetActive(false);
          this.SPEAR_LOD0.SetActive(false);
          this.SWORD_BASTARD_LOD0.SetActive(false);
          this.SWORD_BOARD_01LOD0.SetActive(false);
          this.SWORD_SHORT_LOD0.SetActive(true);
          break;
        }

    }
  }

  public void SetHelmetType(Toggle id)
  {
    try
    {
      PC.HELMET_TYPE name = (PC.HELMET_TYPE)Enum.Parse(typeof(PC.HELMET_TYPE), id.name, true);
      if (id.isOn)
      {
        this.PC_CC.SELECTED_HELMET = name;
        Debug.Log(string.Format("{0} was turned on", name));
      }
      else
      {
        this.PC_CC.SELECTED_HELMET = PC.HELMET_TYPE.none;
        Debug.Log(string.Format("{0} was turned off", name));
      }
    }
    catch
    {
      // if the value passed is not in the enumeration set it to none
      this.PC_CC.SELECTED_HELMET = PC.HELMET_TYPE.none;
      Debug.Log("Helmet Type Enumeration Not Found!");
    }

    switch (id.name)
    {
      case "HL01":
        {
          this.HELMET_01LOD0.SetActive(id.isOn);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
      case "HL02":
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(id.isOn);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
      case "HL03":
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(id.isOn);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
      case "HL04":
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(id.isOn);
          break;
        }
      default:
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetHelmetType(PC.HELMET_TYPE id)
  {
    switch (id.ToString())
    {
      case "HL01":
        {
          this.HELMET_01LOD0.SetActive(true);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
      case "HL02":
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(true);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
      case "HL03":
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(true);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
      case "HL04":
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(true);
          break;
        }
      default:
        {
          this.HELMET_01LOD0.SetActive(false);
          this.HELMET_02LOD0.SetActive(false);
          this.HELMET_03LOD0.SetActive(false);
          this.HELMET_04LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetShieldType(Toggle id)
  {
    try
    {
      PC.SHIELD_TYPE name = (PC.SHIELD_TYPE)Enum.Parse(typeof(PC.SHIELD_TYPE), id.name, true);
      if (id.isOn)
      {
        this.PC_CC.SELECTED_SHIELD = name;
        Debug.Log(string.Format("{0} was turned on", name));
      }
      else
      {
        this.PC_CC.SELECTED_SHIELD = PC.SHIELD_TYPE.none;
        Debug.Log(string.Format("{0} was turned off", name));
      }
    }
    catch
    {
      // if the value passed is not in the enumeration set it to none
      this.PC_CC.SELECTED_SHIELD = PC.SHIELD_TYPE.none;
      Debug.Log("Shield Type Enumeration Not Found!");
    }

    switch (id.name)
    {
      case "SL01":
        {
          this.SHIELD_01LOD0.SetActive(id.isOn);
          this.SHIELD_02LOD0.SetActive(false);
          break;
        }
      case "SL02":
        {
          this.SHIELD_01LOD0.SetActive(false);
          this.SHIELD_02LOD0.SetActive(id.isOn);
          break;
        }
      default:
        {
          this.SHIELD_01LOD0.SetActive(false);
          this.SHIELD_02LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetShieldType(PC.SHIELD_TYPE id)
  {
    switch (id.ToString())
    {
      case "SL01":
        {
          this.SHIELD_01LOD0.SetActive(true);
          this.SHIELD_02LOD0.SetActive(false);
          break;
        }
      case "SL02":
        {
          this.SHIELD_01LOD0.SetActive(false);
          this.SHIELD_02LOD0.SetActive(true);
          break;
        }
      default:
        {
          this.SHIELD_01LOD0.SetActive(false);
          this.SHIELD_02LOD0.SetActive(false);
          break;
        }
    }
  }

  public void SetSkinType(Slider id)
  {
    this.PC_CC.SKIN_ID = System.Convert.ToInt32(id.value);
    Debug.Log(string.Format("Skin ID is {0}", this.PC_CC.SKIN_ID));

    this.SKN_LOD0.GetComponent<Renderer>().material = this.PLAYER_SKIN[System.Convert.ToInt32(id.value)];
    this.FAT_LOD0.GetComponent<Renderer>().material = this.PLAYER_SKIN[System.Convert.ToInt32(id.value)];
    this.RGL_LOD0.GetComponent<Renderer>().material = this.PLAYER_SKIN[System.Convert.ToInt32(id.value)];
  }

  public void SetBootType(Toggle id)
  {
    try
    {
      PC.BOOT_TYPE name = (PC.BOOT_TYPE)Enum.Parse(typeof(PC.BOOT_TYPE), id.name, true);
      if (id.isOn)
      {
        this.PC_CC.SELECTED_BOOT = name;
        Debug.Log(string.Format("{0} was turned on", name));
      }
      else
      {
        this.PC_CC.SELECTED_BOOT = PC.BOOT_TYPE.none;
        Debug.Log(string.Format("{0} was turned off", name));
      }
    }
    catch
    {
      // if the value passed is not in the enumeration set it to none
      this.PC_CC.SELECTED_BOOT = PC.BOOT_TYPE.none;
      Debug.Log("Boot Type Enumeration Not Found!");
    }

    switch (id.name)
    {
      case "BT01":
        {
          this.BOOT_01LOD0.SetActive(id.isOn);
          this.BOOT_02LOD0.SetActive(false);
          break;
        }
      case "BT02":
        {
          this.BOOT_01LOD0.SetActive(false);
          this.BOOT_02LOD0.SetActive(id.isOn);
          break;
        }
      default:
        {
          this.BOOT_01LOD0.SetActive(false);
          this.BOOT_02LOD0.SetActive(false);
          break;
        }
    }
  }

}
