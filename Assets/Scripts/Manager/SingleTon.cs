using UnityEngine;

namespace Manager
{
  public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
  {
    public static T Instance { get; private set; }
    
    protected virtual void Awake()
    {
      if (Instance is null) Instance = (T)this;
      else Destroy(gameObject);
    }
  }
}