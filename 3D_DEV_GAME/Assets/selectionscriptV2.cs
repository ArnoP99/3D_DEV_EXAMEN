using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectionscriptV2 : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    

   

    public Text score;
    private Transform _selection;
    private int scoreStart = 0;
    public float distance;
    private string standardText = "/9 Exams Collected";



    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreStart.ToString() + standardText;
    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Examen" && hit.distance < distance)
        {
            Debug.Log("hit");
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.transform.gameObject);
                    scoreStart++;
                    score.text = scoreStart.ToString() + standardText;
                }
            }
            _selection = selection;
        }
    }
}