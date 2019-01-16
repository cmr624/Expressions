using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class RandomPuzzleGenerator
{
    [HideInInspector]
    public Puzzle puzzle;

    [HideInInspector]
    public PuzzleVisualizer puzzleVisualizer = new PuzzleVisualizer();
    //public
    //private PuzzleData data;

   /*public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneratePuzzle();
            DebugLogger();
        }
    }*/
        

    public void GeneratePuzzle(PuzzleData data)
    {
        this.puzzle = new Puzzle(data.min, data.max);
        RandomizePuzzle();
    }

    private void RandomizePuzzle()
    {
        /*
       1) in colLeft, all of the triple's firstNums in an int array.
       2) in colMiddle, all of the triple's operators in a string array
       3) in colRight, all of the triple's secondNums in an int array
       */
        List<int> colLeft = new List<int>();

        List<string> colMiddle = new List<string>();

        List<int> colRight = new List<int>();

        this.puzzle.grid.ForEach((Triple t) =>
        {
            colLeft.Add(t.firstNum);
            colMiddle.Add(t.operation);
            colRight.Add(t.secondNum);
        });

        Utilities.Shuffle(colLeft);
        Utilities.Shuffle(colMiddle);
        Utilities.Shuffle(colRight);

        this.puzzleVisualizer.colLeft = colLeft;
        this.puzzleVisualizer.colMiddle = colMiddle;
        this.puzzleVisualizer.colRight = colRight;
       
    }

    public void DebugLogger()
    {
        string between = "|";
        Debug.Log("RESULT = " + this.puzzle.globalResult);
        for(int i = 0; i < 3; i++)
        {
            Debug.Log(this.puzzleVisualizer.colLeft[i] + between + this.puzzleVisualizer.colMiddle[i] + between + this.puzzleVisualizer.colRight[i]);
        }
    }

}

