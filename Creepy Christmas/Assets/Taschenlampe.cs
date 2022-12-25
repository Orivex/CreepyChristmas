using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taschenlampe : Item
{
    [SerializeField] Light flashlight;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEquiped == true)
            Use();
    }
    public override void Use()
    {
        base.Use();
        ToggleLight();
    }

    void ToggleLight()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
