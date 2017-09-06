using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {


    private void Update()
    {
        move_controller();
        attack_controller();
    }

    void move_controller()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = (transform.forward * z) + (transform.right * x);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mov_run(dir);
        }else
        {
            mov_walk(dir);
        }
    }
    void attack_controller()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hand.playAction1();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                hand.playAction2();
            }
        }
    }
   
}
