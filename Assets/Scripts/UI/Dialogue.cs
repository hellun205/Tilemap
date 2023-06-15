using System.Collections;
using Manager;
using TMPro;
using UnityEngine;

namespace UI
{
  public sealed class Dialogue : SingleTon<Dialogue>
  {
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private TextMeshProUGUI tmp;

    public bool isActive;
    
    public void Open(string text, float time)
    {
      if (isActive) return;
      tmp.text = text;
      StartCoroutine(Animation(time));
    }

    private IEnumerator Animation(float time)
    {
      isActive = true;
      anim.Play("Open");
      yield return new WaitForSecondsRealtime(time);
      anim.Play("Close");
      isActive = false;
    }
  }
}