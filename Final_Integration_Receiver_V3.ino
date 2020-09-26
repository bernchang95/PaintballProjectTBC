#include <SPI.h>
#include <RF24.h>
#include <RF24Network.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,20,4);
RF24 radio (2,7); // CE, CSN (Change this based on your own connection if required)
RF24Network network(radio);

//Define your network nodes (Refer to tutorial to understand more in detail)
const uint16_t master_node = 00;
//Include extender in network for next test
const uint16_t target1 = 01;
const uint16_t target2 = 02;

byte usb_read;
String gui_read = "";
String targetNo = "";
String ser_data = "";
boolean count_start = false;
unsigned long data_sent = 00; //data packet for Target 1
unsigned long data_sent2 = 00; //data packet for Target 2
int targetNumber = 0;

void setup() {
  //Initialize LCD and NRF radio module
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
  SPI.begin();
  radio.begin();
  network.begin(90, master_node);
}

//Serial port handshake, tells GUI that this arduino successfully connects to it via USB
void detect_port(){
  if (Serial.available() > 0){
    usb_read = Serial.read();
    if (usb_read == 'S'){
      Serial.println("G");
    }
  }
}

void loop() {

  //Define network addresses
  RF24NetworkHeader header; //For receiving data
  RF24NetworkHeader header2(target1); //For writing instructions to Target 1
  RF24NetworkHeader header3(target2); //For writing instructions to Target 2
  
  network.update(); //Required to maintain radio connection.
  
  lcd.setCursor(1,0);
  lcd.print("TN"); //Target Number
  lcd.setCursor(5,0);
  lcd.print("R"); //Range setting
  lcd.setCursor(13,0);
  lcd.print("HIT"); //Hit or no hit
  
  detect_port();

  //Serial commands sent from GUI, respond "G" to tells GUI the job is done.
  if (Serial.available()){
    gui_read = Serial.readString();
    if (gui_read.indexOf("00") >= 0){
      targetNo = gui_read.charAt(0); //Gets which target to send instruction
      lcd.setCursor(1,1);
      if (targetNo.indexOf("1") >= 0) {
        targetNumber = 1;
        lcd.print("1");
        data_sent = TargetRange(); //81, 51, or 21 (Command to tweak Target 1 vibration sensor)
      }else if (targetNo.indexOf("2") >= 0){
        targetNumber = 2;
        lcd.print("2");
        data_sent2 = TargetRange(); //82, 52, or 22 (Command to tweak Target 2 vibration sensor)
      }
      ser_data = "G";
    }else if (gui_read.indexOf("START") >= 0){
      //data_sent variable for debugging purposes.
      data_sent = 77;
      data_sent2 = 77;
      lcd.setCursor(0,1);
      lcd.print(" ");
      lcd.setCursor(13,1);
      lcd.print("   ");
      ser_data = "G";
      count_start = true;
    }else if (gui_read.indexOf("STOP") >= 0){
      //data_sent variable for debugging purposes.
      lcd.setCursor(13,1);
      lcd.print("   ");
      lcd.setCursor(13,1);
      lcd.print("SP");
      lcd.setCursor(14,1);
      lcd.print("  ");
      data_sent = 88;
      data_sent2 = 88;      
      count_start = false;
      ser_data = "G";    
    }else if (gui_read.indexOf("CANCEL")){
      //data_sent variable for debugging purposes.
      data_sent = 99;
      data_sent2 = 99;
      lcd.clear();
      ser_data = "G";
      count_start = false;
    }
  }
  //Radio Write Mode (Sends command to target)
  //Target 1 send command
  network.write(header2, &data_sent, sizeof(data_sent));
  //Target 2 send command
  network.write(header3, &data_sent2, sizeof(data_sent2));      

  //GUI "Start Record" function. Only runs when user clicks that button.
  if (count_start){
    //Radio Read Mode (Awaiting trigger command from target transmitters)
    if (network.available()){
      unsigned long incomingData;
      network.read(header, &incomingData, sizeof(incomingData));
      //Stop GUI timer if hit
      if (incomingData == 11){
        //Target 1 hit
        lcd.setCursor(1,1);
        lcd.print(" ");
        lcd.setCursor(1,1);
        lcd.print(targetNumber);
        lcd.setCursor(14,1);
        lcd.print("H1");
        lcd.setCursor(0,1);
        lcd.print(" ");
        ser_data = "HIT1";        
      }else if (incomingData == 22){
        //Target 2 hit
        lcd.setCursor(1,1);
        lcd.print(" ");        
        lcd.print(targetNumber);
        lcd.setCursor(14,1);
        lcd.print("H2");
        lcd.setCursor(0,1);
        lcd.print(" ");                
        ser_data = "HIT2";      
      }
    }else{
      lcd.setCursor(0,1);
      lcd.print("i");
      ser_data = "G"; 
    }
  }else{
    lcd.setCursor(0,1);
    lcd.print(" ");
  }
  Serial.println(ser_data); //To ensure GUI does not crash while waiting for Arduino to report.
}

long TargetRange(){
  unsigned long range;
  lcd.setCursor(5,1);
  lcd.print("   ");  
  if (gui_read.indexOf("800") >= 0){
    //Close range
    range = 80 + (unsigned long) targetNumber;
    lcd.setCursor(5,1);
    lcd.print("800");    
  }else if (gui_read.indexOf("500") >=0){
    //Mid range
    range = 50 + (unsigned long) targetNumber;
    lcd.setCursor(5,1);
    lcd.print("500");     
  }else if (gui_read.indexOf("200") >=0){
    //Long range
    range = 20 + (unsigned long) targetNumber;
    lcd.setCursor(5,1);
    lcd.print("200");     
  }
  return range;
}
