
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using System.Collections.Generic;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Accord.Audio;
using NAudio.Midi;
using Newtonsoft.Json;

namespace ScreenRecorder
{
    public partial class Form1 : Form
    {
        private int fps = 30;
        private int bitRate = 100;
        private bool recordMic = false;



        //awake
        public Form1()
        {
            InitializeComponent();
            LoadRecordMiceSettingsFromJson();
            if (recordMic)
            {
                micRecording_label1.Text = "Audio Recording Mic";
            }
            else
            {
                micRecording_label1.Text = "Audio Recording Desktop";
            }
            Capturing_label.ForeColor = Color.Red;
            Capturing_label.Text = "NOT Recording.";
        }
        //start
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SaveRecordMiceSettingsToJson()
        {
            var settings = new { RecordMic = recordMic };
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            var path = Path.Combine(Application.StartupPath, "recordMic.json");
            File.WriteAllText(path, json);
        }
        private void LoadRecordMiceSettingsFromJson()
        {
            var path = Path.Combine(Application.StartupPath, "recordMic.json");
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var settings = JsonConvert.DeserializeObject<dynamic>(json);
                recordMic = settings.RecordMic;

            }
        }


        //MICROPHONE RECORDER
        private WaveFormat waveFormatMic;
        private WaveFileWriter writerMic;
        private WaveInEvent waveInMic;

        private void StartMicRecording()
        {
            // Create a new wave format for the audio input
            waveFormatMic = new WaveFormat(44100, 16, 2);

            // Create a new wave file to save the recorded audio
            writerMic = new WaveFileWriter("output_Mic.wav", waveFormatMic);

            // Create a new audio capture device
            waveInMic = new WaveInEvent();

            // Set the audio capture device's input format to the wave format we created
            waveInMic.WaveFormat = waveFormatMic;

            // Define the callback function that will be called whenever audio data is available
            waveInMic.DataAvailable += (sender, audioArgs) =>
            {
                // Write the audio data to the wave file
                writerMic.Write(audioArgs.Buffer, 0, audioArgs.BytesRecorded);
            };

            // Start capturing audio
            waveInMic.StartRecording();
        }

        private void StopMicRecording()
        {
            // Stop capturing audio
            waveInMic.StopRecording();

            // Dispose of the wave file writer to save the recorded audio
            writerMic.Dispose();
        }

        //DESKTOP AUDIO RECORDER
        private WasapiLoopbackCapture waveIn;
        private WaveFileWriter writer;

        public void StartRecordDesktopAudio()
        {
            waveIn = new WasapiLoopbackCapture();
            writer = new WaveFileWriter("output_Desktop.wav", waveIn.WaveFormat);
            waveIn.DataAvailable += (s, e) =>
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            };
            waveIn.RecordingStopped += (s, e) =>
            {
                writer.Dispose();
                waveIn.Dispose();
            };
            waveIn.StartRecording();
        }

        public void EndRecordDesktopAudio()
        {
            waveIn.StopRecording();
        }

        //DESKTOP VIDEO RECORDING
        private Rectangle screenBounds;
        private Bitmap screenBitmap;
        private Graphics screenGraphics;
        private VideoFileWriter videoWriter;
        private string videoFilePath;
        private DateTime startTime;
        private int frameCount;
        private Thread screenCaptureThread;

        public void StartRecording()
        {
            // Set up the screen capture
            screenBounds = Screen.PrimaryScreen.Bounds;
            screenBitmap = new Bitmap(screenBounds.Width, screenBounds.Height);
            screenGraphics = Graphics.FromImage(screenBitmap);

            // Set up the video writer
            videoWriter = new VideoFileWriter();
            videoFilePath = "screen_capture.avi";
            videoWriter.Open(videoFilePath, screenBounds.Width, screenBounds.Height, fps, VideoCodec.MPEG4, bitRate * 1000000);

            // Set up the recording variables
            //recordingTimeSeconds = 10;
            startTime = DateTime.Now;
            frameCount = 0;

            // Start the screen capture loop in a separate thread
            screenCaptureThread = new Thread(ScreenCaptureLoop);
            screenCaptureThread.Start();
        }

        public void StopRecording()
        {
            // Stop the screen capture loop and wait for it to finish
            screenCaptureThreadRunning = false;
            screenCaptureThread.Join();

            // Close the video writer
            videoWriter.Close();

            // Display a message when finished
            MessageBox.Show("Screen capture saved to " + videoFilePath);
        }

        private volatile bool screenCaptureThreadRunning = true;

        private void ScreenCaptureLoop()
        {
            while (screenCaptureThreadRunning && (DateTime.Now - startTime).TotalSeconds < double.PositiveInfinity)
            {
                // Capture the screen and add it to the video
                screenGraphics.CopyFromScreen(screenBounds.X, screenBounds.Y, 0, 0, screenBounds.Size);
                videoWriter.WriteVideoFrame(screenBitmap);

                // Measure the time it takes to capture and write a frame
                TimeSpan frameTime = DateTime.Now - startTime;
                double actualFps = (++frameCount) / frameTime.TotalSeconds;

                // Calculate the sleep time based on the actual frame rate
                int sleepTime = (int)(1000f / actualFps);

                // Sleep for the calculated time
                //Thread.Sleep(sleepTime);
            }
        }

        //*********************************input**************************************************
        private void recordScreenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StartRecording();
            if (recordMic)
            {
                StartMicRecording();
                //RecordMic();
            }
            else
            {
                StartRecordDesktopAudio();
            }
            Capturing_label.ForeColor = Color.LimeGreen;
            Capturing_label.Text = "Recording!";
        }
        private void stopRecordScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopRecording();
            if (recordMic)
            {
                StopMicRecording();
                //RecordMic();
            }
            else
            {
                EndRecordDesktopAudio();
            }
            Capturing_label.ForeColor = Color.Red;
            Capturing_label.Text = "NOT Recording.";
        }

        private void toggleMicRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordMic = !recordMic;
            SaveRecordMiceSettingsToJson();
            if (recordMic)
            {
                micRecording_label1.Text = "Audio Capturing Mic";
            }
            else
            {
                micRecording_label1.Text = "Audio Capturing Desktop";
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Specify the URL to open
            string url = "https://manbearpigman.itch.io";

            // Start a new process to open the default browser and navigate to the URL
            System.Diagnostics.Process.Start(url);
        }
    }
}