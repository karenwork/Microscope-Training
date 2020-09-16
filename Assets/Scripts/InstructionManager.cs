using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
	public List<MicroscopePart> instructionSteps = new List<MicroscopePart>();
	private int currentStep = 0;
	private MicroscopePart currentObject;
	private TaptoPlace taptoPlace;

	// Singleton instance.
	public static InstructionManager Instance = null;

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
    private void OnEnable()
    {
		taptoPlace = FindObjectOfType<TaptoPlace>();
    }
    public void NextStep()
    {
		if (taptoPlace.lastSelectedPart == instructionSteps[currentStep])
        {
			instructionSteps[currentStep].Hide();
			Correct();
			if (currentStep == instructionSteps.Count)
			{
				//Completed Microscope Training
				Completed();
				return;
			}
			instructionSteps[++currentStep].Show();
		}
		
    }
	public void Correct()
    {
		SoundManager.Instance.PlaySound(SoundEffect.CorrectTone);
    }
	public void Completed()
    {
		SoundManager.Instance.PlaySound(SoundEffect.CompletedTone);
    }

	public void InCorrect()
    {
		SoundManager.Instance.PlaySound(SoundEffect.IncorrectTone);
    }
}
