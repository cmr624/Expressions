using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

public class GridVisualizer : MonoBehaviour
{
    public GameObject buttonPrefab;

    public GameObject manager;// = new RandomPuzzleGenerator(data);
    private PuzzleVisualizer puzzleVisualizer;
    [HideInInspector]
    public int counter = -1;

    [HideInInspector]
    public Triple userTriple;

    // Start is called before the first frame update
    private void Start()
    {
        puzzleVisualizer = manager.GetComponent<PuzzleManager>().puzzleVisualizer;
        CreateButtons();
        UpdateButtons();
        ButtonListeners();
    }
    void CreateButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(buttonPrefab, transform);
            Instantiate(buttonPrefab, transform);
            Instantiate(buttonPrefab, transform);
        }
    }



    void CreateOnClick(Button b)
    {
        counter++;
        switch (counter)
        {
            case (0):
                userTriple.firstNum = int.Parse(b.GetComponentInChildren<TextMeshProUGUI>().text);
                break;
            case (1):
                userTriple.operation = b.GetComponentInChildren<TextMeshProUGUI>().text;
                break;
            case (2):
                userTriple.secondNum = int.Parse(b.GetComponentInChildren<TextMeshProUGUI>().text);
                break;
        }

    }

    void ButtonListeners()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.onClick.AddListener(delegate { CreateOnClick(b); });
        }
    }

    public void UpdateButtons()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        int localCounter = 0;
        for (int i = 0; i < 3; i++)
        {
            buttons[localCounter].GetComponentInChildren<TextMeshProUGUI>().text = puzzleVisualizer.colLeft[i].ToString();
            localCounter++;
            buttons[localCounter].GetComponentInChildren<TextMeshProUGUI>().text = puzzleVisualizer.colMiddle[i];
            localCounter++;
            buttons[localCounter].GetComponentInChildren<TextMeshProUGUI>().text = puzzleVisualizer.colRight[i].ToString();
            localCounter++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (counter >= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                counter = -1;
                userTriple = new Triple();
                puzzleVisualizer = manager.GetComponent<PuzzleManager>().puzzleVisualizer;
                UpdateButtons();
            }
        }
    }
}
