﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AwfulForumsReader.Core.Tools;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769
using AwfulForumsReader.Tools;

namespace AwfulForumsReader.Pages
{
    public sealed partial class ForumSettingsFlyout : SettingsFlyout
    {
        private readonly ApplicationDataContainer _localSettings;

        public ForumSettingsFlyout()
        {
            InitializeComponent();
            _localSettings = ApplicationData.Current.LocalSettings;
            if (_localSettings.Values.ContainsKey(Constants.BookmarkBackground))
            {
                BookmarkLiveTiles.IsOn = (bool)_localSettings.Values[Constants.BookmarkBackground];
            }
            if (_localSettings.Values.ContainsKey(Constants.BookmarkStartup))
            {
                LoadBookmarksOnLoadSwitch.IsOn = (bool)_localSettings.Values[Constants.BookmarkStartup];
            }
            if (_localSettings.Values.ContainsKey(Constants.BookmarkDefault))
            {
                FilterComboBox.SelectedIndex = (int)_localSettings.Values[Constants.BookmarkDefault];
            }
            else
            {
                FilterComboBox.SelectedIndex = 0;
            }
            if (_localSettings.Values.ContainsKey(Constants.DarkMode))
            {
                DarkLightThemeSwitch.IsOn = (bool)_localSettings.Values[Constants.DarkMode];
            }
            if (_localSettings.Values.ContainsKey(Constants.AutoRefresh))
            {
                AutoReloadSwitch.IsOn = (bool)_localSettings.Values[Constants.AutoRefresh];
            }
        }

        private async void BookmarkLiveTiles_Toggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null) return;
            if (toggleSwitch.IsOn)
            {
                // Run bookmark live tile creator every 15 minutes.
                // TODO: Change 15 to user selectable value.
                BackgroundTaskUtils.UnregisterBackgroundTasks(BackgroundTaskUtils.BackgroundTaskName);
                BackgroundTaskRegistration task = await
                    BackgroundTaskUtils.RegisterBackgroundTask(BackgroundTaskUtils.BackgroundTaskEntryPoint,
                        BackgroundTaskUtils.BackgroundTaskName,
                        new TimeTrigger(15, false),
                        null);
                _localSettings.Values[Constants.BookmarkBackground] = true;
            }
            else
            {
                //BackgroundTaskUtils.UnregisterBackgroundTasks(BackgroundTaskUtils.BackgroundTaskName);
                _localSettings.Values[Constants.BookmarkBackground] = false;
            }
        }

        private void LoadBookmarksOnLoadSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null) return;
            if (toggleSwitch.IsOn)
            {
                _localSettings.Values[Constants.BookmarkStartup] = true;
            }
            else
            {
                _localSettings.Values[Constants.BookmarkStartup] = false;
            }
        }

        private void FilterComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterComboBox == null) return;
            // TODO: Make Enum.
            _localSettings.Values[Constants.BookmarkDefault] = FilterComboBox.SelectedIndex;
        }

        private void DarkLightThemeSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null) return;
            if (toggleSwitch.IsOn)
            {
                _localSettings.Values[Constants.DarkMode] = true;
            }
            else
            {
                _localSettings.Values[Constants.DarkMode] = false;
            }
        }

        private void AutoReloadSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null) return;
            if (toggleSwitch.IsOn)
            {
                _localSettings.Values[Constants.AutoRefresh] = true;
            }
            else
            {
                _localSettings.Values[Constants.AutoRefresh] = false;
            }
        }
    }
}
