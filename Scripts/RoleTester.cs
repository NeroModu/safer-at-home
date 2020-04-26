using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleTester : MonoBehaviour
{
    Role a = Role.remote_worker;
    Role b = Role.essential_worker;
    // Start is called before the first frame update
    void Start()
    {
        print("a is b: " + RoleExt.isRole(a, b));
        print("a is rw: " + RoleExt.isRole(a, Role.remote_worker));
        print("b is ew: " + RoleExt.isRole(b, Role.essential_worker));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
