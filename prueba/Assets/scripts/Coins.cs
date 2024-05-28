using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using Unity.Mathematics;
public class Coins : MonoBehaviour
{
    public Rigidbody2D RB;
    public Canvas CANVAS;
    public int COUNTER;
    public int OBJCOUNTER;
    public Button button;
    public Uis Uis;
    public string col;
    public Player mov;
    public TMP_Text Count;
    public int lives = 3;
    [SerializeField] Button retry;
    [SerializeField] Button Gmenu;
    [SerializeField] TMP_Text Gameover;
    [SerializeField] Image image;
    GameObject[] lives_;
    [SerializeField] GameObject[] background_objects;       
    GameObject[] flowers;
    [SerializeField] AudioClip flowerSound;
    [SerializeField] AudioSource background_music;
    [SerializeField] AudioClip gameover_sound;
    [SerializeField] Button ok_orchids;
    [SerializeField] GameObject orchids_text;
    public LevelsData levelsdata;
    [SerializeField] Vector3 KillSpawn;
    [SerializeField] Image LevelWin;
    [SerializeField] Button NextLevel;
    public AudioClip buttonSound;
    [SerializeField] Vector3 L1_spawn;
    [SerializeField] Button Menu;
    [SerializeField] Button restart;
    [SerializeField] Button resume;
    [SerializeField] Button asdMenu;
    [SerializeField] TMP_Text percent;
    [SerializeField] int counterfr;
    [SerializeField] AudioClip levelcompleted;
    public bool pause_enabled;
    private void Awake()
    {
        KillSpawn = GameObject.FindGameObjectWithTag("KillSpawn").transform.position;
        levelsdata = GameObject.FindGameObjectWithTag("LevelsData").GetComponent<LevelsData>();
        flowers = GameObject.FindGameObjectsWithTag("INTOBJ");
        lives_ = GameObject.FindGameObjectsWithTag("live");
        background_objects = GameObject.FindGameObjectsWithTag("Background");
        LeanTween.alpha(image.GetComponent<RectTransform>(), 0f, 1f);
        ok_orchids.onClick.AddListener(orchids_message);
        retry.onClick.AddListener(retry_);
        restart.onClick.AddListener(retry_);
        resume.onClick.AddListener(mov.Setup_toggle);
        Menu.onClick.AddListener(menu_);
        NextLevel.onClick.AddListener(NextLevel_);
        asdMenu.onClick.AddListener(menu_);
        Gmenu.onClick.AddListener(menu_);
        if (GameObject.Find("D1") != null)
        {
            levelsdata.CounterLevel1 = 0;
        }
        if (GameObject.Find("D2") != null)
        {
            levelsdata.CounterLevel2 = 0;
        }
        if (GameObject.Find("D3") != null)
        {
            levelsdata.CounterLevel3 = 0;
        }
    }
   void LevelScreen()
    {
        if (GameObject.Find("D3") != null)
        {
            SoundController.Instance.PlaySound(levelcompleted);
            background_music.gameObject.SetActive(false);
            RB.constraints = RigidbodyConstraints2D.FreezePositionX;
            LeanTween.moveX(LevelWin.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutSine);
            Menu.transform.position = NextLevel.transform.position;
            mov.movX = false;
            NextLevel.gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
        }
        else
        {
            SoundController.Instance.PlaySound(levelcompleted);
            background_music.gameObject.SetActive(false);
            NextLevel.gameObject.SetActive(true);
            Menu.gameObject.SetActive(true);
            RB.constraints = RigidbodyConstraints2D.FreezePositionX;
            LeanTween.moveX(LevelWin.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutSine);
            mov.movX = false;
        }
    }
    void NextLevel_()
    {
        SceneManager.LoadScene("Level"+(levelsdata.Clevel+2));
        levelsdata.Clevel += 1;
    }
    void orchids_message()
    {
        orchids_text.gameObject.SetActive(false);
        mov.movX = true;
    }
    public void COINF(int value)
    {

        COUNTER = +value;
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        flowers = GameObject.FindGameObjectsWithTag("INTOBJ");
        if (collision.name == "D1"&&flowers.Length==0)
        {
            if (levelsdata.Levels != 1 && levelsdata.Levels < 1)
            {
                levelsdata.Levels = 1;
            }
            DataControllerScript.Instance.SaveData();
            Debug.Log("no_text");
            Debug.Log(flowers.Length);
            LevelScreen();
            Debug.Log("NL");
        }
        else if(collision.name == "D1")
        {
            orchids_text.gameObject.SetActive(true);
            Debug.Log("orchids");
            mov.movX = false;
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
        }
        if (collision.name == "D2" && flowers.Length == 0)
        {
            if (levelsdata.Levels != 2 && levelsdata.Levels < 2)
            {
                levelsdata.Levels = 2;
            }
            DataControllerScript.Instance.SaveData();
            Debug.Log("no_text");
            Debug.Log(flowers.Length);
            LevelScreen();
            Debug.Log("NL");
        }
        else if (collision.name == "D2")
        {
            orchids_text.gameObject.SetActive(true);
            Debug.Log("orchids");
            mov.movX = false;
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
        }
        if (collision.name == "D3" && flowers.Length == 0)
        {
            if (levelsdata.Levels != 2 && levelsdata.Levels < 2)
            {
                levelsdata.Levels = 2;
            }
            DataControllerScript.Instance.SaveData();
            Debug.Log("no_text");
            Debug.Log(flowers.Length);
            LevelScreen();
            Debug.Log("NL");
            percent.text = "Sabes un "+math.round((levelsdata.CounterLevel1 + levelsdata.CounterLevel2 + levelsdata.CounterLevel3)*3.3333f)+"% de colombia!!".ToString();
        }
        else if (collision.name == "D3")
        {
            orchids_text.gameObject.SetActive(true);
            Debug.Log("orchids");
            mov.movX = false;
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
        }
        if (collision.tag == "kills")
        {
            if (lives == 1)
            {
                gameObject.transform.position = KillSpawn;
                background_music.enabled = false;
                SoundController.Instance.PlaySound(gameover_sound);
                mov.RB.constraints = RigidbodyConstraints2D.FreezePositionX;
                LeanTween.alpha(image.GetComponent<RectTransform>(), 255f, 1f);
                LeanTween.moveY(Gameover.GetComponent<RectTransform>(), 290, 1f).setEase(LeanTweenType.easeInOutSine);
                
            }
            else
            {
                LeanTween.alpha(image.GetComponent<RectTransform>(), 255f, 1f);
                LeanTween.alpha(image.GetComponent<RectTransform>(), 0f, 1f);
            }
            Background script;
            for (int a = 0; a < background_objects.Length; a++)
            {
                Debug.Log(a);
                GameObject Current_object;
                Current_object = background_objects[a];
                script = Current_object.GetComponent<Background>();
                script.material.mainTextureOffset = new Vector2(0, 0);
            }
            lives--;
            SoundController.Instance.PlaySound(mov.die);
            
            
                gameObject.transform.position = L1_spawn;
            if (lives == 0) {
                gameObject.transform.position = KillSpawn;
                    };
            mov.cam.transform.position = new Vector3(transform.position.x, transform.position.y, -15f);
        }
        if (collision.tag == "INTOBJ")
        {
            SoundController.Instance.PlaySound(flowerSound);
            col = collision.gameObject.name;
            Destroy(collision.gameObject);
            mov.movX = false;
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
            CANVAS.gameObject.SetActive(true);
            if (collision.gameObject.name == "f1")
            {
                Uis.trex.text = "¿Cual es el nombre oficial del aeropuerto principal de Bogota y en honor a quien fue nombrado?";
                Uis.AA.text = "“Aeropuerto Internacional El Dorado” Ciudad de oro de la mitología colombiana.";
                Uis.AB.text = "“Aeropuerto Internacional El Dorado” Leyenda de Colombiana";
            }
            if (collision.gameObject.name == "f2")
            {
                Uis.trex.text = "¿Cual es el nombre del cerro mas alto que rodea la ciudad de Bogota y cual es su altura?";
                Uis.AA.text = "Cerro de Guadalupe.";
                Uis.AB.text = "Cerro de Monserrate.";
            }
            if (collision.gameObject.name == "f3")
            {
                Uis.trex.text = "¿Cuando fue fundada oficialmente la ciudad de Bogota?";
                Uis.AB.text = "1538.";
                Uis.AA.text = "1610";
            }
            if (collision.gameObject.name == "f4")
            {
                Uis.trex.text = "¿Cuál es el nombre del museo más visitado de Bogotá y qué exhibe\r\nprincipalmente?";
                Uis.AB.text = "Museo Nacional de Colombia, que exhibe arte e historia del\r\npaís.";
                Uis.AA.text = "Museo del Oro, que exhibe una de las colecciones de oro\r\nprehispánico más grandes del mundo.";
            }
            if (collision.gameObject.name == "f5")
            {
                Uis.trex.text = "¿Cuál es la principal plaza pública de Bogotá y qué importante edificio\r\ngubernamental se encuentra en ella?";
                Uis.AB.text = "Plaza de Bolívar, donde se encuentra el Capitolio Nacional.";
                Uis.AA.text = "Plaza de la Concordia, donde se encuentra el Palacio\r\nPresidencial.";
            }
            if (collision.gameObject.name == "f6")
            {
                Uis.trex.text = "¿Qué icónico evento de teatro se celebra en Bogotá cada dos años y es conocido\r\ninternacionalmente?";
                Uis.AB.text = "Festival Iberoamericano de Teatro de Bogotá.";
                Uis.AA.text = "Festival Internacional de Danza de Bogotá.";
            }
            if (collision.gameObject.name == "f7")
            {
                Uis.trex.text = "¿Cuál es el parque más grande de Bogotá y qué actividades recreativas se\r\npueden hacer allí?";
                Uis.AB.text = "Parque Metropolitano Simón Bolívar, donde se pueden hacer\r\npicnic, montar en bicicleta y disfrutar de conciertos al aire libre.";
                Uis.AA.text = "Parque de los Novios, donde se puede pescar y pasear en bote.";
            }
            if (collision.gameObject.name == "f8")
            {
                Uis.trex.text = "¿Cuál es la avenida más larga de Bogotá y cuántos kilómetros recorre?";
                Uis.AB.text = "Avenida Boyacá, que recorre aproximadamente 39 kilómetros.";
                Uis.AA.text = "Avenida Caracas, que recorre aproximadamente 18 kilómetros.";
            }
            if (collision.gameObject.name == "f9")
            {
                Uis.trex.text = "¿Qué famoso escritor colombiano, ganador del Premio Nobel de Literatura,\r\nvivió y estudió en Bogotá?";
                Uis.AB.text = "Jorge Isaacs.";
                Uis.AA.text = "Gabriel García Márquez.";
            }
            if (collision.gameObject.name == "f10")
            {
                Uis.trex.text = "¿Cuál es el nombre del mercado más antiguo y tradicional de Bogotá, conocido\r\npor su gastronomía y productos frescos?";
                Uis.AB.text = "Mercado de Paloquemao.";
                Uis.AA.text = "Mercado de Usaquén.";
            }
            if(collision.gameObject.name == "H1")
            {
                Uis.trex.text = "¿Cuál es el nombre del castillo más famoso de Cartagena y en qué siglo fue construido?";
                Uis.AA.text = "Castillo de San Felipe de Barajas, construido en el siglo XVII.";
                Uis.AB.text = "Castillo de Santa Catalina, construido en el siglo XVIII.";
            }
            if (collision.gameObject.name == "H2")
            {
                Uis.trex.text = "¿Qué famoso festival de cine se celebra anualmente en Cartagena?";
                Uis.AA.text = "Festival Internacional de Cine de Cartagena de Indias (FICCI).";
                Uis.AB.text = "Festival de Cine Colombiano.";
            }
            if (collision.gameObject.name == "H3")
            {
                Uis.trex.text = "¿Cuál es el nombre del barrio histórico de Cartagena conocido por su arquitectura\r\ncolonial y sus coloridas casas?";
                Uis.AB.text = "Getsemaní.";
                Uis.AA.text = "Manga.";
            }
            if (collision.gameObject.name == "H4")
            {
                Uis.trex.text = "¿Qué monumento en Cartagena honra a los héroes de la independencia de Colombia?";
                Uis.AB.text = "Monumento a los Mártires de la Independencia.";
                Uis.AA.text = "Monumento a los Zapatos Viejos.";
            }
            if (collision.gameObject.name == "H5")
            {
                Uis.trex.text = "¿Cuál es la playa más popular de Cartagena y por qué es famosa?";
                Uis.AA.text = "Playa Blanca, famosa por su arena blanca y aguas cristalinas.";
                Uis.AB.text = "Playa de Bocagrande, famosa por sus resorts y vida nocturna.";
            }
            if (collision.gameObject.name == "H6")
            {
                Uis.trex.text = "¿Qué icónica torre en Cartagena es un símbolo de la ciudad y se encuentra en la entrada\r\ndel centro histórico?";
                Uis.AB.text = "Torre del Reloj.";
                Uis.AA.text = "Torre de la Catedral.";
            }
            if (collision.gameObject.name == "H7")
            {
                Uis.trex.text = "¿Cuál es el nombre del famoso autor que escribió &quot;El amor en los tiempos del cólera&quot; y\r\ncuya historia se desarrolla en Cartagena?";
                Uis.AA.text = "Gabriel García Márquez.";
                Uis.AB.text = "Álvaro Mutis.";
            }
            if (collision.gameObject.name == "H8")
            {
                Uis.trex.text = "¿Qué importante puerto colonial, declarado Patrimonio de la Humanidad por la\r\nUNESCO, se encuentra en Cartagena?";
                Uis.AB.text = "Puerto de Santa Marta.";
                Uis.AA.text = "Puerto de Cartagena.";
            }
            if (collision.gameObject.name == "H9")
            {
                Uis.trex.text = "¿Cuál es el nombre del parque nacional que abarca islas y aguas circundantes cerca de\r\nCartagena?";
                Uis.AB.text = "Parque Nacional Natural Tayrona.";
                Uis.AA.text = "Parque Nacional Natural Corales del Rosario y de San Bernardo.";
            }
            if (collision.gameObject.name == "H10")
            {
                Uis.trex.text = "¿Qué evento anual en Cartagena celebra las culturas africanas y afrodescendientes con\r\nmúsica, danza y arte?";
                Uis.AA.text = "Festival de Música del Caribe.";
                Uis.AB.text = "Festival de la Cultura Afrocaribeña.";
            }
            if(collision.gameObject.name == "A1")
            {
                Uis.trex.text = "¿Cuál es el nombre del río más importante que atraviesa la región del Amazonas en\r\nColombia?";
                    Uis.AA.text = "Río Putumayo.";
                     Uis.AB.text = "Río Amazonas.";
            }
            if (collision.gameObject.name == "A2")
            {
                Uis.trex.text = "¿Qué ciudad es conocida como la puerta de entrada al Amazonas colombiano?";
                Uis.AA.text = "Leticia.";
                Uis.AB.text = "Puerto Nariño.";
            }
            if (collision.gameObject.name == "A3")
            {
                Uis.trex.text = "¿Cuál es el nombre del encuentro de las tres fronteras en el Amazonas colombiano y qué\r\npaíses se unen allí?";
                Uis.AA.text = "Tres Fronteras; Colombia, Brasil y Perú.";
                Uis.AB.text = "Triple Frontera; Colombia, Venezuela y Brasil.";
            }
            if (collision.gameObject.name == "A4")
            {
                Uis.trex.text = "¿Qué famoso delfín de río se puede avistar en las aguas del Amazonas colombiano?";
                Uis.AA.text = "Delfín rosado (Inia geoffrensis).";
                Uis.AB.text = "Delfín gris (Sotalia fluviatilis).";
            }
               if (collision.gameObject.name == "A5")
                {
                    Uis.trex.text = "¿Qué parque nacional en el Amazonas colombiano es hogar de una increíble\r\nbiodiversidad y es considerado Patrimonio de la Humanidad por la UNESCO?";
                    Uis.AA.text = "Parque Nacional Natural Amacayacu.";
                    Uis.AB.text = "Parque Nacional Natural Serranía de Chiribiquete.";
                }
                if (collision.gameObject.name == "A6")
                {
                    Uis.trex.text = "¿Qué comunidad indígena en el Amazonas colombiano es conocida por su habilidad en la fabricación de cerbatanas y arcos?";
                    Uis.AA.text = "Comunidad Tikuna.";
                    Uis.AB.text = "Comunidad Yagua.";
                }
                if (collision.gameObject.name == "A7")
                {
                    Uis.trex.text = "¿Qué comunidad indígena en el Amazonas colombiano es conocida por sus\r\nconocimientos ancestrales sobre plantas medicinales?";
                    Uis.AA.text = "Comunidad Tikuna.";
                    Uis.AB.text = "Comunidad Huitoto.";
                }
                if (collision.gameObject.name == "A8")
                {
                    Uis.trex.text = "¿Cuál es la mejor época del año para visitar el Amazonas colombiano y por qué?";
                    Uis.AA.text = "Junio a septiembre, por ser la temporada seca y facilitar el turismo.";
                    Uis.AB.text = "Diciembre a marzo, por ser la temporada de lluvias y permitir la\r\nnavegación en áreas más remotas.";
                }
                if (collision.gameObject.name == "A9")
                {
                    Uis.trex.text = "";
                    Uis.AA.text = "Caminatas nocturnas..";
                    Uis.AB.text = "Observación de aves al amanecer.";
                }
                if (collision.gameObject.name == "A10")
                {
                    Uis.trex.text = "¿Cuál es el nombre del festival cultural que celebra la diversidad indígena en el\r\nAmazonas colombiano y cuándo se celebra?";
                    Uis.AA.text = "Festival de las Colonias, en agosto.";
                    Uis.AB.text = "Festival de la Confraternidad Amazónica, en julio.";
                }
            
        }
    }
void retry_()
    {
        SoundController.Instance.PlaySound(buttonSound);
        SceneManager.LoadScene("Level"+(levelsdata.Clevel+1), LoadSceneMode.Single);
    }
void menu_()
    {
        Debug.Log("aaaa");
        SoundController.Instance.PlaySound(buttonSound);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    private void Update()
    {
        foreach (GameObject i in lives_)
        {
            if (lives == 2)
            {
                if (i.name == "3")
                {

                    i.SetActive(false);
                }
            }

            if (lives == 1)
            {
                if (i.name == "2")
                {
                    i.SetActive(false);
                }
            }

            else if (lives == 1)
            {
                if (i.name == "2")
                {
                    i.SetActive(false);
                }
            }
            if (lives == 0)
            {
                i.SetActive(false);
                Console.WriteLine("GameOver");
            }

            Count.text = OBJCOUNTER.ToString() + "/10";
        }
    }
}
