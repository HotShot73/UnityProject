using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class AmooSoundScript : MonoBehaviour {

	public static AmooSoundScript Instance;
	public AudioClip amooYadegarPowerUpSound;
	//void Awake()
	//{
		// Register the singleton
		//if (Instance != null)
	//	{
	//		Debug.LogError("Multiple instances of SoundEffectsHelper!");
	//	}
	//	Instance = this;
	//}
	// Use this for initialization

	public void NaveAmooYadegarPowerUpSound(){

		if (!audio.isPlaying) {
			audio.clip = this.amooYadegarPowerUpSound;
			audio.Play ();
		}
	}
//	public void stopAmooYadegar(){
	//	amooYadegarPowerUpSound.Stop ();
	//}
	//private void MakeSound(AudioClip originalClip)
	//{
		// As it is not 3D audio clip, position doesn't matter.
//		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	//}
}
