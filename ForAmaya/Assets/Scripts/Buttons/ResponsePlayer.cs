using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class ResponsePlayer : MonoBehaviour
    {
        [SerializeField] private AnswerController _answerController;
        [SerializeField] private LevelManager _lvlController;
        [SerializeField] private ButtonsAnim _anim;
        [SerializeField] private GameObject _particle;
        private float _multiplayerForTime = 2;
        private void Start()
        {
            _anim = GetComponent<ButtonsAnim>();
            _answerController = GetComponentInParent<AnswerController>();
            _lvlController = GetComponentInParent<LevelManager>();
        }
        public void GiveAnswer()
        {
            StartCoroutine(nameof(EqualsAnswers));
        }
        private IEnumerator EqualsAnswers()
        {
            if (_answerController.GetAnswer() != null)
            {
                if (Equals(gameObject.name, _answerController.GetAnswer()))
                {
                    _anim.GoodAnswer(gameObject, _particle);
                    gameObject.GetComponent<Button>().enabled = false;
                    yield return new WaitForSeconds(_anim.GetGoodAnswerDuration() + _multiplayerForTime);
                    gameObject.GetComponent<Button>().enabled = true;
                    _lvlController.LoadLevel(1);

                }
                else
                {
                    gameObject.GetComponent<Button>().enabled = false;
                    _anim.WrongAnswer(gameObject);
                    yield return new WaitForSeconds(_anim.GetWrongAnswerDuration() + _multiplayerForTime);
                    gameObject.GetComponent<Button>().enabled = true;
                }
            }
        }

    }
}