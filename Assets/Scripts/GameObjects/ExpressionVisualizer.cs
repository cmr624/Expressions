using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExpressionVisualizer : MonoBehaviour
{
    public GameObject manager;
    private TextMeshProUGUI text;
    private PuzzleManager pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = manager.GetComponent<PuzzleManager>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = pm.userTriple.ToString();
    }
}
