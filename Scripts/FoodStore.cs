using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStore : MonoBehaviour
{
    public GameObject foodPanel;
    public GameObject label;
    public GameObject text;
    public GameObject button;
    public GameObject buttonText;
    public float foodCost;
    public float foodRestore;

    private void OnCollisionEnter(Collision other)
    {
        //Check if player
        if (other.gameObject.tag == "Player")
        {
            print("Entered Food Store");
            label.GetComponent<TextMeshProUGUI>().SetText(this.gameObject.name);
            other.gameObject.GetComponent<Player>().lockMovement();
            foodPanel.SetActive(true);
            if (other.gameObject.GetComponent<Player>().getCash() >= foodCost) //Check if player can afford food right now
            {
                text.GetComponent<TextMeshProUGUI>().SetText("You can buy food for " + foodCost.ToString("C0"));
            }
            else
            {
                text.GetComponent<TextMeshProUGUI>().SetText("You cannot afford the food right now!");
                buttonText.GetComponent<TextMeshProUGUI>().SetText("Ok");
            }
        }//Check if AI
        else if (other.gameObject.tag == "AI")
        {
            if (other.gameObject.GetComponent<SimpleAI>().getPlaceOfWork() == this.gameObject.name)//Check if AI works here
            {
                buyFood(other.gameObject);
            }
        }
    }

    public void buyFood(GameObject obj)
    {
        if (obj.tag == "Player") //Logic for player
        {
            Player p = obj.GetComponent<Player>();
            if (p.getCash() >= foodCost) //Check if player can afford food
            {
                p.deductCash(foodCost); //Pay for food
                p.decreaseHunger(foodRestore); //Decrease hunger
            }
            foodPanel.SetActive(false);
            p.unlockMovement();
        }
        else if (obj.tag == "AI") //Logic for AI
        {
            SimpleAI sai = obj.GetComponent<SimpleAI>();
            if(sai.getCash() >= foodCost)
            {
                sai.deductCash(foodCost); //pay for food
                sai.decreaseHunger(foodRestore); //Decrease hunger
            }
        }
    }
}
