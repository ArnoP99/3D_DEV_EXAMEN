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
        if (other.gameObject.CompareTag("Examen"))
        {
            other.gameObject.SetActive(false);
            scoreStart++;
            score.text = scoreStart.ToString() + standardText;
        }
        else if (other.gameObject.tag == "patroler")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}