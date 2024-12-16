using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Buttons
{
    public class ButtonNextLvl : MonoBehaviour
    {
        [SerializeField] private Controllers.LevelManager _lvlController;
        public void NextLvl()
        {
            _lvlController.LoadLevel(1);
        }
    }
}