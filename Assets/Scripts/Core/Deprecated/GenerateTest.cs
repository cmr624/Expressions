using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class GenerateTest : MonoBehaviour
{
    private Puzzle puzzle;
    public int min;
    public int max;
    // Start is called before the first frame update
    private void GeneratePuzzle()
    {
        puzzle = new Puzzle(min, max);
        Debug.Log("GLOBAL RESULT:" + puzzle.globalResult);
        for (int i = 0; i < puzzle.grid.Count; i++)
        {
            Debug.Log(puzzle.grid[i].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneratePuzzle();
        }
    }
}
