using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int weaponSwitch = 0;

    //Start is called before the first frame update
    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int currenWeapon = weaponSwitch;
        if (Input.GetKeyDown(KeyCode.Alpha1))
         {
            if (weaponSwitch == transform.childCount - 1)
            {
                weaponSwitch = 0;
            }
            else
                weaponSwitch++;
         }
        if (currenWeapon != weaponSwitch)
        {
            selectWeapon();
        }

    }

    void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSwitch)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;


        }

    }
}
