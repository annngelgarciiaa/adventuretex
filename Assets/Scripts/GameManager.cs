using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Librer�a para acceder a los componentes de la UI
using TMPro; //Librer�a para poder acceder a los TextMeshPro

public class GameManager : MonoBehaviour
{
    //Con esto podemos acceder al Texto de TextMeshPro de la UI
    [SerializeField] TextMeshProUGUI textComponent;

    //Referencia de tipo State (osea de la clase State), que usamos para poder acceder a las variables y m�todos del script State
    State currentState;//Este estado ir� cambiando conforme avanza el juego

    //Ser� el estado inicial en el que empieza el juego
    [SerializeField] State startingState;
   // [SerializeField] imagen imagenComponent;

    // Start is called before the first frame update
    void Start()
    {
        //El estado actual ser� el estado inicial del juego
        currentState = startingState;
        //Accedemos al componente text dentro del textComponent(StoryText) y metemos lo que haya dentro del campo storyText del estado actual
        textComponent.text = currentState.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        //Llamamos al m�todo que gestiona los cambios de estado
        ManageState();
    }

    private void ManageState()
    {
        //Variable indefinida en su tipo que se puede agrandar para acoger los datos
        //var statesArray= currentState.GetNextStates();
        //Generamos un array de estados, donde guardamos los estados a los que podemos ir desde el estado actual en el que estamos
        State[] statesArray = currentState.GetNextStates();

        //Si pulsamos la tecla 1 del teclado
        /*if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Del estado en el que est� pasa al siguiente estado que est� en la posici�n 0 del array
            currentState = statesArray[0];
        }
        //Si pulsamos la tecla 2 del teclado
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Del estado en el que est� pasa al siguiente estado que est� en la posici�n 0 del array
            currentState = statesArray[1];
        }
        //Si pulsamos la tecla 3 del teclado
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Del estado en el que est� pasa al siguiente estado que est� en la posici�n 0 del array
            currentState = statesArray[2];
        }*/

        //Con esto podemos prescindir de los if-else independientemente de cuantos estados hayan
        for(int index = 0; index < statesArray.Length; index++)
        {
            //Alpha1 + index, cambiar� de n�mero al pulsar cada vez
            if(Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                //Del estado en el que est� pasa al siguiente estado que est� en la posici�n 0 del array
                currentState = statesArray[index];
            }
        }

        //Accedemos al componente text dentro del textComponent(StoryText) y metemos lo que haya dentro del campo storyText del estado actual
        textComponent.text = currentState.GetStateStory();
    }
}
