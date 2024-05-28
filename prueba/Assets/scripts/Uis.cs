using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;
public class Uis : MonoBehaviour
{
    public TMP_Text trex;
    public TMP_Text AA;
    public TMP_Text AB;
   public Button AButton;
    public Button BButton;
    public Canvas canvas;
    public Coins script;
    public Canvas PrUi;
    [SerializeField] Image correct_image;
    [SerializeField] Image incorrect_image;
    [SerializeField] TMP_Text correct_text;
    [SerializeField] AudioClip correct_;
    [SerializeField] AudioClip incorrect_;
    [SerializeField] Button OK;
    [SerializeField] AudioClip button_sound;
    [SerializeField] CanvasGroup screen1;
    void Start()
    {
        script.mov.enabled = false;
        PrUi.gameObject.SetActive(false);
        AButton.onClick.AddListener(A_onclick);
        BButton.onClick.AddListener(B_onclick);
        OK.onClick.AddListener(OK_);
    }
    void Update()
    {
        if (GameObject.Find("D3") == null)
        {
            script.mov.cam.transform.position = script.mov.transform.localPosition + new Vector3(0, 2, -10);
        }
    }
    void A_onclick()
    {
        Debug.Log("a");
        if (script.col == "f1")
        {
            correct_text.text = "En la mitologia colombiana, \"El Dorado\" es una leyenda sobre una ciudad de oro. Los lideres" +
                " indigenas realizaban ceremonias cubriendose con polvo de oro. Aunque los conquistadores buscaron la ciudad, nunca la encontraron. Esta leyenda inspiro el " +
                "nombre del Aeropuerto Internacional El Dorado en Bogota.\r\n";
            correct();
        }
        if (script.col == "f2")
        {
            correct_text.text = "El cerro mas alto que rodea la ciudad de Bogota es el \"Cerro de Guadalupe\"" +
                ", con una altura aproximada de 3,300 metros sobre el nivel del mar. Desde su cima, se puede disfrutar de una vista" +
                " impresionante de la ciudad.\r\n";
            correct();
        }
        if (script.col == "f3")
        {
            correct_text.text = "La ciudad de Bogota fue fundada oficialmente en el 1538. Desde entonces, ha crecido hasta" +
                " convertirse en una metropoli vibrante y culturalmente rica en el corazon de Colombia.";
            incorrect();
        }
        if (script.col == "f4")
        {
            correct_text.text = "El museo más visitado de Bogotá es el Museo del Oro, que exhibe una de las colecciones de oro prehispánico más grandes del mundo.Este museo ofrece una fascinante visión de las culturas indígenas de Colombia antes de la llegada de los europeos.";
            correct();
        }
        if (script.col == "f5")
        {
            correct_text.text = "La principal plaza pública de Bogotá es la Plaza de Bolívar, y en ella se encuentra el Capitolio Nacional.Esta plaza es un lugar central para eventos públicos y manifestaciones en la ciudad.";
            correct();
        }
        if (script.col == "f6")
        {
            correct_text.text = "El icónico evento de teatro que se celebra en Bogotá cada dos\r\naños es el Festival Iberoamericano de Teatro de Bogotá. Este festival es\r\nconocido internacionalmente y atrae a compañías teatrales de todo el mundo.";
            incorrect();
        }
        if (script.col == "f7")
        {
            correct_text.text = "El parque más grande de Bogotá es el Parque Metropolitano\r\nSimón Bolívar. En este parque, se pueden hacer picnic, montar en bicicleta y\r\ndisfrutar de conciertos al aire libre, entre muchas otras actividades\r\nrecreativas.";
            incorrect();
        }
        if (script.col == "f8")
        {
            correct_text.text = "La avenida más larga de Bogotá es la Avenida Boyacá, que\r\nrecorre aproximadamente 39 kilómetros de norte a sur a través de la ciudad.\r\nEs una de las arterias principales para el tránsito vehicular.";
            incorrect();
        }
        if (script.col == "f9")
        {
            correct_text.text = "El famoso escritor colombiano, ganador del Premio Nobel de\r\nLiteratura, que vivió y estudió en Bogotá es Gabriel García Márquez. Su\r\nestancia en la ciudad influyó en varias de sus obras literarias.";
            correct();
        }
        if (script.col == "f10")
        {
            correct_text.text = "El mercado más antiguo y tradicional de Bogotá es el Mercado de Paloquemao.Es conocido por su variada gastronomía y la frescura de sus productos, siendo un lugar icónico para los habitantes de la ciudad y turistas.";
            incorrect();
        }
         if(script.col == "H1")
        {
            correct_text.text = "El castillo más famoso de Cartagena es el Castillo de San Felipe de\r\nBarajas, construido en el siglo XVII. Es una de las fortificaciones más\r\nimpresionantes de América Latina.";
            correct();
        }
        if (script.col == "H2")
        {
            correct_text.text = "El famoso festival de cine que se celebra anualmente en Cartagena es\r\nel Festival Internacional de Cine de Cartagena de Indias (FICCI). Es el festival de\r\ncine más antiguo de América Latina.";
            correct();
        }
        if (script.col == "H3")
        {
            correct_text.text = "El barrio histórico de Cartagena conocido por su arquitectura colonial\r\ny sus coloridas casas es Getsemaní. Es un lugar vibrante y lleno de historia.";
            incorrect();
        }
        if (script.col == "H4")
        {
            correct_text.text = "El monumento en Cartagena que honra a los héroes de la\r\nindependencia de Colombia es el Monumento a los Mártires de la Independencia,\r\nubicado en la Plaza de los Coches.";
            incorrect();
        }
        if (script.col == "H5")
        {
            correct_text.text = "La playa más popular de Cartagena es Playa Blanca, famosa por su\r\narena blanca y aguas cristalinas, siendo un destino preferido por turistas y locales.";
            correct();
        }
        if (script.col == "H6")
        {
            correct_text.text = "La icónica torre en Cartagena que es un símbolo de la ciudad y se\r\nencuentra en la entrada del centro histórico es la Torre del Reloj. Es uno de los\r\npuntos de referencia más reconocibles de Cartagena.";
            incorrect();
        }
        if (script.col == "H7")
        {
            correct_text.text = "El famoso autor que escribió &quot;El amor en los tiempos del cólera&quot; y\r\ncuya historia se desarrolla en Cartagena es Gabriel García Márquez. Sus\r\ndescripciones de la ciudad capturan su magia y encanto.";
            correct();
        }
        if (script.col == "H8")
        {
            correct_text.text = "El importante puerto colonial declarado Patrimonio de la Humanidad\r\npor la UNESCO que se encuentra en Cartagena es el Puerto de Cartagena. Es un\r\nsitio histórico de gran relevancia.";
            correct();
        }
        if (script.col == "H9")
        {
            correct_text.text = "El parque nacional que abarca islas y aguas circundantes cerca de\r\nCartagena es el Parque Nacional Natural Corales del Rosario y de San Bernardo. Es\r\nconocido por su biodiversidad marina y belleza natural.";
            correct();
        }
        if (script.col == "H10")
        {
            correct_text.text = "El evento anual en Cartagena que celebra las culturas africanas y\r\nafrodescendientes con música, danza y arte es el Festival de la Cultura Afrocaribeña. Es\r\nuna celebración vibrante de la herencia cultural de la región.";
            incorrect();
        }
        if (script.col == "A1")
        {
            correct_text.text = "El río más importante que atraviesa la región del Amazonas en\r\nColombia es el Río Amazonas. Es el río más largo y caudaloso del mundo, vital para\r\nla biodiversidad y las comunidades locales.";
            incorrect();
        }
        if (script.col == "A2")
        {
            correct_text.text = "La ciudad conocida como la puerta de entrada al Amazonas\r\ncolombiano es Leticia. Es la capital del departamento del Amazonas y un punto de\r\npartida para explorar la selva amazónica.";
            correct();
        }
        if (script.col == "A3")
        {
            correct_text.text = "El encuentro de las tres fronteras en el Amazonas colombiano se\r\nllama Tres Fronteras, donde se unen Colombia, Brasil y Perú. Es un punto de\r\nconfluencia cultural y comercial entre los tres países.";
            correct();
        }
        if (script.col == "A4")
        {
            correct_text.text = "El famoso delfín de río que se puede avistar en las aguas del\r\nAmazonas colombiano es el delfín rosado (Inia geoffrensis). Es conocido por su\r\ndistintivo color y su inteligencia.";
            correct();
        }
        if (script.col == "A5")
        {
            correct_text.text = "El parque nacional en el Amazonas colombiano que es hogar de una\r\nincreíble biodiversidad y es considerado Patrimonio de la Humanidad por la\r\n\r\nUNESCO es el Parque Nacional Natural Serranía de Chiribiquete. Es famoso por sus\r\ntepuyes y arte rupestre.";
            incorrect();
        }
        if (script.col == "A6")
        {
            correct_text.text = "La comunidad indígena en el Amazonas colombiano conocida por su habilidad en la fabricación de cerbatanas y arcos es la Comunidad Yagua. Estos utensilios tradicionales son fundamentales para su subsistencia y actividades de caza.";
            incorrect();
        }
        if (script.col == "A7")
        {
            correct_text.text = "La comunidad indígena en el Amazonas colombiano conocida por sus\r\nconocimientos ancestrales sobre plantas medicinales es la Comunidad Huitoto.\r\nSus saberes son fundamentales para la medicina tradicional de la región.";
            incorrect();
        }
        if (script.col == "A8")
        {
            correct_text.text = "La mejor época del año para visitar el Amazonas colombiano es de\r\njunio a septiembre, ya que es la temporada seca y facilita el turismo, haciendo\r\nmás accesibles los senderos y actividades al aire libre.";
            correct();
        }
        if (script.col == "A9")
        {
            correct_text.text = "La actividad eco-turística popular en el Amazonas colombiano que\r\npermite a los visitantes conocer la vida silvestre nocturna es la caminata nocturna.\r\nOfrece la oportunidad de observar criaturas que solo son activas durante la noche.";
            correct();
        }
        if (script.col == "A10")
        {
            correct_text.text = "El festival cultural que celebra la diversidad indígena en el Amazonas\r\ncolombiano es el Festival de la Confraternidad Amazónica, que se celebra en julio. Es un\r\nevento lleno de música, danza y tradiciones indígenas.";
            incorrect();
        }
    }
    void    B_onclick()
    {
        Debug.Log("b");
        if (script.col == "f1")
        {
            correct_text.text = "En la mitologia colombiana, \"El Dorado\" es una leyenda sobre una ciudad de oro. Los lideres" +
                " indigenas realizaban ceremonias cubriendose con polvo de oro. Aunque los conquistadores buscaron la ciudad, nunca la encontraron. Esta leyenda inspiro el " +
                "nombre del Aeropuerto Internacional El Dorado en Bogota.\r\n";
            incorrect();
        }
        if (script.col == "f2")
        {
            correct_text.text = "El cerro mas alto que rodea la ciudad de Bogota es el \"Cerro de Guadalupe\"" +
                ", con una altura aproximada de 3,300 metros sobre el nivel del mar. Desde su cima, se puede disfrutar de una vista" +
                " impresionante de la ciudad.\r\n";
            incorrect();
        }
        if (script.col == "f3")
        {
            correct_text.text = "La ciudad de Bogota fue fundada oficialmente en el 1538. Desde entonces, ha crecido hasta" +
                " convertirse en una metropoli vibrante y culturalmente rica en el corazon de Colombia.";
            correct();
        }
        if (script.col == "f4")
        {
            correct_text.text = "El museo más visitado de Bogotá es el Museo del Oro, que exhibe una de las colecciones de oro prehispánico más grandes del mundo.Este museo ofrece una fascinante visión de las culturas indígenas de Colombia antes de la llegada de los europeos.";
            incorrect();
        }
        if (script.col == "f5")
        {
            correct_text.text = "La principal plaza pública de Bogotá es la Plaza de Bolívar, y en ella se encuentra el Capitolio Nacional.Esta plaza es un lugar central para eventos públicos y manifestaciones en la ciudad.";
            correct();
        }
        if (script.col == "f6")
        {
            correct_text.text = "El icónico evento de teatro que se celebra en Bogotá cada dos\r\naños es el Festival Iberoamericano de Teatro de Bogotá. Este festival es\r\nconocido internacionalmente y atrae a compañías teatrales de todo el mundo.";
            correct();
        }
        if (script.col == "f7")
        {
            correct_text.text = "El parque más grande de Bogotá es el Parque Metropolitano\r\nSimón Bolívar. En este parque, se pueden hacer picnic, montar en bicicleta y\r\ndisfrutar de conciertos al aire libre, entre muchas otras actividades\r\nrecreativas.";
            correct();
        }
        if (script.col == "f8")
        {
            correct_text.text = "La avenida más larga de Bogotá es la Avenida Boyacá, que\r\nrecorre aproximadamente 39 kilómetros de norte a sur a través de la ciudad.\r\nEs una de las arterias principales para el tránsito vehicular.";
            correct();
        }
        if (script.col == "f9")
        {
            correct_text.text = "El famoso escritor colombiano, ganador del Premio Nobel de\r\nLiteratura, que vivió y estudió en Bogotá es Gabriel García Márquez. Su\r\nestancia en la ciudad influyó en varias de sus obras literarias.";
            incorrect();
        }
        if (script.col == "f10")
        {
            correct_text.text = "El mercado más antiguo y tradicional de Bogotá es el Mercado de Paloquemao.Es conocido por su variada gastronomía y la frescura de sus productos, siendo un lugar icónico para los habitantes de la ciudad y turistas.";
            correct();
        }
        if (script.col == "H1")
        {
            correct_text.text = "El castillo más famoso de Cartagena es el Castillo de San Felipe de\r\nBarajas, construido en el siglo XVII. Es una de las fortificaciones más\r\nimpresionantes de América Latina.";
            incorrect();
        }
        if (script.col == "H2")
        {
            correct_text.text = "El famoso festival de cine que se celebra anualmente en Cartagena es\r\nel Festival Internacional de Cine de Cartagena de Indias (FICCI). Es el festival de\r\ncine más antiguo de América Latina.";
            incorrect();
        }
        if (script.col == "H3")
        {
            correct_text.text = "El barrio histórico de Cartagena conocido por su arquitectura colonial\r\ny sus coloridas casas es Getsemaní. Es un lugar vibrante y lleno de historia.";
            correct();
        }
        if (script.col == "H4")
        {
            correct_text.text = "El monumento en Cartagena que honra a los héroes de la\r\nindependencia de Colombia es el Monumento a los Mártires de la Independencia,\r\nubicado en la Plaza de los Coches.";
            correct();
        }
        if (script.col == "H5")
        {
            correct_text.text = "La playa más popular de Cartagena es Playa Blanca, famosa por su\r\narena blanca y aguas cristalinas, siendo un destino preferido por turistas y locales.";
            incorrect();
        }
        if (script.col == "H6")
        {
            correct_text.text = "La icónica torre en Cartagena que es un símbolo de la ciudad y se\r\nencuentra en la entrada del centro histórico es la Torre del Reloj. Es uno de los\r\npuntos de referencia más reconocibles de Cartagena.";
            correct();
        }
        if (script.col == "H7")
        {
            correct_text.text = "El famoso autor que escribió &quot;El amor en los tiempos del cólera&quot; y\r\ncuya historia se desarrolla en Cartagena es Gabriel García Márquez. Sus\r\ndescripciones de la ciudad capturan su magia y encanto.";
            incorrect();
        }
        if (script.col == "H8")
        {
            correct_text.text = "El importante puerto colonial declarado Patrimonio de la Humanidad\r\npor la UNESCO que se encuentra en Cartagena es el Puerto de Cartagena. Es un\r\nsitio histórico de gran relevancia.";
            incorrect();
        }
        if (script.col == "H9")
        {
            correct_text.text = "El parque nacional que abarca islas y aguas circundantes cerca de\r\nCartagena es el Parque Nacional Natural Corales del Rosario y de San Bernardo. Es\r\nconocido por su biodiversidad marina y belleza natural.";
            incorrect();
        }
        if (script.col == "H10")
        {
            correct_text.text = "El evento anual en Cartagena que celebra las culturas africanas y\r\nafrodescendientes con música, danza y arte es el Festival de la Cultura Afrocaribeña. Es\r\nuna celebración vibrante de la herencia cultural de la región.";
            correct();
        }
        if (script.col == "A1")
        {
            correct_text.text = "El río más importante que atraviesa la región del Amazonas en\r\nColombia es el Río Amazonas. Es el río más largo y caudaloso del mundo, vital para\r\nla biodiversidad y las comunidades locales.";
            correct();
        }
        if (script.col == "A2")
        {
            correct_text.text = "La ciudad conocida como la puerta de entrada al Amazonas\r\ncolombiano es Leticia. Es la capital del departamento del Amazonas y un punto de\r\npartida para explorar la selva amazónica.";
            incorrect();
        }
        if (script.col == "A3")
        {
            correct_text.text = "El encuentro de las tres fronteras en el Amazonas colombiano se\r\nllama Tres Fronteras, donde se unen Colombia, Brasil y Perú. Es un punto de\r\nconfluencia cultural y comercial entre los tres países.";
            incorrect();
        }
        if (script.col == "A4")
        {
            correct_text.text = "El famoso delfín de río que se puede avistar en las aguas del\r\nAmazonas colombiano es el delfín rosado (Inia geoffrensis). Es conocido por su\r\ndistintivo color y su inteligencia.";
            incorrect();
        }
        if (script.col == "A5")
        {
            correct_text.text = "El parque nacional en el Amazonas colombiano que es hogar de una\r\nincreíble biodiversidad y es considerado Patrimonio de la Humanidad por la\r\n\r\nUNESCO es el Parque Nacional Natural Serranía de Chiribiquete. Es famoso por sus\r\ntepuyes y arte rupestre.";
           correct();
        }
        if (script.col == "A6")
        {
            correct_text.text = "La comunidad indígena en el Amazonas colombiano conocida por su habilidad en la fabricación de cerbatanas y arcos es la Comunidad Yagua. Estos utensilios tradicionales son fundamentales para su subsistencia y actividades de caza.";
            correct();
        }
        if (script.col == "A7")
        {
            correct_text.text = "La comunidad indígena en el Amazonas colombiano conocida por sus\r\nconocimientos ancestrales sobre plantas medicinales es la Comunidad Huitoto.\r\nSus saberes son fundamentales para la medicina tradicional de la región.";
            correct();
        }
        if (script.col == "A8")
        {
            correct_text.text = "La mejor época del año para visitar el Amazonas colombiano es de\r\njunio a septiembre, ya que es la temporada seca y facilita el turismo, haciendo\r\nmás accesibles los senderos y actividades al aire libre.";
            incorrect();
        }
        if (script.col == "A9")
        {
            correct_text.text = "La actividad eco-turística popular en el Amazonas colombiano que\r\npermite a los visitantes conocer la vida silvestre nocturna es la caminata nocturna.\r\nOfrece la oportunidad de observar criaturas que solo son activas durante la noche.";
            incorrect();
        }
        if (script.col == "A10")
        {
            correct_text.text = "El festival cultural que celebra la diversidad indígena en el Amazonas\r\ncolombiano es el Festival de la Confraternidad Amazónica, que se celebra en julio. Es un\r\nevento lleno de música, danza y tradiciones indígenas.";
            correct();
        }
    }
    void correct() {
        script.OBJCOUNTER += 1;
        SoundController.Instance.PlaySound(correct_);
        if (GameObject.Find("D1") != null)
        {
            script.levelsdata.CounterLevel1 += 1;
        }
        if (GameObject.Find("D2") != null)
        {
            script.levelsdata.CounterLevel2 += 1;
        }
        if (GameObject.Find("D3") != null)
        {
            script.levelsdata.CounterLevel3 += 1;
        }
        Debug.Log("correct");
        correct_image.gameObject.SetActive(true);
        correct_text.gameObject.SetActive(true);
        screen1.gameObject.SetActive(false);
    }
    void incorrect()
    {
        script.OBJCOUNTER += 1;
        SoundController.Instance.PlaySound(incorrect_);
        Debug.Log("incorrect");
        incorrect_image.gameObject.SetActive(true);
        correct_text.gameObject.SetActive(true);
        screen1.gameObject.SetActive(false);
    }
    void OK_()
    {
        script.mov.movX = true;
        SoundController.Instance.PlaySound(button_sound);
        screen1.gameObject.SetActive(true);
        correct_image.gameObject.SetActive(false);
        incorrect_image.gameObject.SetActive(false);
        correct_text.gameObject.SetActive(false);
        script.mov.RB.constraints = RigidbodyConstraints2D.None;
        script.mov.enabled = true;
        PrUi.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }
}
