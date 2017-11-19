using System.Windows;
using System.Windows.Input;
using NDC;

namespace NDC_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Controls whether or not the NDCUpdate Function should run
        // Turn off for performance optimization
        bool NDCUpdateEnabled = true;
        public void NDCStart()
        {
            // Any Initialization Code goes here

        }
        public void NDCUpdate()
        {
            // Code that needs to be run repeatedly

        }

        void NDCUpdateAll()
        {
            // Call the Update method for All NDC Controls Here.

        }

        #region Auto Generated UI Functionality
        NDC.NDynamics.Core.AsyncWorker ASW_MC = new NDC.NDynamics.Core.AsyncWorker(1);
        NDC.NDynamics.Core.AsyncWorker ASW_CC = new NDC.NDynamics.Core.AsyncWorker(1);
        public MainWindow()
        {
            InitializeComponent();
            
            Opacity = 0;
            NDC.NStyle.Container.Colors.Deep();
            NDCUpdateAll();

            MouseDown += MainWindow_MouseDown;
            MouseUp += MainWindow_MouseUp;
            
            ASW_MC.StopAsyncWorker();
            ASW_MC.RunAsyncWorker(fadeIn);

            if (NDCUpdateEnabled)
            {
                ASW_CC.RunAsyncWorker(NDCUpdate);
            }

            NDCStart();
        }
        void fadeIn()
        {
            if (Opacity < 1.00F)
            {
                Opacity += 0.01F;
            }
        }
        void md_fade_H()
        {
            if (Opacity > 0.70F)
            {
                Opacity -= 0.01F;
            }
        }
        void mu_fade_H()
        {
            if (Opacity < 1.00F)
            {
                Opacity += 0.01F;
            }
        }
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    ASW_MC.StopAsyncWorker();
                    ASW_MC.RunAsyncWorker(md_fade_H);
                    DragMove();
                }
            }
            catch { }
        }
        private void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ASW_MC.StopAsyncWorker();
            ASW_MC.RunAsyncWorker(mu_fade_H);
        }
        #endregion
    }
}
