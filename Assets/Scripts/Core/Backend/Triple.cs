using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public enum TripleMode
    {
        SOLVEABLE,
        NONSOLVEABLE,
        NONSENSE
    }
    //a triple is a data structure that represents an integer, an operator, and another integer with an associated result
    public struct Triple
    {
        public int firstNum;
        public string operation;
        public int secondNum;

        public TripleMode mode;

        public Triple(int firstNum, string operation, int secondNum, TripleMode mode)
        {
            this.firstNum = firstNum;
            this.operation = operation;
            this.secondNum = secondNum;
            this.mode = mode;
        }

        public int CalculateResult()
        {
            //calculates a result if the triple has a valid mode
            if (this.mode == TripleMode.SOLVEABLE)
            {
                int value = 0;
                switch (this.operation)
                {
                    case "+":
                        value = this.firstNum + this.secondNum;
                        break;
                    case "-":
                        value = this.firstNum - this.secondNum;
                        break;
                    case "*":
                        value = this.firstNum * this.secondNum;
                        break;
                    case "/":
                        //surround by try catch ?
                        //Debug.Log(this.firstNum + "/" + this.secondNum);
                        value = this.firstNum / this.secondNum;
                        break;
                }
                return value;
            }
            else
            {
                return -999;
            }

        }

        public override string ToString()
        {
            return this.firstNum.ToString() + " " + this.operation + " " + this.secondNum.ToString();
        }
    }
}

