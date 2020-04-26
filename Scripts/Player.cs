using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update(); //Updates() from Human class
        //Check if player has died
        if (is_dead())
        {
            gm.deathPanel.SetActive(true);
        }
    }
}
