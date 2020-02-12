using UnityEngine;
using UnityEngine.Events;

namespace NPLH
{
    public abstract class Actor : MonoBehaviour
    {
        public UnityEvent OnSetActive;

        public virtual void OnEnable() 
        {
            OnSetActive?.Invoke();
        }
    }
}

