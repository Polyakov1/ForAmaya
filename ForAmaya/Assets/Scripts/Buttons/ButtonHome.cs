using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Buttons
{
    public class ButtonHome : MonoBehaviour
    {
        private string _scene = "Menu";
        public void GoHome()
        {
            SceneManager.LoadScene(_scene);
        }
    }
}