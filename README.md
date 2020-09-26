# Paintball Target Project

Continued from previous updates.

Summary of progress:
1. Multiple target detection (up to 2 targets)
2. Extender is still in progress (More research and troubleshooting is required)
3. 2 Methodologies have been used to control the Arduino's Radio module (RF24Network.h library-current and manual NRF module setup.)

<h1> Potential troubleshooting issues (Please take note on this!)</h1>
<h2> 1. NRF wrong pin declare on CE/CSN pins</h2>
<p> I wasted quite some time on this troubleshooting, not aware that I connected the wrong pin to the NRF radio module... just in case, make sure you declare them correctly in the Arduino sketch.</p>
  
<h2> 2. Power supply</h2>
<p> If you are using the battery, make sure the battery is fully charged to ease your troubleshooting progress.</p>
  
<h2> 3. System out of sync</h2>
<p> This may happen if the NRF radio modules failed to send or receive commands in between Arduinos or the USB commands fail to interact between the GUI and the station Arduino.</p>
<p> Utilize the LCD provided to make sure you really received things as it is.</p>
<p> If the GUI is no longer required, then you only have to worry about the NRF radio modules.</p>

<h2> 4. RF24Network.h library</h2>
<p> As I explained just now, the current library is causing some bugs that does not auto-refresh the radio modules properly each time you reconnect the system after some time. I will paste the link where I get this idea from and also its respective datasheet for you to study how the library works. I may have missed some functions that ensures the system works bug-free and allows plug and play.</p>
  
<strong>Temporary solution:</strong> Re-upload the codes using the sketch to the arduino station (with LCD) and one of the target system.
NRF_Module_Verification_Receiver: To the main station Arduino (with LCD)
NRF_Module_Verification_Transmiter: To one of the target Arduinos

<p> Once this process is completed, reupload the main sketch back to the system. The system should work properly again...</p>

<h1> Useful References</h1>
<p> Some good references for you to understand my codes a bit better, since that's how I get started anyways... might as well :) </p>
<p> https://www.youtube.com/watch?v=ZD02a9DHgTg - Visual Basic.NET stopwatch project. This teaches you the basics on using Visual Studio, and also how the Timer Counter of the paintball project is setup. </p>

<p> https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/delegates/how-to-invoke-a-delegate-method - This is a basic code example on how the Invoke command with Delegate functions (you see it a lot in the GUI code) is done. Executes process thread without causing the program to lag or "crash". Google "VB.net Invokes and Delegates" if you don't understand this tutorial. </p>

<p> https://www.hackster.io/techno-brothers/arduino-with-vb-net-gui-control-e3a262 - Simple VB.net project on how to control the Arduino via USB connection. Great to start here so you understand how the Target project works. </p>

<p> https://howtomechatronics.com/tutorials/arduino/how-to-build-an-arduino-wireless-network-with-multiple-nrf24l01-modules/ - RF24Network.h library usage tutorial </p>

<p> https://howtomechatronics.com/tutorials/arduino/arduino-wireless-communication-nrf24l01-tutorial/ - Manual NRF module setup </p>

<h1> Datasheets for NRF radio modules and class declaration </h1>
Compulsory libraries for Arduino:
RF24 Network.h
1. Download location - https://www.arduinolibraries.info/libraries/rf24-network
2. Function Guideline - https://tmrh20.github.io/RF24Network/annotated.html (A lot of functions inside... hence you need to click around to find what you need in here.)
LiquidCrystal_I2C.h
1. Download location - https://www.arduinolibraries.info/libraries/liquid-crystal-i2-c
2. Function Guideline - https://github.com/johnrickman/LiquidCrystal_I2C
RF24.h
1. Download location - https://www.arduinolibraries.info/libraries/rf24
2. Function Guideline - https://tmrh20.github.io/RF24/classRF24.html

<h1> Programming Reminder</h1>
<p> Make sure you conduct good practices when you code. Your code must be easy to understand and utilize comments to ease your troubleshooting experience. Also, ensure your codes are robust because project vision or featuers may change overtime. Otherwise, you will have a hard time changing the code structure.</p>
