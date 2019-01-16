using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;
public class ScoreboardVisualizer : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Puzzle puzzle;
    private int globalResult;
    public GameObject manager;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateResult()
    {
        puzzle = manager.GetComponent<PuzzleManager>().currentPuzzle;
        globalResult = puzzle.globalResult;
        text.text = globalResult.ToString();
    }
}
