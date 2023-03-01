using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnSelection : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    public GameObject highlightObject;
    public Material defaultMaterial;
    private Transform _selection;

    // Start is called before the first frame update
    void Start()
    {

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
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                highlightObject.SetActive(true);
                _selection = selection;
            }

        }
    }
}
