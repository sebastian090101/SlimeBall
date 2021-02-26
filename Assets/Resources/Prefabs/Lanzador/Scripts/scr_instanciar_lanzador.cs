using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Mathematics.math;

public class scr_instanciar_lanzador : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{

    // Variables de uso continuo
    int contador = 0, aux = 0;
    public Vector3 mousepos_update = Vector3.zero;
    public Vector3 posicion_inicial = Vector3.zero;
    Vector3 obj_lanzador_XYZ_camera = Vector3.zero;
    GameObject padre, padre_child_flecha;
    RectTransform rt;
    AudioSource Controler_AS;

    private void Start()
    {
        padre = GameObject.Find("Lanzar");
        padre_child_flecha = padre.transform.GetChild(1).gameObject;
        rt = padre_child_flecha.GetComponent<RectTransform>();
        Controler_AS = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Update()
    {
        // poscicion de un objeto del Canvas en la Main Camera
        obj_lanzador_XYZ_camera = Camera.main.ScreenToWorldPoint(padre.transform.GetChild(3).transform.position);
    }

    public void OnPointerDown(PointerEventData data)
    {
        posicion_inicial = padre.transform.position;
        //posicion_inicial = new Vector3(padre.transform.GetChild(1).transform.position.x, padre.transform.GetChild(1).transform.position.y, 50.0f);
    }

    public void OnDrag(PointerEventData data)
    {

        // posicion del mouse en el arrastre
        mousepos_update = new Vector3(data.position.x, data.position.y, 50.0f);
        // obtenemos el vector del mouse/lanzador
        float x = mousepos_update.x - posicion_inicial.x;
        float y = mousepos_update.y - posicion_inicial.y;
        Vector3 vector_resultante = new Vector3(x, y, padre.transform.up.z);

        float height = Mathf.Sqrt(pow(vector_resultante.x, 2) + pow(vector_resultante.y, 2));
        
        // girar al padre
        padre.transform.up = new Vector3 (  Mathf.Clamp(x / height, -0.800f , 0.800f),
                                            Mathf.Clamp(y / height, 0.600f, 1.00f),
                                            padre.transform.up.z);
        
        //activamos la flecha, cambiamos su height y listo              
        padre_child_flecha.SetActive(true);
        rt.sizeDelta = new Vector2(10, height/5);      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (padre.GetComponent<scr_lanzador>().bolitas >0)
        {
            contador = padre.GetComponent<scr_lanzador>().bolitas;
            aux = contador;
            StartCoroutine("Instanciar_Bolita");
        }
        
        padre_child_flecha.SetActive(false);
        
    }

    IEnumerator Instanciar_Bolita()
    {
        // esperar si no es la primera vez
        if ( aux != contador){
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            yield return null;
        }
        // instaciar bolita, restar 1 en el contador del obj padre y en el auxiliar interno de la funcion
        Instantiate(Resources.Load<GameObject>("Prefabs/Lanzador/Prefab_Player/Player"),
                                       obj_lanzador_XYZ_camera,
                                       Quaternion.identity,
                                       GameObject.Find("Obstaculos").transform);
        padre.GetComponent<scr_lanzador>().cambiar_numero_rebotador(false);
        Controler_AS.PlayOneShot((AudioClip)Resources.Load("Sounds/disparo"));
        aux--;

        // Repetir si tenemos mas bolitas
        if(aux > 0)
        {
            StartCoroutine("Instanciar_Bolita");
        }

    }

    
}
