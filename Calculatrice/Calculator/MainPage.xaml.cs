using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e){
            if ((Result.Text == "0") || (isOperationPerformed))
                Result.Text = ""; // . Clear() ?????????

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Content == ".")
            {
                if (!Result.Text.Contains("."))
                    Result.Text = Result.Text + button.Content;

            }
            else
                Result.Text = Result.Text + button.Content;
        }


        private void Operator_click(object sender, RoutedEventArgs e){
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                //Enter.PerformClick();
                operationPerformed = (String) button.Content;
                //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = (String) button.Content;
                resultValue = Double.Parse(Result.Text);
                //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void Enter_click(object sender, RoutedEventArgs e){
            switch (operationPerformed)
            {
                case "+":
                    Result.Text = (resultValue + Double.Parse(Result.Text)).ToString();
                    break;
                case "-":
                    Result.Text = (resultValue - Double.Parse(Result.Text)).ToString();
                    break;
                case "*":
                    Result.Text = (resultValue * Double.Parse(Result.Text)).ToString();
                    break;
                case "/":
                    Result.Text = (resultValue / Double.Parse(Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            //resultValue = Double.Parse(Result.Text);
            //labelCurrentOperation.Text = "";
        }

    }


    }

