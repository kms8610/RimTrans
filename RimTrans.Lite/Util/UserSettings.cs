﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace RimTrans.Lite.Util
{
    internal sealed class UserSettings : INotifyPropertyChanged
    {
        private static readonly ResourceDictionary Default;
        private static ResourceDictionary _appData;

        public static UserSettings All { get; } = new UserSettings();

        #region Initial and Save

        static UserSettings()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            Default = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source.OriginalString.EndsWith("/DefaultSettings.xaml"));

            // AppData settings file path
            string settings = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RimTrans", "Settings.xaml");

            // Check AppData settings file existing
            if (!File.Exists(settings))
            {
                string dir = Path.GetDirectoryName(settings);

                if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                // Create empty file
                File.Create(settings).Dispose();
            }

            // Load AppData settings file
            if (File.Exists(settings))
            {
                _appData = LoadOrDefault(settings);
                Application.Current.Resources.MergedDictionaries.Add(_appData);
            }
        }

        public static void Save()
        {
            if (_appData == null) return;

            string settings = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RimTrans", "Settings.xaml");

            string dir = Path.GetDirectoryName(settings);

            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (XmlWriter xw = XmlWriter.Create(settings, new XmlWriterSettings { Indent = true }))
            {
                XamlWriter.Save(_appData, xw);
            }
        }

        private static object GetValue([CallerMemberName] string key = "")
        {
            if (Application.Current == null || Application.Current.Resources == null)
                return Default[key];

            if (Application.Current.Resources.Contains(key))
                return Application.Current.FindResource(key);

            return Default[key];
        }

        private static void SetValue(object value, [CallerMemberName] string key = "")
        {
            if (_appData != null)
            {
                if (_appData.Contains(key))
                {
                    _appData[key] = value;
                }
                else
                {
                    _appData.Add(key, value);
                }
            }

            if (Application.Current.Resources.Contains(key))
            {
                Application.Current.Resources[key] = value;
            }
            else
            {
                Application.Current.Resources.Add(key, value);
            }

            All.OnPropertyChanged(key);
        }

        private static ResourceDictionary LoadOrDefault(string path)
        {
            ResourceDictionary resource = null;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                        resource = (ResourceDictionary)XamlReader.Load(fs);
                    }
                    catch (Exception)
                    {
                        resource = new ResourceDictionary();
                    }
                }
            }
            catch (Exception)
            {
                resource = new ResourceDictionary();
            }

            return resource;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        //public T PropertyName
        //{
        //    get { return (T)GetValue(); }
        //    set { SetValue(value); }
        //}

        // MainWindow

        #region RimWorld

        public string RimWorldInstallDir
        {
            get { return (string)GetValue(); }
            set { SetValue(value); }
        }

        public string Workshop294100
        {
            get { return (string)GetValue(); }
            set { SetValue(value); }
        }

        // 1-13

        public bool Selected_ChineseSimplified
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_ChineseTraditional
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Czech
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Danish
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Dutch
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_English
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Estonian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Finnish
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_French
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_German
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Hungarian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Italian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Japanese
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        // 14-26

        public bool Selected_Korean
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Norwegian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Polish
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Portuguese
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_PortugueseBrazilian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Romanian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Russian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Slovak
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Spanish
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_SpanishLatin
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Swedish
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Turkish
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        public bool Selected_Ukrainian
        {
            get { return (bool)GetValue(); }
            set { SetValue(value); }
        }

        #endregion

        #region MainWindow

        public WindowState MainWindowState
        {
            get { return (WindowState)GetValue(); }
            set { SetValue(value); }
        }

        public double MainWindowHeight
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double MainWindowWidth
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double MainWindowLeft
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double MainWindowTop
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double ModListBoxWidth
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double LanguageListBoxWidth
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        #endregion

        #region Window Add Mod

        public WindowState AddModWindowState
        {
            get { return (WindowState)GetValue(); }
            set { SetValue(value); }
        }

        public double AddModWindowHeight
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double AddModWindowWidth
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public string AddModSelectedDirLastTime
        {
            get { return (string)GetValue(); }
            set { SetValue(value); }
        }

        #endregion

        #region Window Options

        public WindowState OptionsWindowState
        {
            get { return (WindowState)GetValue(); }
            set { SetValue(value); }
        }

        public double OptionsWindowHeight
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public double OptionsWindowWidth
        {
            get { return (double)GetValue(); }
            set { SetValue(value); }
        }

        public string LanguageCode
        {
            get { return (string)GetValue(); }
            set { SetValue(value); }
        }

        #endregion

        #endregion
    }
}