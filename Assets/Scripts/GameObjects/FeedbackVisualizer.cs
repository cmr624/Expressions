using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FeedbackVisualizer : MonoBehaviour
{

    public GameObject manager;

    private PuzzleManager pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = manager.GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        if (pm.correct)
        {
            GetComponent<TextMeshProUGUI>().text = pm.userTriple.ToString() + " = " + pm.currentPuzzle.globalResult;
            GetComponent<TextMeshProUGUI>().color = Color.green;
            //Debug.Log("YES");
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = pm.userTriple.ToString() + " != " + pm.currentPuzzle.globalResult;
            GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
}
