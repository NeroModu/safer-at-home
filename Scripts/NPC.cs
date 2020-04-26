using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class NPC : Human {
//    // NPC traits
//    private bool isHome = true;
//    public Vector3 target = new Vector3(-1, -1, -1);

//    // Move player one coordinate towards target
//    void move(position pos) {
        
//        float currentX = this.transform.position.x;
//        float currentZ = this.transform.position.z;
//        float targetX = pos.x;
//        float targetZ = pos.z;

//        // work in progress...

//    }

//    // Update is called once per frame
//    void Update() {
//        base.Update(); // Do human things

//        if (isHome) { // Case 1. NPC is currently at home
//            if (this.getCash() > 300) { // Only leave the house if npc can afford it

//                if (this.getHealth() < 40) { // If health gets critical, go to hospital

//                    isHome = false; // NPC is no longer home
//                    target = hospital.transform.position; // Set target to go to hospital

//                }

//                else if (this.getHunger() < 60) { // If hunger gets low, go to grocery store

//                    isHome = false; // NPC is no longer home
//                    target = grocery_store.transform.position; // Set target to go to grocery store

//                }

//            }
//        }

//        else {

//            if (target == null) { // Case 2. NPC is at hospital or grocery store

//                if (this.getHealth() >= 100 || this.getHunger() >= 100) { // If player is done healing / eating

//                    target = houses[this.getHouseID()].transform.position; // Set target to go home (ASSUMES HOUSES ARRAY IS JUST NAMED 'HOUSES')
//                    return;

//                }

//            }

//            else { // Case 3. NPC is mid route
//               //check for collision with either hospital or grocery store
//                if (true) {
//                    target = null;
//                }
//                //check for collision with home
//                if (true) {
//                    target = null;
//                    isHome = true;
//                }

//                else {
//                    this.move(target); // inch NPC a tiny bit closer towards target
//                }

//            }

//        }

        

//    }

//    //Collision Code
//    private void OnCollisionEnter(Collision collision)
//    {
        
//    }
//}