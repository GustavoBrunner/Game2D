using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Clock
{
    public class ClockController : MonoBehaviour
    {
        [SerializeField] private int Hours = 0;
        [SerializeField] private int Minutes = 0;
        [SerializeField] private int Day = 0;

        [SerializeField] private float ClockSpeed = 1f;

        private bool m_isClockRunning = false;

        [SerializeField] UnityEvent HourEvent;
        [SerializeField] UnityEvent DayEvent;
        public bool IsClockRunning { get => m_isClockRunning; 
            set 
            { 
                m_isClockRunning = value; 
                if (m_isClockRunning)
                {
                    StartCoroutine(Clock());
                }
                else
                {
                    StopCoroutine(Clock());
                }
            } 
        }

        private void LateUpdate()
        {
            if (Input.GetKeyUp(KeyCode.O))
            {
                IsClockRunning = !m_isClockRunning;
            }
        }
        public IEnumerator Clock()
        {
            while (m_isClockRunning)
            {
                yield return new WaitForSeconds(1f/ClockSpeed);
                Minutes++;
                if (Minutes >= 60)
                {
                    Minutes = 0;
                    Hours++;
                    HourEvent?.Invoke();
                }
                if (Hours >= 24)
                {
                    Hours = 0;
                    Day++;
                    DayEvent?.Invoke();
                }
            }
        }
    }
}