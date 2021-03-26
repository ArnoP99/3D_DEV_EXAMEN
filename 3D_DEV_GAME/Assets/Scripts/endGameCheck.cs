using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;
using UnityEngine.XR;
using UnityEditor;




public class endGameCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public InputDeviceCharacteristics ControllerCharacteristics;
    private string tempNum;
    private Stopwatch timer;
    private string path = "Assets/Resources/Highscores.txt";
   
    List<InputDevice> devices = new List<InputDevice>();

   


    void Start()
    {
        timer = new Stopwatch();
        timer.Start();
        StreamWriter writer = new StreamWriter(path, true);
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, devices);
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, devices);
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var device in devices)
        {
            bool buttonPressed;
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton , out buttonPressed ) && buttonPressed)
            {
                UnityEngine.Debug.Log("Exit");
                Application.Quit();
            }
        }



       
    }
    private void OnTriggerEnter(Collider other)
    {
        StreamWriter writer = new StreamWriter(path, true);
        UnityEngine.Debug.Log("colided");
        if (score.text.Substring(0, 1) == "1")
        {
            string time = timer.Elapsed.ToString();
            timer.Stop();
            tempNum = score.text.Substring(0, 1);
            score.fontSize = 40;
            score.text = "Congratulations, you WON!\nPress q to quit.\n" + time;
            writer.WriteLine("\n" + time );
            writer.Close();
        }
        else
        {
            tempNum = score.text.Substring(0, 1);
            score.fontSize = 40;
            score.text = "Not enough exams collected \nyet, get some more first!";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey("q") && score.text.Substring(0,1) == "C")
        {
            //UnityEditor.EditorApplication.ExitPlaymode();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        score.fontSize = 40; //ooit nog is nakijken of die fontsize verandere overal nog nodig is aangezien die standaard op 40 staat ... 
        score.text = tempNum + "/9 Exams Collected";
    }
}