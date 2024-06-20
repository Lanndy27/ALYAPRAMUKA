using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class SampahManager2D : MonoBehaviour
{
    public GameObject LevelTransition;
    public float waktuHilang = 2.0f;
    public float jarakMaksimum = 2.0f;
    public int totalSampah = 4;
    public Transform player;

    private GameObject sampahTerpilih;
    private Animator animatorSampah;
    private Coroutine coroutineHilang;
    private List<GameObject> sampahTerkumpul = new List<GameObject>();

    public TextMeshProUGUI labelSampahText;
    public TextMeshProUGUI listSampahText;

    public bool semuaSampahTerkumpul = false;

    AudioManager audioManager;

    public LoadingBarController loadingBarController;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public bool SampahTerkumpulLengkap()
    {
        return sampahTerkumpul.Count == totalSampah;
    }

    public void SetSemuaSampahTerkumpul()
    {
        semuaSampahTerkumpul = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CariSampahTerdekat();
            if (sampahTerpilih != null)
            {
                // Play the sampah collection sound
                audioManager.PlaySFX(audioManager.sampah);
                HilangkanSampahTerpilih();
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            HilangkanSampahTerpilih();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (sampahTerpilih != null && coroutineHilang != null)
            {
                StopCoroutine(coroutineHilang);
                animatorSampah.SetFloat("FadeAmount", 0f);
                sampahTerkumpul.Remove(sampahTerpilih);
                loadingBarController.ShowLoadingBar(false); // Sembunyikan loading bar jika pengambilan dihentikan
            }

            sampahTerpilih = null;
            coroutineHilang = null;
        }

        UpdateSampahTerkumpulText();
    }

    void CariSampahTerdekat()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.position, jarakMaksimum);
        float jarakTerdekat = jarakMaksimum;
        GameObject sampahTerdekat = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Sampah"))
            {
                float jarak = Vector2.Distance(collider.transform.position, player.position);
                if (jarak < jarakTerdekat)
                {
                    jarakTerdekat = jarak;
                    sampahTerdekat = collider.gameObject;
                }
            }
        }

        sampahTerpilih = sampahTerdekat;
        if (sampahTerpilih != null)
        {
            animatorSampah = sampahTerpilih.GetComponent<Animator>();
        }
    }

    void HilangkanSampahTerpilih()
    {
        if (sampahTerpilih != null)
        {
            float jarakDariPlayer = Vector2.Distance(sampahTerpilih.transform.position, player.position);

            if (jarakDariPlayer <= jarakMaksimum)
            {
                if (coroutineHilang == null)
                {
                    animatorSampah.SetFloat("FadeAmount", 1f);
                    coroutineHilang = StartCoroutine(HilangkanSampah(sampahTerpilih));
                    loadingBarController.ShowLoadingBar(true); // Tampilkan loading bar saat sampah mulai diambil
                }
            }
            else
            {
                animatorSampah.SetFloat("FadeAmount", 0f);
                sampahTerpilih = null;
                coroutineHilang = null;
            }
        }
    }

    IEnumerator HilangkanSampah(GameObject sampah)
    {
        float waktuSisa = waktuHilang;
        while (waktuSisa > 0)
        {
            float jarakDariPlayer = Vector2.Distance(sampah.transform.position, player.position);

            if (jarakDariPlayer > jarakMaksimum)
            {
                // Reset sampah jika jarak player terlalu jauh
                animatorSampah.SetFloat("FadeAmount", 0f);
                sampahTerkumpul.Remove(sampah);
                sampahTerpilih = null;
                coroutineHilang = null;
                loadingBarController.ShowLoadingBar(false); // Sembunyikan loading bar jika pengambilan dibatalkan
                yield break;
            }

            // Update loading bar progress
            float progress = (waktuHilang - waktuSisa) / waktuHilang;
            loadingBarController.UpdateLoadingBar(sampah.transform.position, progress);

            yield return null;
            waktuSisa -= Time.deltaTime;
        }

        sampahTerkumpul.Add(sampah);
        Destroy(sampah);

        animatorSampah.SetFloat("FadeAmount", 0f);

        sampahTerpilih = null;
        coroutineHilang = null;

        loadingBarController.ShowLoadingBar(false); // Sembunyikan loading bar setelah sampah diambil

        UpdateSampahTerkumpulText();
    }

    void UpdateSampahTerkumpulText()
    {
        if (listSampahText != null)
        {
            int jumlahSampahTerkumpul = sampahTerkumpul.Count;
            string textSampahTerkumpul;

            if (jumlahSampahTerkumpul < totalSampah)
            {
                textSampahTerkumpul = jumlahSampahTerkumpul + "/" + totalSampah;
            }
            else
            {
                textSampahTerkumpul = "Complete";

                
                if (LevelTransition != null)
                {
                    LevelTransition.SetActive(true); // Mengaktifkan objek levelExit
                }
            }

            listSampahText.SetText(textSampahTerkumpul);
        }
    }
}