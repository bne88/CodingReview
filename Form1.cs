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

namespace Exxon_Sensor_File_Generator
{
    public partial class Form1 : Form
    {
        // Initlialize and declare our variables
        public int SENSOR_RAND = 0;
 
        public int LOC_HORIZONTAL = 0;
        public int LOC_HORIZONTAL_DEC = 0;
        public int LOC_VERTICAL = 0;
        public int LOC_VERTICAL_DEC = 0;
        public int ALTITUDE = 0;
        public int BATTERY = 0;
        public int FLOW_LEVEL = 48;
        public int FLOW_SPEED = 7;
        public int VISCOCITY = 500;
        public int TEMP_INSIDE = 40;
        public int TEMP_OUTSIDE = 70;
        public int MEMORY = 0;

        public int PROBABILITY = 0;
        public int LOOP_KEEPER = 1;

        // FilePath
        string FP = @"C:\ERAU\Vazquez-VTprg.csv";
        // Headers
        string TITLES = "Sensor ID,Route,Date and Time,GPS W, GPS N,Altitude,Battery Life,Flow Level,Flow Speed,Viscocity,Pipeline Temperature (Inside),Pipeline Temperature (Outside),Free Space Available,IP Address,\n";
        public Form1()
        {
            InitializeComponent();
        }
        // Function to Generate Data
        private async void btnCheckSensor_Click(object sender, EventArgs e)
        {
            string[] fileValidation;
            // Variable that will be used in our for loop
            int i = 0;

            // Try to make the program read the file
            try
            {
                fileValidation = System.IO.File.ReadAllLines(FP);
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

            // Check that the file is not empty
            if (FP != null)
            {
                //Write the headers into the file
                File.WriteAllText(FP, TITLES);
                // Iterate through this loop 100 times
                for (i = 1; i < 101; ++i)
                {
                    // Wait 15 seconds to create the data
                    await Task.Delay(TimeSpan.FromSeconds(15));
                    // Generate a sensor to check
                    Random sensor_rand = new Random();
                    SENSOR_RAND = sensor_rand.Next(1, 13);
                    // Create all the data for the file and write it into the file
                    File.AppendAllText(FP, "ExxonVT" + SENSOR_RAND.ToString() + ",");
                    createRoute(sender, e, SENSOR_RAND);
                    File.AppendAllText(FP, DateTime.Now.ToString() + ",");
                    createCoordinates(sender, e, SENSOR_RAND);
                    createAltitude(sender, e, SENSOR_RAND);
                    createBattery(sender, e);
                    createFlowLevel(sender, e);
                    createFlowSpeed(sender, e);
                    createViscocity(sender, e);
                    createTempInside(sender, e);
                    createTempOutside(sender, e);
                    createMemory(sender, e);
                    getIPAddress(sender, e, SENSOR_RAND);
                    // Skip to the next line of the file
                    File.AppendAllText(FP, "\n");
                }
                // When the for loop is done, generate a message to the user that the data was successfully recorded
                MessageBox.Show("Data has been successfully entered");
            }
            
        }

        // Choose which route the sensors are from
        private void createRoute(object sender, EventArgs e, int route)
        {
            if (route > 0 && route <= 6)
            {
                File.AppendAllText(FP, "Spokane,");
            }
            else if (route > 6 && route <= 12)
            {
                File.AppendAllText(FP, "Great Falls,");
            }
            else
            {
                MessageBox.Show("The route is non-existent");
            }
        }

        // Generate the coordinates of the sensors depending on their route
        private void createCoordinates(object sender, EventArgs e, int route)
        {
            if (route > 0 && route <= 6)
            {
                LOC_VERTICAL = -117;
                LOC_HORIZONTAL = 47;
                Random sensor_vert_dec = new Random();
                LOC_VERTICAL_DEC = sensor_vert_dec.Next(300, 999);
                Random sensor_hor_dec = new Random();
                LOC_HORIZONTAL_DEC = sensor_hor_dec.Next(600, 800);

                File.AppendAllText(FP, LOC_HORIZONTAL.ToString() + "." + LOC_HORIZONTAL_DEC.ToString()
                + "," + LOC_VERTICAL.ToString() + "." + LOC_VERTICAL_DEC.ToString() + ",");
            }
            else if (route > 6 && route <= 12)
            {
                LOC_VERTICAL = -11;
                LOC_HORIZONTAL = 47;
                Random sensor_vert_dec = new Random();
                LOC_VERTICAL_DEC = sensor_vert_dec.Next(300, 999);
                Random sensor_hor_dec = new Random();
                LOC_HORIZONTAL_DEC = sensor_hor_dec.Next(600, 800);

                File.AppendAllText(FP, LOC_HORIZONTAL.ToString() + "." + LOC_HORIZONTAL_DEC.ToString()
                + "," + LOC_VERTICAL.ToString() + "." + LOC_VERTICAL_DEC.ToString() + ",");
            }
        }
        
        // Generate the altitude of the sensor depending on the route
        private void createAltitude(object sender, EventArgs e, int route)
        {
            if (route > 0 && route <= 6)
            {
                File.AppendAllText(FP, "1843 ft,");
            }
            else if (route > 6 && route <= 12)
            {
                File.AppendAllText(FP, "3330 ft,");
            }
        }

        // Generate the battery percentage for each sensor
        private void createBattery(object sender, EventArgs e) {
            Random sensor_bat = new Random();
            BATTERY = sensor_bat.Next(0, 101);
            File.AppendAllText(FP, BATTERY.ToString() + "%,");
        }

        // Generate the flow level for each sensor
        private void createFlowLevel(object sender, EventArgs e)
        {
            Random flow_level = new Random();
            FLOW_LEVEL = flow_level.Next(4, 40);
            File.AppendAllText(FP, FLOW_LEVEL.ToString() + " in,");
        }

        // Generate the flow speed for each sensor
        private void createFlowSpeed(object sender, EventArgs e)
        {
            Random flow_speed = new Random();
            FLOW_SPEED = flow_speed.Next(3, 8);
            File.AppendAllText(FP, FLOW_SPEED.ToString() + "mph,");
        }

        // Generate the viscocity for each sensor
        private void createViscocity(object sender, EventArgs e)
        {
            Random viscocity = new Random();
            VISCOCITY = viscocity.Next(480, 520);
            File.AppendAllText(FP, VISCOCITY.ToString() + " cSt,");
        }

        // Generate the temperature inside for each sensor
        private void createTempInside(object sender, EventArgs e)
        {
            Random temp_inside = new Random();
            TEMP_INSIDE = temp_inside.Next(30, 55);
            File.AppendAllText(FP, TEMP_INSIDE.ToString() + " C,");
        }

        // Generate the temperature outside for each sensor
        private void createTempOutside(object sender, EventArgs e)
        {
            Random temp_outside = new Random();
            TEMP_OUTSIDE = temp_outside.Next(-10, 120);
            File.AppendAllText(FP, TEMP_OUTSIDE.ToString() + " C,");
        }

        // Generate how much memory is left in each sensor
        private void createMemory(object sender, EventArgs e)
        {
            Random memory = new Random();
            MEMORY = memory.Next(0, 101);
            File.AppendAllText(FP, MEMORY.ToString() + "%,");
        }

        // Generate the IP Address depending on the Sensor ID
        private void getIPAddress(object sender, EventArgs e, int route)
        {
            File.AppendAllText(FP, "67.193.12." + route.ToString() + ",");
        }

        // Function to close the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
