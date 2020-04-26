using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    /* Took some help from Brackeys Youtube Tutorial on POV movement mechanics */

    private Player player; //reference to player
    public float speed;
    public Camera cam; //reference to camera

    //Awake is called before the game starts
    private void Awake()
    {
        player = this.gameObject.GetComponent<Player>();
        speed = player.getSpeed();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get horizontal and vertical movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Calculate movement direction
        Vector3 dir = new Vector3(x, 0, z);
        //transform.localRotation = Quaternion.Euler(0, 0, pitch);
        //Apply movement direction
        this.gameObject.GetComponent<Rigidbody>().AddForce(dir * speed);
    }
}