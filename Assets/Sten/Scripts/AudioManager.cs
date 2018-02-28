using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum musicTrack { gameSound = 0 };
public enum environmentalSound { ambience = 0 };
public enum uiSounds { cameraSwitch1 = 0, cameraSwitch2  };
public enum interactionSounds { chopTree1 = 0, chopTree2, pushBox, fallBox, grow1, grow2, grow3, enterLever, exitLever,
                                dropSword1, dropSword2, pickUp, shrink1, shrink2, shrink3, switch1, deur1, deur2, deur3,
                                deur4, deur5, stairs, key, attack1, attack2, attack3 };

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
    [SerializeField]
    private AudioSource SFX2;
    [SerializeField]
    private AudioSource SFX3;
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
            musicTracks.loop = true;
            musicTracks.volume = 0.5f;

        }
        else {
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
            environmentalSounds.loop = true;
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

        interactionSounds.clip = interactionSoundsList[(int)sound];
        interactionSounds.Play();

        // Check if this audiosource is available
        if (!interactionSounds.isPlaying) {
            interactionSounds.clip = interactionSoundsList[(int)sound];
            interactionSounds.Play();
        }
        else if (!SFX2.isPlaying)
        {
            SFX2.clip = interactionSoundsList[(int)sound];
            SFX2.Play();
        }
        else if (!SFX3.isPlaying)
        {
            SFX3.clip = interactionSoundsList[(int)sound];
            SFX3.Play();
        }
        else {
            StartCoroutine(waitForInteractionSound(sound));
        }
        
        return interactionSounds;
    }

    // Second AudioSource for interaction sounds
    public AudioSource interactionSound2(interactionSounds sound)
    {
        SFX2.clip = interactionSoundsList[(int)sound];
        SFX2.Play();

        // Check if this audiosource is available
        if (!SFX2.isPlaying)
        {
            SFX2.clip = interactionSoundsList[(int)sound];
            SFX2.Play();
        }

        return SFX2;
    }

    // Third AudioSource for interaction sounds
    public AudioSource interactionSound3(interactionSounds sound)
    {
        SFX3.clip = interactionSoundsList[(int)sound];
        SFX3.Play();

        // Check if this audiosource is available
        if (!SFX3.isPlaying)
        {
            SFX3.clip = interactionSoundsList[(int)sound];
            SFX3.Play();
        }

        return SFX3;
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
   

