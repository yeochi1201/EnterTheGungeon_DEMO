using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrankDT : ScriptableObject
{
    public int ItemNum = 40;
    public int WeaponNum = 28;
    // Start is called before the first frame update
    public enum ItemList
    {
        Meatbun,
        Bottle,
        Bomb,
        Ice_Bomb,
        Proximity_Mine,
        C4,
        Molotov,
        Supply_Drop,
        Ammo_Synthesizer,
        Backpack,
        Scope,
        Ammo_Belt,
        Bullet_Time,
        Decoy,
        Trusty_Lockpicks,
        Potion_of_Lead_Skin,
        Double_Vision,
        Posion_Vial,
        Potion_of_Gun_Friendship,
        Knife_Sheild,
        Grappling_Hook,
        Battery_Bullets,
        Lichy_Trigger_Finger,
        Enraging_Photo,
        Ring_of_Mimic_Friendship,
        Amulet_of_the_P4_Lord,
        Heavy_Boots,
        Springheel_Boots,
        Cigarettes,
        Map,
        Sense_of_Direction,
        Blast_Helmet,
        Lodestone_Ammolet,
        Table_Tech_Sight,
        Table_Tech_Money,
        Table_Tech_Rage,
        Ruby_Bracelet,
        Gas_Mask,
        Battle_Standard,
        Dog
    }
    public ItemList Item;
    public enum WeaponList
    {
        Casey,
        Pea_Shooter,
        Special38,
        Derringer,
        Unfinished_Gun,
        Makarov,
        Dueling_Pistol,
        Flare_Gun,
        Regular_Shotgun,
        Sawed_Off,
        Blunderbuss,
        Crossbow,
        Klobbe,
        Machine_Pistol,
        Plauge_Pistol,
        Winchester_Rifle,
        Alien_Sidearm,
        Flash_Ray,
        Wind_Up_Gun,
        Lil_Bomber,
        Phoenix,
        Snowballer,
        Fossilized_Gun,
        Mailbox,
        Nail_Gun,
        Lower_Case_r,
        T_Shirt_Cannon,
        Sling
    }
    public WeaponList weapon;
}
