using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum musicTrack { startScreenSound = 0, level1Sound, level2Sound, level3Sound, level4Sound, level5Sound, gameOverSound, menuSound };
public enum environmentalSound { };
public enum uiSounds { openMenu = 0, callSwitch, textOpen, textCloses };
public enum interactionSounds {pickupSound=0,woodDropSound, stoneDropSound,glassDropSound,steelDropSound};

public class AudioManager : MonoBehaviour {

    //Music. Main theme, level sounds etc.
    [SerializeField]
    private AudioSource musicTracks;
    //Sound effects like rocks breaking, triggers clicked
    [SerializeField]
    private AudioSource environmentalSounds;
    //Extra gamewide sounds used mainly in combination with the UI
    [SerializeField]
    private AudioSource uiSounds;
    //Interaction sounds. Pick up something, break something, stab something etc. all as a consequence to the X button
    [SerializeField]
    private AudioSource interactionSounds;
    //Transition sound
    [SerializeField]
    private AudioSource transitionSoundSource;

    //List containing all the music tracks
    [SerializeField]
    private List<AudioClip> musicList = new List<AudioClip>();
    //List containing all the sounds
    [SerializeField]
    private List<AudioClip> environmentalSoundList = new List<AudioClip>();
    //List containing all the ui sounds
    [SerializeField]
    private List<AudioClip> uiList = new List<AudioClip>();
    //List containing special sounds
    [SerializeField]
    private List<AudioClip> interactionSoundsList = new List<AudioClip>();
    //Audioclip containing transition sound
    [SerializeField]
    private List<AudioClip> transitionSound;


    //MUSIC TRACKS
    public AudioSource soundTrack(musicTrack song) {
        if (!musicTracks.isPlaying) {
            musicTracks.clip = musicList[(int)song];
            musicTracks.Play();
        }else {
            StartCoroutine(waitForSoundTrack(song));
        }     
        return musicTracks;
    }
    IEnumerator waitForSoundTrack(musicTrack song) {
        yield return new WaitWhile(() => musicTracks.isPlaying);
        musicTracks.clip = musicList[(int)song];
        musicTracks.Play();
    }

    //ENVIRONMENTAL SOUNDS
    public AudioSource ambianceSoundTrack(environmentalSound sound) {
        if (!environmentalSounds.isPlaying) {
            environmentalSounds.clip = environmentalSoundList[(int)sound];
            environmentalSounds.Play();
        }
        else {
            StartCoroutine(waitForEnvironmentalTrack(sound));
        }
        return environmentalSounds;
    }
    IEnumerator waitForEnvironmentalTrack(environmentalSound sound) {
        yield return new WaitWhile(() => environmentalSounds.isPlaying);
        environmentalSounds.clip = environmentalSoundList[(int)sound];
        environmentalSounds.Play();
    }

    //UI SOUNDS
    public AudioSource uiSoundTrack(uiSounds sound) {
        if (!uiSounds.isPlaying) {
            uiSounds.clip = uiList[(int)sound];
            uiSounds.Play();
        }
        else {
            StartCoroutine(waitForUITrack(sound));
        }
        return uiSounds;
    }
    IEnumerator waitForUITrack(uiSounds sound) {
        yield return new WaitWhile(() => uiSounds.isPlaying);
        uiSounds.clip = uiList[(int)sound];
        uiSounds.Play();
    }
    
    //Interaction Sounds
    public AudioSource interactionSound(interactionSounds sound) {
        if (!interactionSounds.isPlaying) {
            interactionSounds.clip = interactionSoundsList[(int)sound];
            interactionSounds.Play();
        }
        else {
            StartCoroutine(waitForInteractionSound(sound));
        }
        return interactionSounds;
    }
    IEnumerator waitForInteractionSound(interactionSounds sound) {
        yield return new WaitWhile(() => interactionSounds.isPlaying);
        interactionSounds.clip = interactionSoundsList[(int)sound];
        interactionSounds.Play();
    }

    public AudioSource playTransitionSound() {
        transitionSoundSource.Play();
        return transitionSoundSource;
    }
}
   

