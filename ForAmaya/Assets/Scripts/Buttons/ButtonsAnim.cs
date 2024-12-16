using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Buttons
{
    public class ButtonsAnim : MonoBehaviour
    {
        [Header("Wrong Answer Animation Settings")]
        [SerializeField] private float wrongAnswerMoveDistance = 1f;
        [SerializeField] private float wrongAnswerDuration = 0.3f;

        [Header("Good Answer Animation Settings")]
        [SerializeField] private float goodAnswerScaleMultiplier = 1.2f;
        [SerializeField] private float goodAnswerPunchDuration = 0.5f;


        public float GetWrongAnswerDuration()
        {
            return wrongAnswerDuration;
        }
        public float GetGoodAnswerDuration()
        {
            return goodAnswerPunchDuration;
        }
        public void WrongAnswer(GameObject wrongAnswerObject)
        {
            Vector3 originalLocalPosition = wrongAnswerObject.transform.localPosition;

            Sequence sequence = DOTween.Sequence();

            sequence.Append(wrongAnswerObject.transform.DOLocalMove(originalLocalPosition + new Vector3(-wrongAnswerMoveDistance, 0, 0), wrongAnswerDuration).SetEase(Ease.OutBounce))
                    .Append(wrongAnswerObject.transform.DOLocalMove(originalLocalPosition + new Vector3(wrongAnswerMoveDistance, 0, 0), wrongAnswerDuration).SetEase(Ease.OutBounce))
                    .Append(wrongAnswerObject.transform.DOLocalMove(originalLocalPosition, wrongAnswerDuration).SetEase(Ease.OutBounce));
        }
        public void GoodAnswer(GameObject goodAnswerObject, GameObject starParticlesPrefab)
        {

            goodAnswerObject.transform.DOPunchScale(Vector3.one * goodAnswerScaleMultiplier, goodAnswerPunchDuration, 10, 1);


            GameObject starParticles = Instantiate(starParticlesPrefab, goodAnswerObject.transform.position, Quaternion.identity);
            
            Destroy(starParticles, 2f);
        }
    }
}