using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;
using UnityEngine.XR;


public class endGameCheck : MonoBehaviour
{
    private string tempNum;
    private Stopwatch timer;
    private string path = "Assets/Resources/Highscores.txt";

    public Text score;
    public InputDeviceCharacteristics ControllerCharacteristics;

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
            writer.WriteLine("\n" + time);
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
        foreach (var device in devices)
        {
            bool buttonPressed;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out buttonPressed) && buttonPressed)
            {
                UnityEngine.Debug.Log("Exit");
                Application.Quit();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        score.fontSize = 40;
        score.text = tempNum + "/9 Exams Collected";
    }
}