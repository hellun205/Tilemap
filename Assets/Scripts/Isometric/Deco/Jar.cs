using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Isometric.Player;
using Item;
using UI;
using UnityEngine;
using Utils;

namespace Isometric.Deco
{
  public class Jar : InteractableObject
  {
    public List<CountableItem> items;

    [SerializeField]
    private Item itemPrefab;

    [SerializeField]
    private Transform trans;

    [SerializeField]
    private Animator anim;

    private bool isRemoving = false;

    public override void Interact()
    {
      base.Interact();
      if (isRemoving) return;
      if (items.Count > 0)
      {
        anim.Play("None");
        anim.Play("Interact");
        var r = items.Random();
        StartCoroutine(Throw(r.item));
        isInteractable = false;

        if (r.count == 1)
          items.Remove(r);
        else
          r.count--;
      }

      if (items.Count == 0)
      {
        isRemoving = true;
        StartCoroutine(Remove());
      }
    }

    public override void Exit()
    {
      base.Exit();
    }

    private IEnumerator Throw(ItemData itemData)
    {
      var item = Instantiate(itemPrefab, trans.position, new Quaternion(0, 0, 0, 0));
      item.item = itemData;
      item.rb.gravityScale = 0.5f;
      item.rb.AddForce(new Vector2(Random.Range(-1f, 1f), 5f).normalized * 100f);
      yield return new WaitForSeconds(Random.Range(0.5f, 1f));
      item.rb.gravityScale = 0f;
      item.rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private IEnumerator Remove()
    {
      anim.Play("Remove");
      yield return new WaitForSeconds(1f);
      Destroy(gameObject,2f);
      gameObject.SetActive(false);
    }
  }
}