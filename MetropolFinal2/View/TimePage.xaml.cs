using System;
using System.Collections.Generic;
using Windows.UI.Popups;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MetropolFinal2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimePage : Page
    {
        CheckBox[] checkBoxesView;

        int number = 100;
        public TimePage()
        {
            this.InitializeComponent();
            checkBoxesView = new CheckBox[12] {checkbox1, checkbox2, checkbox3, checkbox4, checkbox5, checkbox6, checkbox7, checkbox8,
                                               checkbox9, checkbox10, checkbox11, checkbox12};
            //CheckCheckBoxes();
            //if (checkbox1.IsChecked == true)
            //{
            //    textblock.Text = "Bleeeeee";
            //}
        }

        public void CheckCheckBoxes()
        {
            
            bool DontDisablePrevious = false;
            for (int i = 0; i < checkBoxesView.Length; i++)
            {
                if (checkBoxesView[i].IsChecked == true)
                {
                    for (int j = 0; j < checkBoxesView.Length; j++)
                    {
                        if (i == 0)
                        {
                            if ((checkBoxesView[j] == checkBoxesView[i]) || (checkBoxesView[j] == checkBoxesView[i + 1]))
                            {
                                checkBoxesView[j].IsEnabled = true;
                            }
                            else
                            {
                                checkBoxesView[j].IsEnabled = false;
                            }
                        }
                        else if (i == 11)
                        {
                            if (DontDisablePrevious == true)
                            {
                                if ((checkBoxesView[j] == checkBoxesView[i - 1]) || (checkBoxesView[j] == checkBoxesView[i]))
                                {
                                    checkBoxesView[j].IsEnabled = true;

                                }
                                else
                                {
                                    if (number != 100)
                                    {
                                        checkBoxesView[j].IsEnabled = false;
                                        checkBoxesView[number].IsEnabled = true;
                                    }
                                    else
                                    {
                                        checkBoxesView[j].IsEnabled = false;
                                    }
                                }
                            }
                            else
                            {
                                if ((checkBoxesView[j] == checkBoxesView[i - 1]) || (checkBoxesView[j] == checkBoxesView[i]))
                                {
                                    checkBoxesView[j].IsEnabled = true;
                                    DontDisablePrevious = true;
                                    number = j;
                                }
                                else
                                {
                                    checkBoxesView[j].IsEnabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (DontDisablePrevious == true)
                            {
                                if ((checkBoxesView[j] == checkBoxesView[i - 1]) || (checkBoxesView[j] == checkBoxesView[i]) || (checkBoxesView[j] == checkBoxesView[i + 1]))
                                {
                                    checkBoxesView[j].IsEnabled = true;

                                }
                                else
                                {
                                    if (number != 100)
                                    {
                                        checkBoxesView[j].IsEnabled = false;
                                        checkBoxesView[number].IsEnabled = true;
                                    }
                                    else
                                    {
                                        checkBoxesView[j].IsEnabled = false;
                                    }                                
                                }           
                            }
                            else
                            {
                                if ((checkBoxesView[j] == checkBoxesView[i - 1]) || (checkBoxesView[j] == checkBoxesView[i]) || (checkBoxesView[j] == checkBoxesView[i + 1]))
                                {
                                    checkBoxesView[j].IsEnabled = true;
                                    DontDisablePrevious = true;
                                    number = j;
                                }
                                else
                                {
                                    checkBoxesView[j].IsEnabled = false;
                                }
                            }
                        }
                    }
                }
            }
            int start = number;
            int end = 100;
            for (int k = 0; k < checkBoxesView.Length; k++)
            {
                if (checkBoxesView[k].IsChecked == true)
                {
                    end = k;
                }
            }

            if ((start != 100) && (end != 100))
            {
                for (int z = start; z < end; z++)
                {
                    checkBoxesView[z].IsEnabled = true;
                }
                for (int z = start; z < end; z++)
                {
                    if (checkBoxesView[z].IsChecked == false)
                    {
                        if ((z > start) && (z < end))
                        {
                            MessageDialog msg = new MessageDialog("You cannot split the meetings in two different times. If you want to do so, try to make two meetings with different times.");
                            msg.ShowAsync();
                            checkBoxesView[z].IsChecked = true;
                        }
                    }
                }
            }
           
        }

        private void checkbox1_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox2_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox3_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox4_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox5_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox6_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox7_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox8_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox9_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox10_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox11_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

        private void checkbox12_Checked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }



        private void checkbox1_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox2_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox3_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox4_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox5_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox6_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox7_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox8_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox9_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox10_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox11_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }
        private void checkbox12_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckCheckBoxes();
        }

    }
}
