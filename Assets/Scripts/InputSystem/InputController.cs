using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace InputSystem
{
    public class InputController : Singleton<InputController>
    {
        private Inputs m_Inputs;
        public bool IsRunning;
        public bool IsInteracting;
        public bool IsWalkLeft;
        public bool IsWalkRight;
        public bool IsWalkForward;
        public bool IsWalkBackward;
        public bool IsPaused;
        public bool IsAlternativeInteracting;

        protected override void Awake()
        {
            base.Awake();
            m_Inputs = new Inputs();
        }

        private void Update()
        {
            GetInputs();
        }
        

        private void GetInputs()
        {
            IsRunning = false;
            IsInteracting = false;
            IsAlternativeInteracting = false;
            if (Input.GetKeyDown(m_Inputs.RunInput))
            {
                IsRunning = true;
            }
            if (Input.GetKeyUp(m_Inputs.RunInput))
            {
                IsRunning = false;
            }
            if (Input.GetKeyDown(m_Inputs.InteractInput))
            {
                IsInteracting = true;
            }
            if (Input.GetKeyUp(m_Inputs.InteractInput))
            {
                IsInteracting = false;
            }
            if (Input.GetMouseButtonDown((int) m_Inputs.AlternativeInteractiveInp))
            {
                IsAlternativeInteracting = true;
            }
            if (Input.GetMouseButtonUp((int)m_Inputs.AlternativeInteractiveInp))
            {
                IsAlternativeInteracting = false;
            }
            if (Input.GetKeyDown(m_Inputs.WalkLeft))
            {
                IsWalkLeft = true;
            }
            if (Input.GetKeyUp(m_Inputs.WalkLeft))
            {
                IsWalkLeft = false;
            }
            if (Input.GetKeyDown(m_Inputs.WalkRight))
            {
                IsWalkRight = true;
            }
            if (Input.GetKeyUp(m_Inputs.WalkRight))
            {
                IsWalkRight = false;
            }
            if (Input.GetKeyDown(m_Inputs.WalkForward))
            {
                IsWalkForward = true;
            }
            if (Input.GetKeyUp(m_Inputs.WalkForward))
            {
                IsWalkForward = false;
            }
            if (Input.GetKeyDown(m_Inputs.WalkBackward))
            {
                IsWalkBackward = true;
            }
            if (Input.GetKeyUp(m_Inputs.WalkBackward))
            {
                IsWalkBackward = false;
            }
            if (Input.GetKeyDown(m_Inputs.PauseInput))
            {
                IsPaused = true;
            }
            if (Input.GetKeyUp(m_Inputs.PauseInput))
            {
                IsPaused = false;
            }
        }

        #region METHODS

        public void SetRunInput(KeyCode key)
        {
            m_Inputs.RunInput = key;
        }
        public void SetWalkRight(KeyCode key)
        {
            m_Inputs.WalkRight = key;
        }
        public void SetWalkLeft(KeyCode key)
        {
            m_Inputs.WalkLeft = key;
        }
        public void SetWalkForward(KeyCode key)
        {
            m_Inputs.WalkForward = key;
        }
        public void SetWalkBackward(KeyCode key)
        {
            m_Inputs.WalkBackward = key;
        }
        public void SetInteractInput(KeyCode key)
        {
            m_Inputs.InteractInput = key;
        }
        public void SetAlternativeInteractiveInp(int mouseNumber)
        {
            m_Inputs.AlternativeInteractiveInp = (KeyCode) mouseNumber;
        }

        public KeyCode GetRunInput()
        {
            return m_Inputs.RunInput;
        }
        public KeyCode GetWalkRight()
        {
            return m_Inputs.WalkRight;
        }
        public KeyCode GetWalkLeft()
        {
            return m_Inputs.WalkLeft;
        }
        public KeyCode GetWalkForward()
        {
            return m_Inputs.WalkForward;
        }
        public KeyCode GetWalkBackward()
        {
            return m_Inputs.WalkBackward;
        }
        public KeyCode GetInteractInput()
        {
            return m_Inputs.InteractInput;
        }
        public KeyCode GetAlternativeInteractiveInp()
        {
            return m_Inputs.AlternativeInteractiveInp;
        }
        public KeyCode GetPauseInput()
        {
            return m_Inputs.PauseInput;
        }
        #endregion
    }
}