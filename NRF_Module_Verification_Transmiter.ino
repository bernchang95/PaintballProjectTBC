/*
:Marker Counter Transmitter
:Author: Lukas Johnny
:Email: Lukasjohnny2328@gmail.
:Maker Counter v1.0
:Date: 05/08/2020
:Revision: v1.0
:License: TechMon
*/

//Sends data to Arduino Receiver
//Make sure NRF_Module_Verification_Receiver code is uploaded to your Arduino station.

//Include Necessary Libraries
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

//Declare nRF pin and const address
RF24 radio(9, 10); // CE, CSN
//Address must be same as receiver, free to change
const byte address[6] = "000001";

//Create a struct that do not exceed 32 bytes (I prefer this method)
struct Data_to_be_sent {
  byte ch1;
};

Data_to_be_sent sent_data;

void setup() {
  Serial.begin(9600);
  radio.begin();
  radio.setAutoAck(false);
  radio.setPALevel(RF24_PA_MIN);
  radio.setDataRate(RF24_250KBPS);
  radio.openWritingPipe(address);
  radio.stopListening();  

  //Default reset channel value
  sent_data.ch1 = 0;
}

void loop() {
  //Increase counter amount and send data to receiver
  marks =++count;
  sent_data.ch1 = marks;
  radio.write(&sent_data, sizeof(Data_to_be_sent));
  Serial.println(sent_data.ch1);
}
