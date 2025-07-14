using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Clock
{
    public class ClockController : MonoBehaviour
    {
        [SerializeField] private int m_Hours = 0;
        [SerializeField] private int m_Minutes = 0;
        [SerializeField] private int m_Day = 0;

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

        public int Hours { get => m_Hours; }
        public int Minutes { get => m_Minutes;}
        public int Day { get => m_Day;}

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
                m_Minutes++;
                if (m_Minutes >= 60)
                {
                    m_Minutes = 0;
                    m_Hours++;
                    HourEvent?.Invoke();
                }
                if (m_Hours >= 24)
                {
                    m_Hours = 0;
                    m_Day++;
                    DayEvent?.Invoke();
                }
            }
        }
    }
}