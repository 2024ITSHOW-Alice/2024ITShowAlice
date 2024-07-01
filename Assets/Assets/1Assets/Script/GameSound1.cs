using UnityEngine;

public class GameSound1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameClip;
    public AudioClip hitSoundClip; // 새로운 오디오 클립 추가
    private GameManager gameManager;

    void Start()
    {
        // AudioSource를 가져오거나 없으면 추가하기
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = gameClip; // AudioClip 설정
        audioSource.loop = false; // 필요에 따라 루프 설정
        audioSource.playOnAwake = false; // 시작시 재생하지 않도록 설정
    }

    private void Awake()
    {
        // GameManager 객체 참조 초기화 (필요시)
        gameManager = FindObjectOfType<GameManager>();
    }

    // 노래를 재생하는 메서드
    public void PlaySong()
    {
        if (audioSource != null && gameManager != null)
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

    // Hit 사운드를 재생하는 메서드
    public void PlayHitSound()
    {
        if (audioSource != null && hitSoundClip != null)
        {
            audioSource.PlayOneShot(hitSoundClip); // hitSoundClip 재생
            Debug.Log("Hit sound played");
        }
    }
}
