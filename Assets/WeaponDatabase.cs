using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Weapons/WeaponDatabase")]

public class WeaponDatabase : ScriptableObject
{
    public List<WeaponType> weapons = new List<WeaponType>();
}
