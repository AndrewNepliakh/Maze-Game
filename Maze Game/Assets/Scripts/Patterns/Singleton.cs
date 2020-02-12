using UnityEngine;

namespace NPLH
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        var singleton = new GameObject("SingletonManager: " + typeof(T));
                        _instance = singleton.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
    }
}

