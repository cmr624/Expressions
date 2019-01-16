using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{ 
    public class Puzzle
    {
        public List<Triple> grid = new List<Triple>(3);

        private List<string> operators = new List<string>() { "+", "-", "*", "/" };

        public int globalResult;

        private Triple GenerateTriple(TripleMode mode, int min, int max)
        {
            Triple returnMe = new Triple();
            returnMe.mode = mode;
            if (TripleMode.SOLVEABLE == returnMe.mode)
            {
                returnMe.firstNum = Random.Range(min, max);
                returnMe.operation = Utilities.RandomStringFromArray(operators);
               
               if (returnMe.operation == "/")
                {
                    returnMe.secondNum = FindDivisible(returnMe);
                }
                else
                {
                    returnMe.secondNum = Random.Range(min, max);
                }
                globalResult = returnMe.CalculateResult();
                //Debug.Log("SOLVEABLE");
            }
            else if (TripleMode.NONSENSE == returnMe.mode)
            {
                returnMe.firstNum = Random.Range(min, max);
                returnMe.operation = Utilities.RandomStringFromArray(operators);
                returnMe.secondNum = Random.Range(min, max);
            }
            else
            {
                Debug.LogError("Unsolveable");
            }

            return returnMe;
        }

        private static int FindDivisible(Triple returnMe)
        {
            //finds all possible 
            List<int> possibilities = new List<int>();
            for (int i = 1; i <= returnMe.firstNum; i++)
            {
                if (returnMe.firstNum % i == 0)
                {
                    possibilities.Add(i);
                }
            }
            //possibilities.ForEach((obj) => Debug.Log(obj));
            int x = Random.Range(0, possibilities.Count);
            return possibilities[x];

        }

        //constructor
        public Puzzle(int min, int max)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    grid.Add(GenerateTriple(TripleMode.SOLVEABLE, min, max));
                }
                else
                {
                    grid.Add(GenerateTriple(TripleMode.NONSENSE, min, max));
                }
            }
        }
    }
}


