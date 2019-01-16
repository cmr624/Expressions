using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using TMPro;
public class PuzzleManager : MonoBehaviour
{
    [HideInInspector]
    public Puzzle currentPuzzle;
    [HideInInspector]
    public PuzzleVisualizer puzzleVisualizer;

    public FeedbackVisualizer fv;
    private GameObject grid;
    private RandomPuzzleGenerator RPG;

    public PuzzleData data;

    public Triple userTriple;

    [HideInInspector]
    public bool correct;


    private GameObject indicator;

    private Validator validator;
    public ScoreboardVisualizer sv;
    //this basically needs to act as the one and only thing that
    //creates a puzzle and indicates what puzzle is ont he screen. also validates. 
    //all data goes through here.

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid");
        RPG = new RandomPuzzleGenerator();
        NewPuzzleInfo();

        indicator = GameObject.FindGameObjectWithTag("UIIndicator");
        indicator.SetActive(false);

        int width = 375; // or something else
        int height = 667; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else
        Screen.SetResolution(width, height, isFullScreen, desiredFPS);


    }

    private void NewPuzzleInfo()
    {
        userTriple = new Triple();
        RPG.GeneratePuzzle(data);
        puzzleVisualizer = RPG.puzzleVisualizer;
        currentPuzzle = RPG.puzzle;
        correct = false;
        sv.UpdateResult();
        RPG.DebugLogger();
    }

    private void Update()
    {

        userTriple = grid.GetComponent<GridVisualizer>().userTriple;
        if (grid.GetComponent<GridVisualizer>().counter >= 2)
        {
            validator = new Validator(userTriple, currentPuzzle);
            correct = validator.Validate();
            indicator.SetActive(true);
            //new puzzle
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fv.UpdateText();
                NewPuzzleInfo();
                grid.GetComponent<GridVisualizer>().UpdateButtons();
                indicator.SetActive(false);
            }
        }
    }



}
