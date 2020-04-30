using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Role {
    essential_worker,
    remote_worker
};

//extension functions
public static class RoleExt {
    public static bool isRole(Role a, Role b) {
        if((int)a == (int)b) //comapres int value of each enum
        {
            return true;
        }
        return false;
    }
}

public class Human : MonoBehaviour
{
    //reference to GameManager
    public GameManager gm;
    private RigidbodyConstraints originalConstraints;
    //Human traits
    public float speed = 14;
    private float hunger = 100;
    private float immune_system = 100;
    private bool is_infected = false;
    private bool virus_test = false;
    private float cash = 1200;
    private float income = 0;
    private int house_id = 0;
    private float time_to_pay;
    public Role role;
    private string placeOfWork = "";
    private bool canWork = false;
    private bool isDead = false;
    //Default values for rates
    public float defaultHunger = 5;
    public float infectedHunger = 8;
    public float defaultImmune = .005f;
    public float infectedImmune = 1;

    //getRole(): returns the role of the human
    public Role getRole()
    {
        return role;
    }

    //getSpeed(): returns the human's speed
    public float getSpeed()
    {
        return speed;
    }

    //getCash(): returns the players cash
    public float getCash()
    {
        return cash;
    }

    //addCash(float x): Increases the players cash by x
    public void addCash(float x)
    {
        cash += x;
    }

    //deductCash(float x): Decreases the players cash by x
    public void deductCash(float x)
    {
        cash -= x;
    }

    //getHunger(): returns the human's hunger
    public float getHunger()
    {
        return hunger;
    }
    //increaseHunger(int x): increases players hunger
    public void increaseHunger(float x)
    {
        hunger -= x;
    }
    //decreaseHunger(int x): decreases player hunger
    public void decreaseHunger(float x)
    {
        hunger += x;
    }

    //getImmuneSystem(): returns the players immune system
    public float getImmuneSystem()
    {
        return immune_system;
    }
    //decreaseImmuneSystem(): decreases the players immune system
    public void decreaseImmuneSystem(float x)
    {
        immune_system -= x;
    }
    //increaseImmuneSystem(): increases the players immune system
    public void increaseImmuneSystem(float x)
    {
        immune_system += x;
    }

    //setImmuneSystem(x): sets the immune system to value of x
    public void setImmuneSystem(float x)
    {
        immune_system = x;
    }

    //isInfected(): returns whether or not the player is infected
    public bool isInfected()
    {
        return is_infected;
    }

    //infect(): infects the human
    public void infect()
    {
        is_infected = true;
    }
    //setInfected(): sets the infected status of the human
    public void setInfected(bool b)
    {
        is_infected = b;
    }
    //determineInfection(): Determines whether or not the human gets infected when in contact
    public void determineInfection()
    {
        if(Random.Range(0, 100) > immune_system) //If the number rolled is greater than what the immune system can handle, then the player gets infected
        {
            infect();
        }
    }

    //getVirusTest(): returns the results of the players virus test
    public bool getVirusTest()
    {
        return virus_test;
    }

    //setVirusTest(bool b): sets the results of the virus test for the player
    public void setVirusTest(bool b)
    {
        virus_test = b;
    }

    //getHouseID(): returns the human's house ID
    public int getHouseID()
    {
        return house_id;
    }

    //setHouseID(int id): sets the human's house ID
    public void setHouseID(int id)
    {
        house_id = id;
    }

    //getPlaceOfWork(): gets the place of work
    public string getPlaceOfWork()
    {
        return placeOfWork;
    }
    //setPlaceOfWork(): sets the place of work
    public void setPlaceOfWork(string s)
    {
        placeOfWork = s;
    }

    //canWorkCheck(): Sets whether or not the player can work
    public bool canWorkCheck()
    {
        return canWork;
    }
    //setCanWork(): Sets whether or not the player can work
    public void setCanWork(bool b)
    {
        canWork = b;
    }

    //getIncome(): returns the income of the human
    public float getIncome()
    {
        return income;
    }

    //Update Function
    public void Awake()
    {
        //Determine the role of the human
        if(Random.Range(1, 10) < 6)
        {
            role = Role.essential_worker;
            //Set place of work
            placeOfWork = "Family Grocery Store";
            income = 150;
            canWork = true;
        }
        else
        {
            role = Role.remote_worker;
            income = 450;
        }
    }

    void checkIfDead()
    {
        if(getHunger() <= 0 && getImmuneSystem() <= 0)
        {
            isDead = true;
        }
    }

    public void lockMovement()
    {
        this.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void unlockMovement()
    {
        this.gameObject.transform.GetComponent<Rigidbody>().constraints = originalConstraints;
    }

    public bool is_dead()
    {
        return isDead;
    }
    //Start Function
    public void Start()
    {
        originalConstraints = this.gameObject.GetComponent<Rigidbody>().constraints;
        gm = GameManager.instance; //initialize gm to instance of game manager
        //set time_to_pay
        time_to_pay = gm.time_per_day;
    }

    //Update function
    public void Update()
    {

        //Clamp stats
        Mathf.Clamp(immune_system, 0, 100);
        Mathf.Clamp(hunger, 0, 100);
        //check if dead
        checkIfDead();
        if (isDead) //Destroy the gameObject if dead
        {
            lockMovement();
            this.gameObject.transform.position += (new Vector3(0, 2, 0) * Time.deltaTime);
        }
        if(getHunger() <= 0)
        {
            defaultImmune = infectedImmune;
        }
        //Check if infected
        if (is_infected)
        {
            increaseHunger(infectedHunger * Time.deltaTime * 2.5f);
            if(getHunger() <= 0)
            {
                decreaseImmuneSystem(infectedImmune * Time.deltaTime);
            }
            else
            {
                decreaseImmuneSystem(infectedImmune * Time.deltaTime * 1/10);
            }
        }
        else //if not infected
        {
            increaseHunger(defaultHunger * Time.deltaTime * .25f);
            if (getHunger() <= 0)
            {
                decreaseImmuneSystem(infectedImmune * Time.deltaTime);
            }
            else
            {
                decreaseImmuneSystem(infectedImmune * Time.deltaTime * 1/5);
            }
        }
        //decrement time to pay
        time_to_pay -= Time.deltaTime;
        //FOR REMOTE_WORKER
        if (RoleExt.isRole(role, Role.remote_worker))
        {
            //check if it is time to pay
            if(time_to_pay <= 0)
            {
                addCash(income);
                time_to_pay = gm.time_per_day;
            }
        }

        //FOR ESSENTIAL WORKER
        if(RoleExt.isRole(role, Role.essential_worker))
        {
            //Check if it is time to pay
            if(time_to_pay <= 0)
            {
                setCanWork(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Entered infection range with player!");
            //check if player is infected
            if (other.gameObject.GetComponent<Player>().isInfected() && !isInfected())
            {
                print("Determining if the AI will be infected");
                determineInfection(); //determine if AI gets infected
            }
        }
        else if(other.gameObject.tag == "AI"){
            print("Entered infection range with AI");
            //check if AI is infected
            if (other.gameObject.GetComponent<SimpleAI>().isInfected() && !isInfected())
            {
                print("Determining if the player will be infected");
                determineInfection(); //determine if the player gets infected
            }
        }
    }
}
