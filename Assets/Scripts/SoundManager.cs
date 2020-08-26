using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource correctTone;
	public AudioSource incorrectTone;
	public AudioSource suggestedTone;
	public AudioSource completedTone;

	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

	public void PlaySound(SoundEffect type = SoundEffect.SuggestedTone)
    {
		switch (type)
        {
			case SoundEffect.CorrectTone:
				correctTone.Play();
				break;
			case SoundEffect.IncorrectTone:
				incorrectTone.Play();
				break;
			case SoundEffect.SuggestedTone:
				suggestedTone.Play();
				break;
			case SoundEffect.CompletedTone:
				completedTone.Play();
				break;
		}
    }

}
public enum SoundEffect
{
	CorrectTone,
	IncorrectTone,
	SuggestedTone,
	CompletedTone,
}