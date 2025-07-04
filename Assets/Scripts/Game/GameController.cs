using SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController
{
    public class GameController : Singleton<GameController>
    {

        protected override void Awake()
        {
            base.Awake();
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneLoader.Instance.LoadSceneAdditive("SecondScene");
            }
        }
    }
}