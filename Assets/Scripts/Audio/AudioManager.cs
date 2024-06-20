using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource tuyulSource;
    [SerializeField] AudioSource pocongSource;
    [SerializeField] AudioSource kuntiSource;
    [SerializeField] AudioSource bossSource;
    [SerializeField] AudioSource detakSource;
    [SerializeField] AudioSource detakHardSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip playerWalk;
    public AudioClip tuyul;
    public AudioClip pocong;
    public AudioClip kunti;
    public AudioClip boss;
    public AudioClip sampah;
    public AudioClip detak;
    public AudioClip detakHard;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    //==============================================
    public void PlayLoopedSFX(AudioClip clip)
    {
        if (SFXSource.clip != clip)
        {
            SFXSource.clip = clip;
            SFXSource.loop = true;
            SFXSource.Play();
        }
    }
    public void StopLoopedSFX()
    {
        if (SFXSource.loop)
        {
            SFXSource.Stop();
            SFXSource.loop = false;
            SFXSource.clip = null;
        }
    }

    //==============================================
    public void PlayTuyulSFX(AudioClip clip)
    {
        if (tuyulSource.clip != clip)
        {
            tuyulSource.clip = clip;
            tuyulSource.loop = true;
            tuyulSource.Play();
        }
    }

    public void StopTuyulSFX()
    {
        if (tuyulSource.loop)
        {
            tuyulSource.Stop();
            tuyulSource.loop = false;
            tuyulSource.clip = null;
        }
    }

    //==============================================
    public void PlayPocongSFX(AudioClip clip)
    {
        if (pocongSource.clip != clip)
        {
            pocongSource.clip = clip;
            pocongSource.loop = true;
            pocongSource.Play();
        }
    }

    public void StopPocongSFX()
    {
        if (pocongSource.loop)
        {
            pocongSource.Stop();
            pocongSource.loop = false;
            pocongSource.clip = null;
        }
    }
    //==============================================
    public void PlayKuntiSFX(AudioClip clip)
    {
        if (kuntiSource.clip != clip)
        {
            kuntiSource.clip = clip;
            kuntiSource.loop = true;
            kuntiSource.Play();
        }
    }

    public void StopKuntiSFX()
    {
        if (kuntiSource.loop)
        {
            kuntiSource.Stop();
            kuntiSource.loop = false;
            kuntiSource.clip = null;
        }
    }
    //==============================================
    public void PlayBossSFX(AudioClip clip)
    {
        if (bossSource.clip != clip)
        {
            bossSource.clip = clip;
            bossSource.loop = true;
            bossSource.Play();
        }
    }

    public void StopBossSFX()
    {
        if (bossSource.loop)
        {
            bossSource.Stop();
            bossSource.loop = false;
            bossSource.clip = null;
        }
    }
    //==============================================

    public void PlayDetakSFX(AudioClip clip)
    {
        if (detakSource.clip != clip)
        {
            detakSource.clip = clip;
            detakSource.loop = true;
            detakSource.Play();
        }
    }

    public void StopDetakSFX()
    {
        if (detakSource.loop)
        {
            detakSource.Stop();
            detakSource.loop = false;
            detakSource.clip = null;
        }
    }

    //==============================================
    public void PlayDetakHardSFX(AudioClip clip)
    {
        if (detakHardSource.clip != clip)
        {
            detakHardSource.clip = clip;
            detakHardSource.loop = true;
            detakHardSource.pitch = 1.5f;
            detakHardSource.Play();
        }
    }

    public void StopDetakHardSFX()
    {
        if (detakHardSource.loop)
        {
            detakHardSource.Stop();
            detakHardSource.loop = false;
            detakHardSource.clip = null;
            detakHardSource.pitch = 1.0f;
        }
    }
    //==============================================
    //==============================================
    //==============================================
    //==============================================
    //==============================================
}
