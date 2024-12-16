using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
namespace Controllers
{
    public class Quest : MonoBehaviour
    {
        [SerializeField] private AnswerController _answerController;
        private TextMeshProUGUI _textMeshPro;

        private void Start()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _textMeshPro.text = "";

        }
        public void ChangeText()
        {
            _textMeshPro.text = "Find:" + _answerController.GetAnswer();
        }
    }
}