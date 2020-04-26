using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hospital : MonoBehaviour
{
    public GameObject hospitalPanel;
    public GameObject text;
    public GameObject button;
    public GameObject buttonText;

    //Costs
    public float testingCost;
    public float treatmentCost;

    private void OnCollisionEnter(Collision other)
    {
        //Check if player
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Hospital")
        {
            hospitalPanel.SetActive(true);
            Player p = other.gameObject.GetComponent<Player>();
            p.lockMovement();
            //Check if is negative
            if (p.getVirusTest() == false)
            {
                if(p.getCash() >= testingCost)
                {
                    text.GetComponent<TextMeshProUGUI>().SetText("Pay " + testingCost.ToString("C0") + " to get tested");
                    buttonText.GetComponent<TextMeshProUGUI>().SetText("Pay for test");
                }
                else
                {
                    text.GetComponent<TextMeshProUGUI>().SetText("You need " + testingCost.ToString("C0") + " to get tested");
                    buttonText.GetComponent<TextMeshProUGUI>().SetText("Ok");
                }
            }else if(p.getVirusTest() == true)
            {
                if(p.getCash() >= treatmentCost)
                {
                    text.GetComponent<TextMeshProUGUI>().SetText("Pay " + testingCost.ToString("C0") + " to get treatment (70% success rate)");
                    buttonText.GetComponent<TextMeshProUGUI>().SetText("Pay for treatment");
                }
                else
                {
                    text.GetComponent<TextMeshProUGUI>().SetText("You need " + testingCost.ToString("C0") + " to get treated");
                    buttonText.GetComponent<TextMeshProUGUI>().SetText("ok");
                }
            }
            
        }//Check if AI
        else if (other.gameObject.tag == "AI" && this.gameObject.tag == "Hospital")
        {
            if (other.gameObject.GetComponent<SimpleAI>().getPlaceOfWork() == this.gameObject.name)//Check if AI works here
            {
                getHospitalServices(other.gameObject);
            }
        }
    }

    public void getHospitalServices(GameObject obj)
    {
        if (obj.tag == "Player") //Logic for player
        {
            Player p = obj.GetComponent<Player>();
            //Check if they are tested or not
            if(p.getVirusTest() == false && p.getCash() >= testingCost)
            {
                //Pay for the virus test
                p.deductCash(testingCost);
                //Apply test
                p.setVirusTest(p.isInfected());
            }else if(p.getVirusTest() == true && p.getCash() >= treatmentCost) //tested positive
            {
                //Pay for treatment
                p.deductCash(treatmentCost);
                //apply immune services
                if(Random.Range(0, 10) <= 7)
                {
                    p.setInfected(false);
                    p.setImmuneSystem(100);
                }
            }
            hospitalPanel.SetActive(false);
            p.unlockMovement();
        }
        else if (obj.tag == "AI") //Logic for AI
        {
            SimpleAI sai = obj.GetComponent<SimpleAI>();
            //Check if ai is infected
            if(sai.getVirusTest() == false)
            {
                if(sai.getCash() >= testingCost)
                {
                    //Deduct AI cash
                    sai.deductCash(testingCost);
                    sai.setVirusTest(sai.isInfected());
                }
            }
            while(sai.getVirusTest() == true)
            {
                if(sai.getCash() >= treatmentCost)
                {
                    //Deduct AI cash
                    sai.deductCash(treatmentCost);
                    //apply immune services
                    if(Random.Range(0, 10) <= 7)
                    {
                        sai.setInfected(false);
                        sai.setImmuneSystem(100);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
