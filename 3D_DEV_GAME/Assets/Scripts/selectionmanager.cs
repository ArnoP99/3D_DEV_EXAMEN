using UnityEngine;
using UnityEngine.UI;

public class selectionmanager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;


    private Transform _selection;
    private int scoreStart = 0;
    private string standardText = "/9 Exams Collected";

    public float distance;
    public Text score;

    void Start()
    {
        score.text = scoreStart.ToString() + standardText;
    }

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
