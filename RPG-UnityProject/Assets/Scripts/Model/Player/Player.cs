using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {


    private void Update()
    {
        move_controller();
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
   
}
