using System;
using System.Collections;
using System.Linq;
using Isometric.Deco;
using Isometric.Player;
using Item;
using Manager;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Isometric
{
  public sealed class GameManager : SingleTon<GameManager>
  {
    public ItemData[] requireItems;
    public Animator start;

    [SerializeField]
    private GameObject completePanel;
    
    [SerializeField]
    private GameObject failPanel;

    private void Start()
    {
      StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
      yield return new WaitForSecondsRealtime(1f);
      Dialogue.Instance.Open($"{requireItems.Length}가지 색상의 보석을 모두 가져와라.", 3f);
      yield return new WaitForSecondsRealtime(3.2f);
      Dialogue.Instance.Open("다른 아이템은 E키를 누른 후 우클릭을 하면 시간이 늘어날 것이야.", 5f);
      yield return new WaitForSecondsRealtime(5.2f);
      Dialogue.Instance.Open("큭큭.. 얼른 보물을 찾아오지 않으면 네 목숨은 없을 것이다.", 5f);
      yield return new WaitForSecondsRealtime(5f);
      start.Play("Show");
      Timer.Instance.OnTimerEnd += TimerEnd;
      Timer.Instance.StartTimer(120f);
    }

    public bool isComplete => requireItems.All(x => PlayerManager.Inventory.HasItem(x));

    public void CompleteMission(Cat cat)
    {
      StartCoroutine(CompleteRoutine(cat));
    }

    private IEnumerator CompleteRoutine(Cat cat)
    {
      yield return new WaitForSecondsRealtime(1f);
      Dialogue.Instance.Open("헉.. 다 모아온 것이냐..", 2f);
      yield return new WaitForSecondsRealtime(2.2f);
      Dialogue.Instance.Open("나의 패배군.. 큭", 2f);
      yield return new WaitForSecondsRealtime(2.2f);
      cat.anim.Play("Brake");
      yield return new WaitForSecondsRealtime(2f);
      Time.timeScale = 0f;
      completePanel.SetActive(true);
    }

    public void Restart()
    {
      SceneManager.LoadScene("Scenes/Play");
    }

    private void TimerEnd()
    {
      StartCoroutine(FailRoutine());
    }
    
    private IEnumerator FailRoutine()
    {
      yield return new WaitForSecondsRealtime(1f);
      Dialogue.Instance.Open($"큭큭 결국 다 찾지 못하였군...", 2f);
      yield return new WaitForSecondsRealtime(2.2f);
      Dialogue.Instance.Open("너의 목숨은 없다.", 1.5f);
      yield return new WaitForSecondsRealtime(1.7f);
      Time.timeScale = 0f;
      failPanel.SetActive(true);
    }
  }
}