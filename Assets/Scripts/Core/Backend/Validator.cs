using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace Core
{
    public class Validator
    {
        public Triple input;
        public Puzzle puzzle;

        public Validator(Triple input, Puzzle puzzle)
        {
            this.input = input;
            this.puzzle = puzzle;
        }

        public bool Validate()
        {
            return (input.CalculateResult() == puzzle.grid[0].CalculateResult());
        }

    }
}

