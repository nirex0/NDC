/**************************************************************************\
Copyright (c) 2017 Nirex.0@Gmail.Com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
\**************************************************************************/


using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NDC.NStyle.Controls
{
    public class NSListBox : ListBox
    {
        private NDC.NDynamics.Core.Lerp BRHOV;
        private NDC.NDynamics.Core.Lerp BRUNH;
        public bool Override { get; set; } = false;
        public NSListBox()
        {
            Style = (Style)FindResource("NS_LISTBOX");

            MouseEnter += NLB_ME;
            MouseLeave += NLB_ML;

            BorderThickness = new Thickness(0, 0, 0, 0);
            FontSize = 14;
            FontWeight = FontWeights.Bold;
            FontFamily = new FontFamily("Global User Interface");
            Foreground = new SolidColorBrush(Container.Colors.MAIN);
            BorderBrush = new SolidColorBrush(Container.Colors.MAIN);
            Background = new SolidColorBrush(Container.Colors.BACK);
        }

        private void NLB_ME(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BOR_HOVER();
        }
        private void NLB_ML(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BOR_UNHOVER();
        }
        private void BOR_HOVER()
        {
            try
            {
                if (BRUNH != null)
                {
                    BRUNH.Pause();
                }
                    BRHOV = new NDC.NDynamics.Core.Lerp(0, 2, 0.01f, 0.1f, 1);
                    BRHOV.LTick += BRHOV_LerpTick;
                    BRHOV.LDone += BRHOV_LerpDone;
                    BRHOV.Start();
            }
            catch { }
        }
        private void BRHOV_LerpTick(object sender, NDC.NDynamics.Arguments.LerpArgs e)
        {
            BorderThickness = new Thickness(e.valueExact, 0, BorderThickness.Right, 0);
        }
        private void BRHOV_LerpDone(object sender, NDC.NDynamics.Arguments.LerpArgs e)
        {
            BorderThickness = new Thickness(2, 0, BorderThickness.Right, 0);
        }
        private void BOR_UNHOVER()
        {
            try
            {
                if (BRHOV != null)
                {
                    BRHOV.Pause();
                }
                    BRUNH = new NDC.NDynamics.Core.Lerp(2, 0, 0.01f, 0.1f, 1);
                    BRUNH.LTick += BRUNH_LerpTick;
                    BRUNH.LDone += BRUNH_LerpDone;
                    BRUNH.Start();
            }
            catch { }
        }
        private void BRUNH_LerpTick(object sender, NDC.NDynamics.Arguments.LerpArgs e)
        {
            BorderThickness = new Thickness(e.valueExact, 0, BorderThickness.Right, 0);
        }
        private void BRUNH_LerpDone(object sender, NDC.NDynamics.Arguments.LerpArgs e)
        {
            BorderThickness = new Thickness(0, 0, BorderThickness.Right, 0);
        }

        public int Add(string intake)
        {
            NSListBoxItem TMP_ITEM = new NSListBoxItem();
            TMP_ITEM.NContainer = this;
            TMP_ITEM.Content = intake;
            Items.Add(TMP_ITEM);
            return Items.Count;
        }
        public NSListBoxItem Get(int index)
        {
            return Items.GetItemAt(index) as NSListBoxItem;
        }
        public void Update()
        {
            if (!Override)
            {
                 NDC.NStyle.Transition.Smooth.ListBox.Foreground(this, Container.Colors.MAIN, 250);
                 NDC.NStyle.Transition.Smooth.ListBox.BorderBrush(this, Container.Colors.MAIN, 250);
                 NDC.NStyle.Transition.Smooth.ListBox.Background(this, Container.Colors.BACK, 250);
            }
        }
    }
}
