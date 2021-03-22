using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectExamen : MonoBehaviour
{

    public Text score;
    private int scoreStart = 0;
    private string standardText = "/9 Exams Collected";


    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreStart.ToString() + standardText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colide");
            if (other.gameObject.CompareTag("Examen"))
            {
            Debug.Log("colide with exam");
            other.gameObject.SetActive(false);
                Debug.Log(other.gameObject.name);
                scoreStart++;
                score.text = scoreStart.ToString() + standardText;
                // So, I think what I'm saying here is: if the GameObject that this script is attached to (the Right Hand Controller) touches an object tagged "Present"
                // Then the object is set inactive, the name is logged, and the count goes up by one.
            }
       
    }


}
