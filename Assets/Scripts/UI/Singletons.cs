using System;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
	private static T _instance;

	/// <summary>
	/// This will be create a new game object if instance is null
	/// So if you want to check this null, use bool 'Initialized' instead.
	/// </summary>
	public static T Instance {
		get {
			if (_instance != null) return _instance;
			_instance = (new GameObject(typeof(T).Name)).AddComponent<T>();
			return _instance;
		}
	}

	/// <summary>
	/// Use for checking whether Instance is null or not. 
	/// <para>Use "if (Initialized)" instead of "if (Instance != null)"</para>
	/// </summary>
	public static bool Initialized => _instance != null;

	protected virtual bool DontDestroy => false;

	protected virtual void OnAwake() { }

	private void Awake() {
		if (_instance == null) {
			_instance = this as T;
		}
		else if (_instance != this as T) {
			Destroy(gameObject);
			return;
		}

		if (DontDestroy) DontDestroyOnLoad(gameObject);

		OnAwake();
	}


	///<summary>Call 'T.Instance.Preload()' at the first application script to preload the service.</summary>
	public virtual void Preload() { }
}

public class SingletonBehaviourDontDestroy<T> : SingletonBehaviour<T> where T : MonoBehaviour {
	protected override bool DontDestroy => true;
}