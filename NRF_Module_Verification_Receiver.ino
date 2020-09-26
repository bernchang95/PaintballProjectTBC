/*
:Marker Counter Receiver
:Author: Lukas Johnny
:Email: Lukasjohnny2328@gmail.
:Maker Counter v1.0
:Date: 05/08/2020
:Revision: v1.0
:License: TechMon
*/

//LCD output:
//Hit Count:
//   0 (then receives data from transmitter for changes)
// Expected changes: Number increases and resets back to 0 quickly

//Include Necessary Libraries
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,20,4);

//Declare nRF pin and const address
RF24 radio(2,7); // CE, CSN <- Check your connection
//Radio's address, you are free to change it as long as transmitter and
//receiver adress is the same all the time.
const byte address[6] = "000001";

//Data packets to capture what transmitter has sent.
struct Received_data {
  byte ch1;
  //byte ch2;
};

Received_data received_data;

int ch1_value = 0;
int ch2_value = 0;
int count = 0;
int marks = 0;
int piezoPin = 8;
String sp1 = " : ";

void setup() {
  //Radio and LCD initialization.
  //Refer to datasheet for function details.
  lcd.init();
  lcd.backlight();
  Serial.begin(9600);
  radio.begin();
  radio.setAutoAck(false);
  radio.setPALevel(RF24_PA_MIN);
  radio.setDataRate(RF24_250KBPS);
  radio.openReadingPipe(0,address);
  radio.startListening();
}

//For arduino multi-tasking
unsigned long last_Time =0;

//Reads transmitter data.
void receive_the_data()
{
  if(radio.available()> 0)
  {
    radio.read(&received_data, sizeof(Received_data));
    last_Time = millis();
  }
}
void loop() {
  //LCD display results.
  lcd.setCursor(3,0);
  lcd.print("Hits Count");
  
  receive_the_data();
  ch1_value = received_data.ch1;

  if(ch1_value == 0) {
    lcd.setCursor(7,1);
    lcd.print(" "); 
    lcd.setCursor(8,1);
    lcd.print(" "); 
  }
  //ch2_value = received_data.ch2;
  //Serial.println(ch1_value + sp1 + ch2_value);

   lcd.setCursor(7,1);
   lcd.print(ch1_value);
   String sp1 = "Hits Count ";

  Serial.println(sp1 + ch1_value);
}
