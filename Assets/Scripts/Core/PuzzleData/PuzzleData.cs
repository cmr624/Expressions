using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Core/PuzzleData")]
    public class PuzzleData : ScriptableObject
    {
        public int min;
        public int max;
    }
  
}

