using UnityEngine;

public class GameSound1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameClip;
    public AudioClip hitSoundClip; // ���ο� ����� Ŭ�� �߰�
    private GameManager gameManager;

    void Start()
    {
        // AudioSource�� �������ų� ������ �߰��ϱ�
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = gameClip; // AudioClip ����
        audioSource.loop = false; // �ʿ信 ���� ���� ����
        audioSource.playOnAwake = false; // ���۽� ������� �ʵ��� ����
    }

    private void Awake()
    {
        // GameManager ��ü ���� �ʱ�ȭ (�ʿ��)
        gameManager = FindObjectOfType<GameManager>();
    }

    // �뷡�� ����ϴ� �޼���
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

    // Hit ���带 ����ϴ� �޼���
    public void PlayHitSound()
    {
        if (audioSource != null && hitSoundClip != null)
        {
            audioSource.PlayOneShot(hitSoundClip); // hitSoundClip ���
            Debug.Log("Hit sound played");
        }
    }
}
