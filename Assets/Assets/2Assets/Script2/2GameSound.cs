using UnityEngine;

public class GameSound2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameClip;
    public AudioClip radarSoundClip; // 새로운 오디오 클립 추가
    private GameStart gameStart;

    void Start()
    {
        // AudioSource를 가져오거나 없으면 추가하기
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = gameClip; // AudioClip 설정
        audioSource.loop = true; // 필요에 따라 루프 설정
        audioSource.playOnAwake = false; // 시작시 재생하지 않도록 설정
    }

    private void Awake()
    {
        // GameStart 객체 참조 초기화 (필요시)
        gameStart = FindObjectOfType<GameStart>();
    }

    // 노래를 재생하는 메서드
    public void PlaySong()
    {
        if (audioSource != null && gameStart != null && gameStart.GameRunning)
        {
            audioSource.Play();
            Debug.Log("PlaySong called");
        }
    }

    public void PauseSong()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    // Radar 사운드를 재생하는 메서드
    public void PlayRadarSound()
    {
        if (audioSource != null && radarSoundClip != null)
        {
            audioSource.PlayOneShot(radarSoundClip); // radarSoundClip 재생
            Debug.Log("Radar sound played");
        }
    }
}
