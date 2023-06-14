using System;
using System.Collections;
using System.Linq;
using Isometric.Player;
using Item;
using Manager;
using UI;
using UnityEngine;

namespace Isometric
{
  public class GameManager : SingleTon<GameManager>
  {
    public ItemData[] requireItems;
    public Animator start;
    
    private void Start()
    {
      StartCoroutine(Crt());
    }

    private IEnumerator Crt()
    {
      yield return new WaitForSecondsRealtime(1f);
      Dialogue.Instance.Open("9가지 색상의 보석을 모두 가져와라.", 3f);
      yield return new WaitForSecondsRealtime(3.2f);
      Dialogue.Instance.Open("다른 아이템은 E키를 누른 후 우클릭을 하면 시간이 늘어날 것이야.", 5f);
      yield return new WaitForSecondsRealtime(5.2f);
      Dialogue.Instance.Open("큭큭.. 얼른 보물을 찾아오지 않으면 네 목숨은 없을 것이다.", 5f);
      yield return new WaitForSecondsRealtime(5f);
      start.Play("Show");
      Timer.Instance.StartTimer(120f);
    }

    public bool isComplete => requireItems.All(x => PlayerManager.Inventory.HasItem(x));
  }
}