using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //static instance
    public GameObject AI;
    public Player player;
    //global time variable
    public float time = 0;
    public int day = 1;
    public float time_per_day;

    //Canvas Items
    public GameObject deathPanel;

    //Stores houses
    public GameObject[] house;
    //public static GameObject[] houses;

    private void Awake()
    {
        //Make sure another GameManager doesn't exist
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //Instantiate AI
        for (int i = 1; i < house.Length/2; i++)
        {
            GameObject human = Instantiate(AI) as GameObject;
            human.SetActive(true);
            human.name = "human[" + i + "]";
            human.GetComponent<SimpleAI>().setHouseID(i);
            house[i].GetComponent<House>().id = i;
            Vector3 pos = house[i].transform.position;
            pos.z = player.gameObject.transform.position.z;
            this.gameObject.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; //increment the time
        if(time >= time_per_day) //Once 60 seconds have passed reset the clock and increment the day
        {
            time = 0; //set the time back to 0
            day++; //increment the day
        }
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
