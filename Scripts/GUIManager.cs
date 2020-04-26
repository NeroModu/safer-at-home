using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    //GameManager
    public GameManager gm;
    //Time and day
    public GameObject dayText;
    public GameObject timeText;
    //Player
    public Player player;
    //Role
    public GameObject roleText;
    //Money
    public GameObject cashText;
    //infection status
    public GameObject infectionStatus;
    //Sliders
    public GameObject healthSlider;
    public GameObject hungerSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance; //set gm to instance of GameManager
    }

    // Update is called once per frame
    void Update()
    {
        //Update date and time GUI
        dayText.GetComponent<TextMeshProUGUI>().SetText("Day: " + gm.day.ToString());
        timeText.GetComponent<TextMeshProUGUI>().SetText("Time: " + gm.time.ToString("F0"));
        //Update Player Stats GUI
        roleText.GetComponent<TextMeshProUGUI>().SetText(roleStr(player.getRole()));
        cashText.GetComponent<TextMeshProUGUI>().SetText(player.getCash().ToString("C0"));
        infectionStatus.GetComponent<Toggle>().isOn = player.getVirusTest();
        healthSlider.GetComponent<Slider>().value = player.getImmuneSystem();
        hungerSlider.GetComponent<Slider>().value = player.getHunger();
    }

    private string roleStr(Role r)
    {
        if (r.Equals(Role.essential_worker))
        {
            return "Essential Worker";
        }
        else if(r.Equals(Role.remote_worker))
        {
            return "Remote Worker";
        }
        else
        {
            return "Unknown Role";
        }
    }
}
