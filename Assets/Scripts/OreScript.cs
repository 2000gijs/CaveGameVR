using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreScript : MonoBehaviour {
    float xpos;
    float ypos;
    float zpos;
    float hitcount;
    public GameObject miniOre;
    public float oreHealth = 15;
    public GameObject RockUi;
    public Text impactEffect;
    private IEnumerator coroutine;
    public GameObject PlayerCamera;


    //everything in start
	void Start () {
        posOres();
        hitCanvas();
        definePlayerCamera();
    }
    private void posOres()
    {
        xpos = this.gameObject.transform.position.x;
        ypos = this.gameObject.transform.position.y;
        zpos = this.gameObject.transform.position.z;
    }
    private void hitCanvas()
    {
        RockUi = GetComponentInChildren<Canvas>().gameObject;
        impactEffect = GetComponentInChildren<Text>();
    }
    private void definePlayerCamera()
    {
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in gos)
        {
            if (go.layer == 20)
            {
                PlayerCamera = go;
            }
        }
    }
    //everything in oncolliderenter
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pickaxe")
        {
            RockUi.transform.rotation = PlayerCamera.transform.rotation;
            RockUi.SetActive(true);
            //Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude >= 4)
            {
                //Debug.Log("Magnitude of the collider velocity was more then 4");
                oreHealth -= 1;
                impactEffect.text = "-1".ToString();
                coroutine = WaitAndPrint(2.0f);
                StartCoroutine(coroutine);
            }
            else if (collision.relativeVelocity.magnitude >= 8)
            {
                //Debug.Log("Magnitude of the collider velocity was more then 8");
                oreHealth -= 5;
                impactEffect.text = "-5".ToString();
                coroutine = WaitAndPrint(2.0f);
                StartCoroutine(coroutine);
            }
            if (oreHealth <= 0) {
                PickaxeScript.OresMined++;
                PickaxeScript.orecount--;
                TorchScript.TorchTimer += 30;
                Destroy(this.gameObject);
                Instantiate(miniOre, new Vector3(xpos, ypos, zpos), transform.rotation);
            }
            
        }
    }
    
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            impactEffect.text = "".ToString();
        }
    }
  
}
