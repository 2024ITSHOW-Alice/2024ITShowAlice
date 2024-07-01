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
        // AudioManager가 유일한 인스턴스로 유지되도록 처리
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 다른 AudioManager 인스턴스가 존재하면 파괴
            return;
        }

        // AudioSource 초기 설정
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = mainMusic;
    }

    void Start()
    {
        // 메인 씬에서만 음악 재생
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
        // Scene 로드 시 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Scene 로드 시 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 새로 로드된 Scene이 메인 씬이면 음악 재생, 아니면 음악 정지
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
