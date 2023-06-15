using System.Collections;
using UI;
using UnityEngine;

namespace Isometric.Deco
{
  public sealed class Cat : InteractableObject
  {
    public Animator anim;
    
    public override void Interact()
    {
      base.Interact();
      if (GameManager.Instance.isComplete)
      {
        GameManager.Instance.CompleteMission(this);
      }
      else
      {
        Dialogue.Instance.Open("얼른 찾는 것이 좋을 것이야.", 2f);  
      }
    }

    private IEnumerator Crt()
    {
      Dialogue.Instance.Open("아닛! 모든 보물을 찾다니... 나의 패배군..", 3f);
      Timer.Instance.isActive = false;
      yield return new WaitForSeconds(3.2f);
      anim.Play("Brake");
    }
  }
}