/*
:Final integration with GUI (Transmitter)
:Author: Bernard C.
:License: MarketSolvers
:Revision: v1.1
:Serves Target 1 only, for multi-target please clone a copy and tweak the data sent accordingly.
*/

#include <SPI.h>
#include <RF24.h>
#include <RF24Network.h>

RF24 radio (9,10); //CE, CSN (change this if you connect the radio module differently)
RF24Network network(radio);

//Define your network nodes
const uint16_t master_node = 00; //Arduino station/receiver address
const uint16_t target1 = 01; //Target 1 address
//const uint16_t target2 = 02; //Target 2 address (Remember to comment Target 1)
unsigned long incomingData = 00; //Data to be sent to Arduino station/receiver

//Sensors and Piezo Pin
//Current plan for transmitter: Connect to 2 vibration sensors.
int vibrPin_A = A1; //Vibration sensor 1
int vibrPin_B = A2; //Vibration sensor 2
int piezoPin = 8; //Beep if target hits.
int sensitivity = 800; //Initial vibration sensor sensitivity (Will change according to GUI input)

//Wobbling flag
//When bullet hits target, the target "shaking" effect may trick the system that it is another hit
//This state variable ensures only bullet impact is recorded.
int state = 1; 


//Multi-tasking (Refer to Arduino Multi-Task tutorial on millis()
unsigned long previousTime = 0;
long readTime = 10; //10ms read once
long writeTime = 5; //5ms send sensor data once

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  SPI.begin();
  radio.begin();
  //To upload codes to target 2, remember to comment target 1's declaration
  network.begin(90, target1);
  //network.begin(90, target2);

  pinMode(vibrPin_A,INPUT);
  pinMode(vibrPin_B,INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  network.update(); //Updates radio network.
  unsigned long currentTime = millis();
  long measurement_A = TP_init_A();
  long measurement_B = TP_init_B();  

  //Write Mode
  if (currentTime - previousTime >= writeTime){
    //For 2 sensors (final)
    //if ((measurement_A > sensitivity) && (measurement_B > sensitivity && state == 1)){
    //For 1 sensor only (testing)
    if ((measurement_A > sensitivity) && state == 1){
      //Hit data = 11 or 22
      RF24NetworkHeader header2(master_node);
      unsigned long data_sent = 11; //Change to 22 for target 2
      network.write(header2, &data_sent, sizeof(data_sent));
      Serial.println("BINGO!"); //For debugging purposes
      tone(piezoPin, 440, 200); //Buzzer will beep
      state = 0;
    }else{
      noTone(8);
      state = 1;
    }
    previousTime = writeTime; //Multi-tasking purpose
  }

  //Read Mode (Wait GUI commands from Arduino receiver)
  if (currentTime - previousTime >= readTime){
    while(network.available()){
      Serial.print("Wait Radio input: "); //For debugging purpose
      RF24NetworkHeader header;
      network.read(header, &incomingData, sizeof(incomingData));
      //Target On or Off (data = 11 or 31)
      if (incomingData == 81){
        sensitivity = 800; //Close range
      }else if (incomingData == 51){
        sensitivity = 500; //Mid range
      }else if (incomingData == 21){
        sensitivity = 200; //Far range
      }
      Serial.println(incomingData); //For debugging purpose
    }
    previousTime = readTime; //Multi-tasking purpose
  }

}

//Records vibration sensor input
long TP_init_A(){
  delay(10);
  long measurement_A = pulseIn(vibrPin_A, HIGH);
  return measurement_A;
}

//Records vibration sensor input
long TP_init_B(){
  delay(10);
  long measurement_B = pulseIn(vibrPin_B, HIGH);
  return measurement_B;
}
