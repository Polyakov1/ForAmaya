using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class AnswerController : MonoBehaviour
    {
        [Header("Answers")]
        private string _answer;
       [SerializeField] private string[] _possibleOptionsCurrent = { };

        private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private Quest _questComponent;

        private Sprite _error;
        private void Start()
        {
            UpdatePossibleOptions();


        }
        public void UpdatePossibleOptions()
        {
            ArrayList tempArrayAnswer = new ArrayList();
            foreach (var sprite in _sprites)
            {
                tempArrayAnswer.Add(sprite.name);
            }
            _possibleOptionsCurrent = tempArrayAnswer.ToArray(typeof(string)) as string[];
        }
        public int RandomAnswer()
        {
            return Random.Range(0, _possibleOptionsCurrent.Length - 1);
        }

        public string GetAnswer()
        {
            return _answer;
        }

        public void SetAnswer(string answer)
        {
            _answer = answer;
            _questComponent.ChangeText();
        }

        public void LoadLetters(Sprite[] sprites)
        {
            _sprites = sprites;
        }
        private string RemoveSymbol(string nameSprite)
        {
            List<string> tempList = new List<string>();
            string giveSpriteName = null;

            for (int i = 0; i < _possibleOptionsCurrent.Length; i++)
            {
                if (!Equals(_possibleOptionsCurrent[i], nameSprite))
                {

                    tempList.Add(_possibleOptionsCurrent[i]);
                }
                else
                {
                    giveSpriteName = _possibleOptionsCurrent[i];
                }
            }
            _possibleOptionsCurrent = tempList.ToArray();
            return giveSpriteName;
        }

        public Sprite GiveSprite(int index)
        {
            string nameSprite = RemoveSymbol(_possibleOptionsCurrent[index]);
            foreach (var item in _sprites)
            {
                if (Equals(item.name, nameSprite))
                {
                    
                    return item;
                }
            }
            return null;
        }


    }
}
