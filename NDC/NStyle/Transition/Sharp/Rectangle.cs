﻿/**************************************************************************\
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
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NDC.NStyle.Transition.Sharp
{
    public static class Rectangle
    {
        /// <summary>
        /// Changes the Fill property of the control.
        /// </summary>
        /// <param name="targetControl">The control instance.</param>
        /// <param name="fromValue">The color to change to before the transition begins./param>
        /// <param name="toValue">The color to change to.</param>
        /// <param name="duration">Transtition Time in Milliseconds.</param>
        public static void Fill(System.Windows.Shapes.Rectangle targetControl, Color fromValue, Color toValue, int duration)
        {
            ColorAnimation animation = new ColorAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(duration)));
            targetControl.Fill = new SolidColorBrush(fromValue);
            targetControl.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }
        /// <summary>
        /// Changes the Stroke property of the control.
        /// </summary>
        /// <param name="targetControl">The control instance.</param>
        /// <param name="fromValue">The color to change to before the transition begins./param>
        /// <param name="toValue">The color to change to.</param>
        /// <param name="duration">Transtition Time in Milliseconds.</param>
        public static void Stroke(System.Windows.Shapes.Rectangle targetControl, Color fromValue, Color toValue, int duration)
        {
            ColorAnimation animation = new ColorAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(duration)));
            targetControl.Stroke = new SolidColorBrush(fromValue);
            targetControl.Stroke.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

    }
}
