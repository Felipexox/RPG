using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
 
    private UtilsCamera cam;
    protected override void Start()
    {
        base.Start();
        Cursor.visible = false;
        if(cam == null)
        {
            cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<UtilsCamera>();
        }
    }
    private void Update()
    {
        move_controller();
        attack_controller();

    }
    private void FixedUpdate()
    {
        rotation_controller();
    }
    void move_controller()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //  Vector3 cameraDir = cam.getDir().normalized;

        //   Vector3 dir = (cameraDir * z) + (transform.right * x);
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
    void rotation_controller()
    {
        Quaternion lookTo = Quaternion.LookRotation(cam.getDir());
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTo, 0.2f);
    }
   
}
