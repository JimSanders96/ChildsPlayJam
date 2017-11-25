using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public FloatReference TimerPercentage;

    public List<AudioClip> CoinTosses;
    public List<AudioClip> CoinRotations;

    private AudioSource _tossSource;
    private AudioSource _rotationSource;

	// Use this for initialization
	void Start ()
	{
	    if (_tossSource == null)
	    {
	        _tossSource = gameObject.AddComponent<AudioSource>();
	        _tossSource.playOnAwake = false;
	    }
	        
	    if (_rotationSource == null)
	    {
	        _rotationSource = gameObject.AddComponent<AudioSource>();
	        _rotationSource.playOnAwake = false;
	    }

        

        if (CoinTosses.Count <= 0)
            Debug.LogError("Cointoss needs a reference");
        if (CoinRotations.Count <= 0)
            Debug.LogError("CoinRotation needs a reference");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(TimerPercentage.Value);
	}

    public void PlayCoinToss()
    {
        _tossSource.clip = CoinTosses[CoinTosses.Count - 1];
        _rotationSource.clip = CoinRotations[CoinRotations.Count - 1];
        StartCoroutine(CombineTwoSoundsSources(_tossSource, _rotationSource));
    }

    private IEnumerator CombineTwoSoundsSources(AudioSource firstSource, AudioSource secondSource)
    {
        firstSource.Play();
        yield return new WaitForSeconds(firstSource.clip.length);
        secondSource.Play();
    }

    public void StopSounds()
    {
        _tossSource.Stop();
        _rotationSource.Stop();
    }
}
