using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    static volatile T instance = null; // volatile -> Degiskenin degerinin direkt bellekten alinmasini saglar.

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected void Singleton(bool dontDestroy = false)
    {
        if (dontDestroy)
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (instance == null)
            {
                instance = this as T;
            }
        }
    }
}