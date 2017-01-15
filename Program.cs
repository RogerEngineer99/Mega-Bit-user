using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;

//
// Application Name: Meg Bit
// Description: Application that generates erratic mouse and keyboard movements and input and generates system sounds and fake dialogs to confuse the user  
// Topic:
//   1) Threads
//   2) System.Windows.Forms namespace & assembly
//   3) Hidden application 

namespace MegBit
{
    class Program
    {
        public static Random _random = new Random();

        public static int _startupDelaySeconds = 10;
        public static int _totalDurationSeconds = 240;


        /// <summary>
        /// Entry point for prank application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("MegaBit Prank Application by: Hacker (aka. First Last");

            // Check for command line arguelents and assign the new values
            if (args.Length >= 2)
            {
                _startupDelaySeconds = Convert.ToInt32(args[0]);
                _totalDurationSeconds = Convert.ToInt32(args[1]);
            }

            // Create all threads that manipulate all of the inputs and outputs to the system
            Thread megabitMouseThread = new Thread(new ThreadStart(megabitMouseThread));
            Thread megabitKeyBoardThread = new Thread(new ThreadStart(megabitKeyboardThread));
            Thread megabitSoundThread = new Thread(new ThreadStart(megabitSoundThread));
            Thread megabitPopupThread = new Thread(new ThreadStart(megaPopupThread));


            DateTime future = DateTime.Now.AddSeconds(_startupDelaySeconds);
            Console.WriteLine("Waiting 10 seconds before starting threads");
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }


            // Start all of the threads
            megabitMouseThread.Start();
            megabitKeyBoardThread.Start();
            megabitSoundThread.Start();
            megabitPopupThread.Start();

            future = DateTime.Now.AddSeconds(_totalDurationSeconds);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            Console.WriteLine("Terminating all threads");
            // Kill all threads and exit application
            megabitMouseThread.Abort();
            megabitKeyBoardThread.Abort();
            megabitSoundThread.Abort();
            megabitPopupThread.Abort();


        }
        #region Thread Functions
        /// <summary>
        /// This thread will random affect the mouse movement to screw with the end user
        /// </summary>
        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                Console.WriteLine(Cursor.Position.ToString());

                // Generate the random amount to move the cursor on X and Y 
                moveX = _random.Next(20) - 10;
                moveY = _random.Next(20) - 10;

                // Change mouse cursor position to new random coordinates
                Cursor.Position = new System.Drawing.Point(
                Cursor.Position.X + moveX,
                Cursor.Position.Y + moveY);

                Thread.Sleep(50);
            }

        }
        /// <summary>
        /// This will generate random keyboard output to screw with the end user
        /// </summary>
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            while (true)
            {
                if (_random.Next(100) > 50)
                {
                    // Generate a random capitol letter
                    char key = (char)(_random.Next(25) + 65);

                    // 50/50 make it lower case
                    if (_random.Next(2) == 0)
                    {
                        key = Char.ToLower(key);
                    }

                    SendKeys.SendWait(key.ToString());

                    Thread.Sleep(_random.Next(500));
                }
            }

        }
        /// <summary>
        /// This will play system sounds at random to screw with the end user
        /// </summary>
        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            while (true)
            {
                // Determine if we're going to play a sound this time through the loop (20% odds)
                if (_random.Next(100) > 90)
                {
                    // Randomly select a system sound
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;

                    }

                    SystemSounds.Asterisk.Play();
                }

                Thread.Sleep(50);
            }

        }

        /// <summary>
        /// This will play popup fake error notifications to make the user go crazy and pull their hair out
        /// </summary>
        public static void DrunkPopupThread()
        {
            Console.WriteLine("DrunkPopupThread Started");

            while (true)
            {
                // Every 10 seconds roll the dice and 10% of the time show a dialog
                if (_random.Next(100) > 90)
                {
                    // Determined which message to show user
                    switch (_random.Next(2))
                    {
                        case 0:
                            MessageBox.Show
                            ("Internet explorer has stopped working",
                            "Internet Explorer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show("Your system is running low on resources",
                           "Microsoft Windows",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                            break;

                    }
                }

                Thread.Sleep(10000);
            }
            #endregion
        }
    }
}
