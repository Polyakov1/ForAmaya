using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    public class ButtonRefresh : MonoBehaviour
    {
       [SerializeField] private Controllers.AnswerController _objAnswerComponent;
       [SerializeField] private Controllers.Quest _objQuestComponent;
       [SerializeField] private Controllers.LevelManager _lvlController;

        public void RestartLvl()
        {
            _lvlController.LoadLevel(0);
        }
    }
}