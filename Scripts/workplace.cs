using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class workplace : MonoBehaviour
{
    public GameObject workPanel;
    public GameObject label;
    public GameObject text;
    public GameObject button;
    public GameObject buttonText;

    private void OnCollisionEnter(Collision other)
    {
        //Check if player
        if(other.gameObject.tag == "Player")
        {
            print("Entered Workplace");
            if(other.gameObject.GetComponent<Player>().getPlaceOfWork() == this.gameObject.name)
            {
                label.GetComponent<TextMeshProUGUI>().SetText(other.gameObject.GetComponent<Player>().getPlaceOfWork());
                other.gameObject.GetComponent<Player>().lockMovement();
                workPanel.SetActive(true);
                if (other.gameObject.GetComponent<Player>().canWorkCheck()) //Check if player can work
                {
                    text.GetComponent<TextMeshProUGUI>().SetText("You can work right now!");
                    buttonText.GetComponent<TextMeshProUGUI>().SetText("Go to Work");
                }
                else
                {
                    text.GetComponent<TextMeshProUGUI>().SetText("You cannot work right now!");
                    buttonText.GetComponent<TextMeshProUGUI>().SetText("Ok");
                }
            }
        }//Check if AI
        else if(other.gameObject.tag == "AI")
        {
            if(other.gameObject.GetComponent<SimpleAI>().getPlaceOfWork() == this.gameObject.name)//Check if AI works here
            {
                goToWork(other.gameObject);
            }
        }
    }

    public void goToWork(GameObject obj)
    {
        if(obj.tag == "Player") //Logic for player
        {
            Player p = obj.GetComponent<Player>();
            if (p.canWorkCheck()) //Check if player can work
            {
                p.addCash(p.getIncome()); //Set it so they get their money
                p.setCanWork(false); //Set it so they can't work again
            }
            workPanel.SetActive(false);
            p.unlockMovement();
        } else if(obj.tag == "AI") //Logic for AI
        {
            SimpleAI sai = obj.GetComponent<SimpleAI>();
            sai.addCash(sai.getIncome());
            sai.setCanWork(false); //Set it so they can't work again
        }
    }
}
