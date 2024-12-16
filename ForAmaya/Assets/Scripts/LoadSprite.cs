using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;
namespace Controllers
{
    public class LoadSprite : MonoBehaviour
    {
        [SerializeField] private Controllers.AnswerController _answerContoller;
        private void Awake()
        {
            List<Sprite> _spritesList = new List<Sprite>();
            SpriteRenderer[] _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            foreach (var spriteRenderer in _spriteRenderers)
            {
                if (spriteRenderer.sprite != null)
                {
                    _spritesList.Add(spriteRenderer.sprite);
                }
            }

            Sprite[] _sprites = _spritesList.ToArray();
            _answerContoller.LoadLetters(_sprites);
            Destroy(gameObject);
        }
    
         
    }
}