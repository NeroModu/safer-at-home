using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : Human {
    static int[][] map = new int[][] 
    {
	    new int[] {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1},
        new int[] {1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        new int[] {1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0},
        new int[] {1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        new int[] {1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        new int[] {1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        new int[] {1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1},
        new int[] {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1},
        new int[] {1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1},
        new int[] {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
        new int[] {1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
        new int[] {1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
        new int[] {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
        new int[] {1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1},
        new int[] {1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
        new int[] {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1},
        new int[] {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };

    GameObject hospital1, hospital2, grocery_store, home, work;

    // NPC traits

    //change back to false after testing
    private bool isHome = true;
    //change back to false after testing
    private bool isMoving = false;
    private bool isColliding = false;
    public coordinate target = new coordinate(2,2);
    public coordinate[] targetPath = {new coordinate(0, 0), new coordinate(0,1), new coordinate(1,1), new coordinate(2,1), new coordinate(2,2)};
    public coordinate currentGoal = null;
    public static int index = 0;

    // Get coordinate from transform.position
    public coordinate getCoord(Vector3 pos) {
        int rx = ((int) pos.x);
        int ry = ((int) pos.y);
        // int run = (rx - 5) / 10;
        // int rise = (ry - 195) / (-10);
        int run = (rx - 5) / 10;
        int rise = (ry - 5) / 10;

        return new coordinate(rise, run);
    }

    // Get vector3 (transform.position) from coordinate
    public Vector3 decodeCoord(coordinate coord) {
        int rise = coord.getX();
        int run = coord.getY();
        int x = 5 + (10 * run);
        int y = 195 - (10 * rise);

        return new Vector3(x, 1.4f, y);
    }

    // Move player towards target
    void move(coordinate newPos, coordinate[] pathToNewPos) {
        Debug.Log("Move");
        if (!isMoving) return;

        currentGoal = pathToNewPos[index];
        if(this.transform.position == decodeCoord(currentGoal)){

            //"popping" the first element in the array. creates a new array without the first element 

            currentGoal = pathToNewPos[index+1];

            
            index++;
        }
        float step = base.speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, decodeCoord(currentGoal), step);
    }

    // Set new target for player
    void setTarget(coordinate tget) {
        
        Debug.Log("Now going to: X= " + tget.getX()+ " Y= " + tget.getY());

        int startX = getCoord(this.transform.position).getX();
        int startY = getCoord(this.transform.position).getY();
        Debug.Log(startX + " / " + startY);
        int endX = tget.getX();
        int endY = tget.getY();
        
        int[] start	= new int[2] {startY, startX};
        int[] end	= new int[2] {endY, endX};
        List<Vector2> path = new Pathfinder(map, start, end, "").result;

        List<coordinate> coords = new List<coordinate>();
        foreach (Vector2 vec in path) {
            Debug.Log(vec.x + " " + vec.y);
            coords.Add(new coordinate((int)vec.y, (int)vec.x));
        }

        index = 0;
        targetPath = coords.ToArray();
    }
    
    new void Start() {
        
        hospital1 = GameObject.Find("hospital1");
        hospital2 = GameObject.Find("hospital2");
        grocery_store = GameObject.Find("Grocery Store");
        work = GameObject.Find("Family Grocery Store");
        home = GameManager.instance.house[getHouseID()];

        base.Start();
        //randomly infect
        infect();
    }

    // Update is called once per frame
    new void Update() {
        base.Update(); // Do human things
        Debug.Log("updating");
        if (isHome) { // Case 1. NPC is currently at home
            Debug.Log("Home");
            if (getCash() > 300) { // Only leave the house if npc can afford it
                Debug.Log("cash gang");
                if (getImmuneSystem() < 40) { // If health gets critical, go to hospital
                    Debug.Log("Immune'nt");
                    isHome = false; // NPC is no longer home
                    isMoving = true;

                    // Set target to go to random hospital
                    if (Random.Range(0, 10) >= 5) target = getCoord(hospital1.transform.position);
                    else target = getCoord(hospital2.transform.position);
                    

                    setTarget(target);
                    

                }

                else if (getHunger() < 60) { // If hunger gets low, go to grocery store
                    Debug.Log("Foodn't");
                    isHome = false; // NPC is no longer home
                    isMoving = true;
                    Debug.Log("calling store");
                    target = getCoord(grocery_store.transform.position); // Set target to go to grocery store
                    //target = new coordinate(0, 14);

                    setTarget(target);

                    // targetPath = Pathfinder.aStar(getCoord(this.transform.position), target);
                    // Debug.Log(targetPath);

                }


            }
        }

        else {

            isMoving = true;

            if (!isMoving) { // Case 2. NPC is at hospital or grocery store

                if (getImmuneSystem() >= 100 || getHunger() >= 100) { // If player is done healing / eating
                    Debug.Log("Not Moving");
                    target = getCoord(home.transform.position); // Set target to go home
                    setTarget(target);
                    isMoving = true;
                    return;

                }
                
                

            }

            else this.move(target, targetPath); // Case 3. NPC is mid route. Inch NPC a tiny bit closer towards target

            

        }
         

    }

    private void OnCollisionEnter(Collision other) {

        if (!isHome && isMoving) { // Case 3. NPC is mid route

            //check for collision with either hospital or grocery store
            if (other.gameObject.name == ("hospital1") || other.gameObject.name == ("hospital2") || other.gameObject.name == ("Grocery Store") || other.gameObject.name == ("Family Grocery Store")) {
                // target = getCoord(home.transform.position);
                // setTarget(target);
                // isMoving = true;
                isMoving = false;
                Debug.Log("touch");

                if (Random.Range(0, 10) >= 7) {
                    if (Random.Range(0, 10) >= 5) {
                        target = getCoord(hospital1.transform.position);
                    }

                    else target = getCoord(hospital2.transform.position);
                }

                else {
                    
                    if (Random.Range(0, 10) >= 5) {
                        target = getCoord(grocery_store.transform.position);
                    }

                    else target = getCoord(work.transform.position);

                }

                setTarget(target);
                isMoving = false;
            }

            //check for collision with home
            // if (other.gameObject.name == ("house" + getHouseID().ToString())) {

            //     if (Random.Range(0, 10) >= 7) {
            //         if (Random.Range(0, 10) >= 5) {
            //             target = getCoord(hospital1.transform.position);
            //         }

            //         else target = getCoord(hospital2.transform.position);
            //     }

            //     else {
                    
            //         if (Random.Range(0, 10) >= 5) {
            //             target = getCoord(grocery_store.transform.position);
            //         }

            //         else target = getCoord(work.transform.position);

            //     }

            //     setTarget(target);
            //     isMoving = true;
            //     isHome = true;
            // }

        }
    }


}

public class coordinate {
    int x, y;

    public coordinate(int x1, int y1) {
        x = x1;
        y = y1;
    }

    public int getX() { return x; }
    public int getY() { return y; }

    public bool isEq(coordinate c) {
        if (c.getX() == x && c.getY() == y) return true;
        else return false;
    }

}

/*

    JUNCTION ID CHART (DEFUNCT)

    "Junction1" = ╋     "Junction6" = ┗

    "Junction2" = ┳     "Junction7" = ┏

    "Junction3" = ┣     "Junction8" = ┛

    "Junction4" = ┻     "Junction9" = ┓

    "Junction5" = ┫

    */
