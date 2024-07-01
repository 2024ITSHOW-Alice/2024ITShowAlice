using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip mainMusic;
    public string mainSceneName = "Main_Scene";

    void Awake()
    {
        // AudioManager�� ������ �ν��Ͻ��� �����ǵ��� ó��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ٸ� AudioManager �ν��Ͻ��� �����ϸ� �ı�
            return;
        }

        // AudioSource �ʱ� ����
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = mainMusic;
    }

    void Start()
    {
        // ���� �������� ���� ���
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == mainSceneName)
        {
            PlayMusic();
        }
        else
        {
            StopMusic();
        }
    }

    void OnEnable()
    {
        // Scene �ε� �� �̺�Ʈ ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Scene �ε� �� �̺�Ʈ ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �ε�� Scene�� ���� ���̸� ���� ���, �ƴϸ� ���� ����
        if (scene.name == mainSceneName)
        {
            PlayMusic();
        }
        else
        {
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
