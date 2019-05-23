using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class PickaxeScript : MonoBehaviour {

    public static float orecount = 10;
    public static float OresMined;
    public Text OreCount;
    public GameObject WinningUI;
    public Text WonUi;
    public GameObject player;
    public bool pickaxedropped = false;
    public GameObject host;
    
    

    // Use this for initialization
    void Start () {
        quantityofores();
        winscreendisableatstart();
    }
	public void quantityofores()//for the ui tracker and the winning conditions.
    {
        OresMined = 0;
    }
	
	//function to disable Win UI at start of level
    public void winscreendisableatstart()
    {
        WinningUI.SetActive(false);
    }
    
    
    void OnCollisionEnter(Collision collision)
    {
        //system to spawn pickaxe at belt
        if (collision.gameObject.tag == "Ground")
        {
            pickaxedropped = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(player.transform);
            this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            this.gameObject.transform.Rotate(0, 0, 180);
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
    
    
    void OnTriggerEnter(Collider collider){
        //system to check if the player grabs the pickaxe from the belt
        if (collider.gameObject.tag == "Hand" && pickaxedropped == true)
        {
            Debug.Log("de grip is ingedrukt en de speler heeft gecollide met de pickaxe");
            transform.SetParent(null);
            pickaxedropped = false;
        }
    }

	// Update is called once per frame
	void Update () {
        OreCounter();
        wincondittiontosetactive();
    }
	
	//function for the orecounter
   private void OreCounter()
    {
        OreCount.text = "Ore Count: " + orecount.ToString();
    }
    
   //function to set the win UI on
   private void wincondittiontosetactive()
    {
        if (orecount == 0)
        {


            //Debug.Log("gewonnen");
            WinningUI.SetActive(true);
        }
    }
}
