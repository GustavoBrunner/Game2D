using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class Inputs
    {
        public KeyCode RunInput { get; set; }
        public KeyCode WalkRight { get; set; }
        public KeyCode WalkLeft { get; set; }
        public KeyCode WalkForward { get; set; }
        public KeyCode WalkBackward { get; set; }
        public KeyCode InteractInput { get; set; }
        public KeyCode AlternativeInteractiveInp { get; set; } 
        public KeyCode PauseInput { get; set; }


        public Inputs()
        {
            RunInput = KeyCode.LeftShift;
            WalkRight = KeyCode.D;
            WalkLeft = KeyCode.A;
            WalkForward = KeyCode.W;
            WalkBackward = KeyCode.S;
            InteractInput = KeyCode.E;
            AlternativeInteractiveInp = 0;
            PauseInput = KeyCode.Escape;
        }

    }
}

