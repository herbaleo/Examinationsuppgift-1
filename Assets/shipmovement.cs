using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipmovement : MonoBehaviour {

    public float rotationSpeed;
    public float shipSpeed;
    public float slowShipSpeed;
    public SpriteRenderer ship;
    public Color shipBlueColor;
    public Color ShipGreenColor;
    public int Timer;
    public float shipLeftRotationSpeed;
    public Color ShipRandomColor;
    public Transform shipPosition;
    public Transform RandomShipPosition;
    
   
    
    

    // Use this for initialization
    void Start () {
        // Denna variabel bestämmer hur snabbt skeppet svänger.
        rotationSpeed = 4;

        shipBlueColor = new Color(0, 0, 1);
        ShipGreenColor = new Color(0, 1, 0);
        //Denna kod randomisar skeppets position vid start av spelet. 
        RandomShipPosition.position = new Vector3(Random.Range(-10 , 10), Random.Range(-6, 6));

        //Denna kod gör att shipSpeed blir ett värde mellan 1 till 16 och så att slowShipSpeed blir hälften så stor som shipSpeed. 
        shipSpeed = Random.Range(1, 16);
        slowShipSpeed = shipSpeed / 2;
        


    }
	
	// Update is called once per frame
	void Update () {
        /*Denna kod är till för att skeppet svänger höger och blir blått om man trycker på D. Skeppet svänger dubbelt så snabbt om man trycker på D 
        jämfört med A*/
        if (Input.GetKey(KeyCode.D))
        {
            rotationSpeed = 150;
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            ship.color = shipBlueColor;
        }
       
        //Denna kod gör att skeppet svänger vänster och blir blått om man trycker på A. Skeppet svänger dubbelt så långsamt om man trycker på A jämfört med D.
        if (Input.GetKey(KeyCode.A))
        {
            rotationSpeed = 75;
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            ship.color = ShipGreenColor;
        }
        /*Denna kod gör att skeppet åker dubbelt så långsamt. Om jag trycker på S så förlyttas skeppet frammåt med hjälp av slowShipSpeed som i void start 
         * är hälften så stor som shipspeed. Om jag inter trycker på S så åker skeppet framåt med hjälp av shipSPeed vilket är en värde som slumpmässigt
         * tas fram i void start.*/
        if (Input.GetKey(KeyCode.S))
        {
           
            
            transform.Translate((slowShipSpeed) * Time.deltaTime, 0, 0, Space.Self);
        }
        else
            {
           
            transform.Translate((shipSpeed) * Time.deltaTime, 0, 0, Space.Self);
        }
        //Detta är en kod som räknar hur många sekunder man har spelat. Den räknar i riktiga sekunder och den printar en gång varje sekund.

           if (Time.fixedTime == Timer)
        {
            Timer = Timer + 1;
            print("Timer:" + Timer);
        }

        /*Det här är en kod som gör att skeppet får en random färg varje gång man trycker på Space. Den ger ett random värde utav röd, 
        grön och blå färg. Den är helt synlig hela tiden.*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShipRandomColor = new Color( Random.Range(1f, 0f), Random.Range(1f, 0f), Random.Range(1f, 0f), 1.0f );
            ship.color = ShipRandomColor;
        }

        /*  */
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            shipPosition.position = new Vector3(shipPosition.position.x * -1f, shipPosition.position.y);
        }
        if(transform.position.y < -6.5 || transform.position.y > 6.5)
        {
            shipPosition.position = new Vector3(shipPosition.position.x, shipPosition.position.y * -1f);
        }
        
       
    }
}
