using System;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class Timer : SingleTon<Timer>
  {
    public event Action OnTimerEnd;
    public Image progress;

    public float timer;
    public float maxTime = 60;

    public bool isActive = false;

    private void Update()
    {
      if (isActive == true)
      {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
          isActive = false;
          OnTimerEnd?.Invoke();
        }
      }
      progress.fillAmount = timer / maxTime;
    }

    public void StartTimer(float max)
    {
      maxTime = max;
      timer = maxTime;
      isActive = true;
    }

    public void AddTime(float amount) => timer += amount;
    
    
  }
}