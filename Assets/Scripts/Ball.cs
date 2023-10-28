using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Ball : MonoBehaviour {
	private AudioSource mAudioSource;
	public static Ball instance = null;
	public cat2 hodledGO;
	void Awake (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		init ();
	}

	void init(){
		hodledGO = null;
		mAudioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;
		float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
		if (damage >= 10) {
			//GetComponent<AudioSource>().clip = destroySound1;

		}

		if(col.gameObject.tag == Assets.Scripts.Constants.EnemyTag || col.gameObject.tag == Assets.Scripts.Constants.PlayerTag) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0);
			//SoundManager.instance.RandomizeSfx(destroySound1);
			if(!mAudioSource.isPlaying && SoundManager.instance.soundOn){
				float randomPitch = Random.Range(0.8f, 1.8f);
				mAudioSource.pitch = randomPitch;
				mAudioSource.volume = damage/10;
				mAudioSource.Play();

			}

		}else {
			if( SoundManager.instance.soundOn && ( damage > 10) ){
				float randomPitch = Random.Range(0.8f, 1.8f);
				mAudioSource.pitch = randomPitch;
				mAudioSource.volume = damage/(2*10);
				mAudioSource.Play();
			}

		}
		if(!mAudioSource.isPlaying && SoundManager.instance.soundOn ){
			mAudioSource.volume = damage+0.1f;
			mAudioSource.Play();
		}

	}
}
