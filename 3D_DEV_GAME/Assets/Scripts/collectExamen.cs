using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collectExamen : MonoBehaviour
{

    private int scoreStart = 0;
    private string standardText = "/9 Exams Collected";

    public Text score;

    void Start()
    {
        score.text = scoreStart.ToString() + standardText;
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
        }
        else if (other.gameObject.tag == "patroler")
        {
            Debug.Log("gameover");
            SceneManager.LoadScene("MainScene");
        }
    }
}



