using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class UIScriptControllers : MonoBehaviour {

    public GameObject LeftControllerUI;
    public GameObject RightControllerUI;
    public bool RightUiController;
    public bool LeftUiController;
    public float test;
    public float test1;
    public Text OresMinedController;
    public float UiSelect;
    public float UiActive;

    public GameObject UiSelected1;
    public GameObject UiSelected2;
    public GameObject UiSelected3;

   

    // Use this for initialization
    void Start() {
        startingwithmenuclosed();
        defaultmenuselection();
    }
    public void startingwithmenuclosed()
    {
        RightControllerUI.SetActive(false);
        LeftControllerUI.SetActive(false);
        LeftUiController = false;
        RightUiController = false;
    }
    private void defaultmenuselection()
    {
        UiSelected1.SetActive(true);
        UiSelected2.SetActive(false);
        UiSelected3.SetActive(false);
    }
    // Update is called once per frame
    void Update() {
        OreQuantityCounter();
        inputForMenu();
        MovingInTheMenu();
        activatingMenuButtons();
        testPrints();
    }
    private void OreQuantityCounter()
    {
        OresMinedController.text = "Ores Mined: " + PickaxeScript.OresMined.ToString();
    }
    private void inputForMenu()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.A) && test == 0f)
        {
            //Debug.Log("the Right trigger has been pressed");
            RightControllerUI.SetActive(true);
            RightUiController = true;
            test++;
            //Debug.Log("UIActief");
        }

        if (OVRInput.GetUp(OVRInput.RawButton.B) && test == 1f)
        {
            //Debug.Log("the Right trigger has been pressed");
            RightControllerUI.SetActive(false);
            RightUiController = false;
            test--;
        }

        //Debug.Log(test);
        //Debug.Log(test1);
        if (OVRInput.GetUp(OVRInput.RawButton.X) && test1 == 0f)
        {
            //Debug.Log("the Right trigger has been pressed");
            LeftControllerUI.SetActive(true);
            LeftUiController = true;
            test1++;

            //Debug.Log("UIActief");
        }

        if (OVRInput.GetUp(OVRInput.RawButton.Y) && test1 == 1f)
        {
            //Debug.Log("the Right trigger has been pressed");
            LeftControllerUI.SetActive(false);
            LeftUiController = false;
            test1--;
        }
    }
    private void MovingInTheMenu()
    {
        //the code that dictates the value that dictates which menu option you have selected-----------------------
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown) && UiSelect >= 0 && UiSelect < 2)
        {
            UiSelect++;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp) && UiSelect > 0 && UiSelect <= 2)
        {
            UiSelect--;
        }
        //the options you select by value from the lines above----------------------------------------------
        if (UiSelect == 0)
        {
            UiSelected1.SetActive(true);
            UiSelected2.SetActive(false);
            UiSelected3.SetActive(false);
        }
        if (UiSelect == 1)
        {
            UiSelected2.SetActive(true);
            UiSelected1.SetActive(false);
            UiSelected3.SetActive(false);
        }
        if (UiSelect == 2)
        {
            UiSelected3.SetActive(true);
            UiSelected2.SetActive(false);
            UiSelected1.SetActive(false);
        }
    }
    private void activatingMenuButtons()
    {
        if (UiSelect == 0 && UiActive == 1 && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {

        }
        if (UiSelect == 1 && UiActive == 1 && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {

        }
        if (UiSelect == 2 && UiActive == 1 && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            Application.Quit();
        }
    }
    private void testPrints()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            Debug.Log("the Right grip has been pressed");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        {
            Debug.Log("the Right thumbstick has been moved down");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp))
        {
            Debug.Log("the Right thumbstick has been moved up");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            Debug.Log("the Right thumbstick has been moved to the right");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            Debug.Log("the Right thumbstick has been moved to the left");
        }
    }
}
