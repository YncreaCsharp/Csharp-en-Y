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
        bool isEqualPressed = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        // For button 0-1-2-3-4-5-6-7-8-9
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (isEqualPressed)
            {

                //reset everything ( if we have a result and we press a new number, no operation)
                resultValue = 0;
                operationPerformed = "";
                isOperationPerformed = false;
                isEqualPressed = false;
                Result.Text = button.Content.ToString();
                Result2.Text = button.Content.ToString();
            }
            else
            {

                if ((Result.Text == "0") || (isOperationPerformed))
                {

                    Result.Text = "";
                    //Si on appuie sur la touche 0 on enlève alors que rien n'a été fait avant, on efface ce qu'il y a dans la textbox.
                    //Idem si on vient d'effectuer l'opération.
                }
                isOperationPerformed = false;


                if (button.Content == ".")
                {
                    if (!Result.Text.Contains("."))
                    {
                        Result.Text = Result.Text + button.Content;
                        Result2.Text += Result.Text;
                    }

                }
                else
                {
                    Result.Text += button.Content;
                    Result2.Text += button.Content;
                }
            }
        }


        //Use for      - + * /
        private void Operator_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;


            if (isEqualPressed)
            {
                operationPerformed = (String)button.Content;
                Result2.Text = Result.Text + " " + operationPerformed.ToString() + " ";
                resultValue = Double.Parse(Result.Text);
                isOperationPerformed = true;

                //Result.Text = button.Content.ToString();
                //Result2.Text = button.Content.ToString();
                isEqualPressed = false;
            }
            else
            {

                if (resultValue != 0)
                {

                    operationPerformed = (String)button.Content;
                    Result2.Text += " " + operationPerformed.ToString() + " ";
                    isOperationPerformed = true;
                    //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                }
                else
                {

                    operationPerformed = (String)button.Content;
                    resultValue = Double.Parse(Result.Text);
                    Result2.Text += " " + operationPerformed.ToString() + " ";
                    isOperationPerformed = true;
                    //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                }
            }
        }

        //Use for =
        private void Enter_click(object sender, RoutedEventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    Result.Text = (resultValue + Double.Parse(Result.Text)).ToString();
                    isEqualPressed = true;
                    break;
                case "-":
                    Result.Text = (resultValue - Double.Parse(Result.Text)).ToString();
                    isEqualPressed = true;
                    break;
                case "*":
                    Result.Text = (resultValue * Double.Parse(Result.Text)).ToString();
                    isEqualPressed = true;
                    break;
                case "/":
                    Result.Text = (resultValue / Double.Parse(Result.Text)).ToString();
                    isEqualPressed = true;
                    break;
                default:
                    break;
            }

            //We set value to the normal ones
            resultValue = 0;
            operationPerformed = "";
            isOperationPerformed = false;

        }


        private void ResetEverything(object sender, RoutedEventArgs e)
        {
            resultValue = 0;
            operationPerformed = "";
            isOperationPerformed = false;
            isEqualPressed = false;
            Result.Text = "0";
            Result2.Text = "";
        }


    }
}
