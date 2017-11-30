﻿using ElmSharp.Wearable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.CircularUI;
using Xamarin.Forms.Platform.Tizen;
using ElmSharp;

[assembly: ExportRenderer(typeof(Xamarin.Forms.CircularUI.CircleDateTimeSelector), typeof(Xamarin.Forms.CircularUI.Renderer.CircleDateTimeSelectorRenderer))]


namespace Xamarin.Forms.CircularUI.Renderer
{
    public class CircleDateTimeSelectorRenderer : ViewRenderer<CircleDateTimeSelector, ElmSharp.Wearable.CircleDateTimeSelector>
    {
        public CircleDateTimeSelectorRenderer()
        {
            RegisterPropertyHandler(CircleDateTimeSelector.MarkerColorProperty, UpdateMarkerColor);
            RegisterPropertyHandler(CircleDateTimeSelector.ValueTypeProperty, UpdateValueType);
            RegisterPropertyHandler(CircleDateTimeSelector.DateTimeProperty, UpdateDateTime);
            RegisterPropertyHandler(CircleDateTimeSelector.MaximumDateProperty, UpdateMaximum);
            RegisterPropertyHandler(CircleDateTimeSelector.MinimumDateProperty, UpdateMinimum);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CircleDateTimeSelector> e)
        {
            if (Control == null)
            {
                var surface = this.GetSurface();
                if (null != surface)
                {
                    Console.WriteLine($"Circle Surface hash = {surface.GetHashCode()}");
                    SetNativeControl(new ElmSharp.Wearable.CircleDateTimeSelector(Xamarin.Forms.Platform.Tizen.Forms.Context.MainWindow, surface));
                }
                else
                {
                    throw new CirclePageNotFoundException();
                }
            }
            base.OnElementChanged(e);
        }

        protected override Size MinimumSize()
        {
            return new ElmSharp.Size(300, 290).ToDP();
        }

        protected override ElmSharp.Size Measure(int availableWidth, int availableHeight)
        {
            return new ElmSharp.Size(300, 290);
        }

        void UpdateMinimum(bool initialize)
        {
            if (null != Control && null != Element)
            {
                Control.MinimumDateTime = Element.MinimumDate;
                Console.WriteLine($"CircleDateTimeSelector.MinimumDateTime = {Control.MinimumDateTime}");
            }   
        }

        void UpdateMaximum(bool initialize)
        {
            if (null != Control && null != Element)
            {
                Control.MaximumDateTime = Element.MaximumDate;
                Console.WriteLine($"CircleDateTimeSelector.MaximumDateTime = {Control.MaximumDateTime}");
            }   
        }

        void UpdateDateTime(bool initialize)
        {
            if (null != Control && null != Element)
            {
                Control.DateTime = Element.DateTime;
                Console.WriteLine($"CircleDateTimeSelector.DateTime = {Control.DateTime}");
            }
        }

        void UpdateValueType(bool initializej)
        {
            if (null != Control && null != Element)
            {
                if (Element.ValueType == DateTimeType.Date)
                {
                    Control.Style = "datepicker/circle";
                }
                else if (Element.ValueType == DateTimeType.Time)
                {
                    Control.Style = "timepicker/circle";
                }
                Console.WriteLine($"CircleDateTimeSelector.Style = {Control.Style}");
            }
        }

        void UpdateMarkerColor(bool initialize)
        {
            if (null != Control && null != Element && Element.MarkerColor != Color.Default)
            {
                Control.MarkerColor = Element.MarkerColor.ToNative();
                Console.WriteLine($"CircleDateTimeSelector.MarkerColor = {Control.MarkerColor}");
            }
        }
    }
}
