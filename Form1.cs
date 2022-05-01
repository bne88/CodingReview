using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Read_Sensor
{
    public partial class Form1 : Form
    {
        // Initialize our variables
        string FILETOREAD = @"C:\ERAU\Vazquez-VTprg.csv";
        string FILETOWRITE = @"C:\ERAU\Results.csv";
        // Headers
        string TITLES = "Sensor ID,Route,Date and Time,GPS W, GPS N,Altitude,Battery Life,Flow Level,Flow Speed,Viscocity,Pipeline Temperature (Inside),Pipeline Temperature (Outside),Free Space Available,IP Address,Valve Level\n";
        int VALVE_LEVEL = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            // Variable that will be used for the for loop
            int i = 0;
            // Variable that will be used to check if a file exists
            string[] fileValidation;

            // Check that the sensor number button has been selected
            if (btnSensorNumber.Checked == true)
            {
                // Show the instructions to the user of how to enter input
                lblInstructions.Text = "Please enter a sensor number\n";
                // Check that textbox is not empty
                if (txtInput.Text == "")
                {
                    MessageBox.Show("Please enter a value");
                }
                // If input is not a number, tell the user to enter a number
                else if (checkInt(txtInput) == 1)
                {
                    MessageBox.Show("Please enter a valid sensor number from 1-12");
                }
                // Check that the input is an integer
                else if (checkInt(txtInput) == 0)
                {
                    // If the input is valid, convert the string into an integer
                    int num = int.Parse(txtInput.Text);
                    // Check that the input is between 1-12
                    if (num >= 1 && num <= 12)
                    {
                        // Try to make the program read the file
                        try
                        {
                            fileValidation = System.IO.File.ReadAllLines(FILETOREAD);
                        }
                        // If the file is not found, send a message to the user and stop the program
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show("Please enter data into the file");
                            this.Close();
                        }
                        // If the Directory is not found, send a message to the user and stop the program
                        catch (DirectoryNotFoundException)
                        {
                            MessageBox.Show("Directory not found");
                            this.Close();
                        }
                        // If something else fails, also report it
                        catch
                        {
                            MessageBox.Show("Please enter data into the file");
                            this.Close();
                        }
                        // Read the file into a string of lines
                        string[] lines = File.ReadAllLines(FILETOREAD);
                        // Check that the file is not empty
                        if (FILETOREAD != null)
                        {
                            // Write the headers into the file
                            File.WriteAllText(FILETOWRITE, TITLES);
                            // Iterate through the string of lines
                            for (i = 0; i < lines.Length; ++i)
                            {
                                // If a line starts with ExxonVT and the number from the user, append it into the file to write
                                if (lines[i].StartsWith("ExxonVT" + num))
                                {
                                    File.AppendAllText(FILETOWRITE, lines[i]);
                                    // Append if the valve is open or closed
                                    writeValveLevel(sender, e);
                                }
                            }
                            // Tell the user that the data was recorded successfully
                            MessageBox.Show("Data has been recorded successfully");
                        }
                        // If file is null or empty, report it
                        else
                        {
                            MessageBox.Show("Please enter data into the file");
                        }
                    }
                    // If the input is out of range, show a message to the user
                    else if (num < 1 || num > 12)
                    {
                        MessageBox.Show("Enter a number between 1-12");
                    }
                }
                // If anything else fails, report it to the user
                else
                {
                    MessageBox.Show("Enter a valid number");
                }
            }
            // Check that the Max Temperature button is selected
            else if (btnMaxTemp.Checked == true)
            {
                // Show the instructions to the user of how to enter input
                lblInstructions.Text = "Please enter a max temperature";
                // Check if textbox is empty
                if (txtInput.Text == "")
                {
                    MessageBox.Show("Please enter a value");
                }
                // Check if the input is not an integer
                else if (checkInt(txtInput) == 1)
                {
                    MessageBox.Show("Please enter a valid max temperature from -10-120");
                }
                // Check if input is an integer
                else if (checkInt(txtInput) == 0)
                {
                    // Convert the input from a string to an integer
                    int num = int.Parse(txtInput.Text);
                    // Check if the input is between the valid range
                    if (num >= -10 && num <= 120)
                    {
                        try
                        {
                            fileValidation = System.IO.File.ReadAllLines(FILETOREAD);
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show("Please enter data into the file");
                            this.Close();
                        }
                        catch (DirectoryNotFoundException)
                        {
                            MessageBox.Show("Please enter data into the file");
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Please enter data into the file");
                            this.Close();
                        }
                        // Read the file into a string of lines
                        string[] lines = File.ReadAllLines(FILETOREAD);
                        // Check if the file read is not null or empty
                        if (FILETOREAD != null)
                        {
                            // Write the headers into the file to write
                            File.WriteAllText(FILETOWRITE, TITLES);
                            // Iterate through the string of lines
                            for (i = 0; i < lines.Length; ++i)
                            {
                                // Look for lines that contain the temperature the user desires
                                if (lines[i].Contains("," + num.ToString() + " C"))
                                {
                                    // Write to the file the lines that contain the temperature the user wants
                                    File.AppendAllText(FILETOWRITE, lines[i]);
                                    // Write to the file if the valve is open or closed
                                    writeValveLevel(sender, e);
                                }
                            }
                            // Tell the user the data was recorded successfully
                            MessageBox.Show("Data has been recorded successfully");
                        }
                        // If file is empty, tell the user to enter data into the file
                        else
                        {
                            MessageBox.Show("Please enter data into the file");
                        }
                    }
                    // Check if input entered is out of the range of temperatures
                    else if (num < -10 || num > 120)
                    {
                        MessageBox.Show("Enter a temperature between -10-120");
                    }
                }
                // If anything fails when checking input, let the user know
                else
                {
                    MessageBox.Show("Enter a valid number");
                }
            }
            // Check if none of the buttons were checked
            else if (btnMaxTemp.Checked != true && btnSensorNumber.Checked != true)
            {
                MessageBox.Show("You must choose one option");
            }
            // If anything else fails, send a message to the user
            else
            {
                MessageBox.Show("Sensor number and temperature did not return ANYTHING");
            }
        }
        // Function created to check if the input from the user is an integer
        private int checkInt(TextBox textBox)
        {
            int i;

            //Checking if input is not a number
            if ((!int.TryParse(textBox.Text, out i)) && (textBox.Text != ""))
            {
                return 1;
            }
            // Return 0 if input is in fact an integer
            else
            {
                return 0;
            }
        }
        // Function that chooses if a valve is open and write the valve level to the file
        private void writeValveLevel(object sender, EventArgs e)
        {
            Random valve = new Random();
            VALVE_LEVEL = valve.Next(1, 3);
            if (VALVE_LEVEL == 1)
            {
                File.AppendAllText(FILETOWRITE, "Open\n");
            }
            else
            {
                File.AppendAllText(FILETOWRITE, "Closed\n");
            }
        }
        // Function that closes the program
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
