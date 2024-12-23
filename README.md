README.md file based on the Mega-Bit user program that generates erratic mouse and keyboard movements, system sounds, and fake dialogs to confuse users. This program was programmed in High School (2017).



Mega-Bit: Prank Program



Overview



Mega-Bit is a prank program created as a personal project during high school in 2017. The application generates erratic mouse and keyboard movements, simulates system sounds, and triggers fake dialogs to confuse and annoy the user. It’s designed purely for fun and is a simple demonstration of automation techniques in C# programming.



Please note: This program should only be used in controlled environments (such as your personal computer) for fun and not for pranks or misuse in public or professional settings.



Features

• Erratic Mouse Movements: The program simulates random mouse movements, making it appear that the mouse is uncontrollable.

• Simulated Keyboard Inputs: The program generates random keyboard inputs, typing characters without user interaction.

• Fake Dialog Boxes: The application creates fake system dialogs (such as error messages or warnings) to trick the user into thinking something is wrong with the system.

• System Sounds: Random system sounds are played during execution to further confuse the user.

• Application Termination: The program will eventually terminate once a predefined maximum value for the display is reached.



How It Works



The application is built using C# and utilizes Windows Forms for its graphical interface. It leverages several key techniques, including:

• Mouse Event Handling: Random mouse movements are simulated through the Windows API.

• Keyboard Input Automation: Keyboard events are triggered programmatically to simulate typing.

• Fake System Dialogs: The program uses message boxes to simulate fake dialogs.

• System Sounds: Random system sounds are triggered at intervals.



The program generates behavior that may cause some confusion or annoyance to the user, making it perfect for a light-hearted prank among friends.



Getting Started



Prerequisites



To run this program, you need:

• Microsoft Visual Studio (version 2017 or later recommended).

• .NET Framework 4.5.2 or higher.

• Basic understanding of C# and Windows Forms applications.



Installation

1. Clone or Download the Project:

Clone this repository or download the ZIP file containing the project files.



git clone https://github.com/your-username/mega-bit-prank.git





2. Open the Project:

Open the Mega-Bit.sln solution file in Microsoft Visual Studio.

3. Build and Run:

Once the solution is opened, build and run the project using Visual Studio. Select Debug configuration and click Start.

4. The program will start running, and it will simulate mouse movements, keyboard inputs, system sounds, and fake dialogs.



Usage

• Start the Program: Once the program is running, it will start its “prank” behavior automatically.

• End the Program: The program will stop automatically once the predefined limits are reached. Alternatively, the user can manually close the application by terminating it via the task manager.



Example of Output

• Erratic Mouse Movement: The mouse pointer will jump around the screen in unpredictable ways.

• Keyboard Input: Random characters will be typed in any active window.

• Fake Dialog Boxes: The program will generate fake system error dialogs like:

• “Warning: Your computer is infected!”

• “Error: Critical system failure.”

• System Sounds: Random Windows system sounds will be played during execution (e.g., notification or error sounds).



C# Code Example



Below is a simple implementation of generating random mouse movement:



using System;

using System.Runtime.InteropServices;

using System.Threading;



public class PrankProgram

{

    // Importing the mouse movement API

    [DllImport("user32.dll", CharSet = CharSet.Auto)]

    public static extern bool SetCursorPos(int x, int y);



    static Random random = new Random();



    public static void GenerateErraticMouseMovement()

    {

        while (true)

        {

            // Generate random coordinates within screen bounds

            int x = random.Next(0, 1920);

            int y = random.Next(0, 1080);



            // Move the mouse

            SetCursorPos(x, y);



            // Sleep for a short random interval

            Thread.Sleep(random.Next(100, 1000));

        }

    }



    public static void Main()

    {

        // Start the erratic mouse movement

        GenerateErraticMouseMovement();

    }

}



This code continuously moves the mouse to random positions on the screen, causing erratic behavior.



Example of Fake Dialog Box



using System;

using System.Windows.Forms;



public class PrankProgram

{

    public static void ShowFakeDialog()

    {

        MessageBox.Show("Warning: System error detected!", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

    }



    public static void Main()

    {

        // Show fake dialog

        ShowFakeDialog();

    }

}



This code shows a message box with a simulated system error.



Disclaimer

• Not for Malicious Use: This program is intended purely for entertainment and should not be used to disrupt or harm others.

• Use at Your Own Risk: Always ensure you use this program in safe environments and with others’ consent.

• Educational Use: This project is a learning exercise in programming and automation techniques.



License



This project is licensed under the MIT License. See the LICENSE file for more details.



This README.md provides an overview, installation instructions, and examples of usage for the Mega-Bit prank program. The application showcases simple automation techniques to simulate erratic system behavior for fun.


