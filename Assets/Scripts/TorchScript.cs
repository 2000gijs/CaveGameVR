using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour {

    public static float TorchTimer = 200;
    public float TorchTimer2;
    public bool countdownactivebool = false;
    public GameObject torcheffect;
    public bool torcheffectative = false;

    void Update() {
        torchfuelcountdown();
        torchoutoffuel();
        torchfuelrefill();

    }
    private void torchfuelcountdown()
    {
        TorchTimer2 = TorchTimer;
    }
    private void torchoutoffuel()
    {
        if (TorchTimer <= 0) {
            StopAllCoroutines();
            countdownactivebool = false;
        }
        if (countdownactivebool == false)
        {
            torcheffect.SetActive(false);

        }
    }
    private void torchfuelrefill()
    {
        if (TorchTimer > 0 && countdownactivebool == false)
        {
            StartCoroutine(WaitAndPrint());
            countdownactivebool = true;
        }
        if (countdownactivebool == true)
        {
            torcheffect.SetActive(true);

        }

    }
    private IEnumerator WaitAndPrint()
    {
        
            yield return new WaitForSeconds(1); 
            TorchTimer--;
            //Debug.Log("kkkkkkkk");
            StartCoroutine(WaitAndPrint());
    }
}
