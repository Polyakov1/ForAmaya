using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Buttons;

namespace Controllers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levels;
        [SerializeField] private GameObject _prefabButton;
        [SerializeField] private Transform _PosParent;
        [SerializeField] private float _DistanceBetweenBlocks;
        [SerializeField] private AnswerController _answerController;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private Image _fadeImage;
        private int _lvl;

        private void Start()
        {
            _PosParent = gameObject.transform;
        }

        public void LoadLevel(int levelIndex)
        {
            _lvl += levelIndex;

            if (_lvl < 0 || _lvl >= _levels.Length)
            {
                ShowRestartButton();
                return;
            }

            ClearPreviousGrid();
            LevelData currentLevel = _levels[_lvl];
            CreateGrid(currentLevel);
        }

        private void ShowRestartButton()
        {
            _restartButton.SetActive(true);
            StartCoroutine(FadeIn(_fadeImage));
        }

        public void OnRestartButtonClicked()
        {
            StartCoroutine(RestartGame());
        }

        private IEnumerator RestartGame()
        {
            yield return StartCoroutine(FadeOut(_fadeImage));

            _lvl = 0;
            ClearPreviousGrid();
            CreateGrid(_levels[_lvl]);
            _answerController.UpdatePossibleOptions();
            yield return StartCoroutine(FadeIn(_fadeImage));
            _restartButton.SetActive(false);
            _fadeImage.gameObject.SetActive(false); 
        }

        private IEnumerator FadeIn(Image image)
        {
            Color color = image.color;
            color.a = 0;
            image.color = color;
            image.gameObject.SetActive(true);

            while (color.a < 0.5f)
            {
                color.a += Time.deltaTime;
                image.color = color;
                yield return null;
            }
        }

        private IEnumerator FadeOut(Image image)
        {
            Color color = image.color;
            color.a = 0.5f;

            while (color.a > 0)
            {
                color.a -= Time.deltaTime;
                image.color = color;
                yield return null;
            }

            image.gameObject.SetActive(false); 
        }

        private void ClearPreviousGrid()
        {
            foreach (Transform child in _PosParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void CreateGrid(LevelData levelData)
        {
            ArrayList imagesTempInScene = new ArrayList();

            for (int row = 0; row < levelData.GetRows(); row++)
            {
                for (int col = 0; col < levelData.GetColumns(); col++)
                {
                    GameObject cell = Instantiate(_prefabButton, _PosParent); 
                    cell.transform.localPosition = new Vector3(col * _DistanceBetweenBlocks, row * _DistanceBetweenBlocks, 0);

                    Image buttonImage = cell.GetComponentInChildren<Button>().GetComponent<Image>();
                    buttonImage.sprite = _answerController.GiveSprite(_answerController.RandomAnswer());
                    imagesTempInScene.Add(buttonImage.sprite.name);
                }
            }
        


            string[] tempNameImages = new string[imagesTempInScene.Count];
            for (int i = 0; i < imagesTempInScene.Count; i++)
            {
                tempNameImages[i] = (string)imagesTempInScene[i];
            }

            _answerController.SetAnswer(tempNameImages[Random.Range(0, tempNameImages.Length)]);
        }


    }
}
