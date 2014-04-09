﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CefSharp.Example;
using CefSharp.Wpf.Example.Views.Main;

namespace CefSharp.Wpf.Example
{
	public partial class MainWindow : Window
	{
		private const string DefaultUrl = "https://www.google.com.au";

		public ObservableCollection<BrowserTabViewModel> BrowserTabs { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			BrowserTabs = new ObservableCollection<BrowserTabViewModel>();

			CommandBindings.Add(new CommandBinding(ApplicationCommands.New, OpenNewTab));
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, CloseTab));

			Loaded += MainWindowLoaded;
		}

		private void CloseTab(object sender, ExecutedRoutedEventArgs e)
		{
			//Obtain the original source element for this event
			var originalSource = (FrameworkElement)e.OriginalSource;

			//Remove the matching DataContext from the BrowserTabs collection
			BrowserTabs.Remove((BrowserTabViewModel)originalSource.DataContext);
		}

		private void OpenNewTab(object sender, ExecutedRoutedEventArgs e)
		{
			CreateNewTab();

			TabControl.SelectedIndex = TabControl.Items.Count - 1;
		}

		private void MainWindowLoaded(object sender, RoutedEventArgs e)
		{
			CreateNewTab(ExamplePresenter.DefaultUrl, true);
		}

		private void CreateNewTab(string url = DefaultUrl, bool showSideBar = false)
		{
			BrowserTabs.Add(new BrowserTabViewModel(url) { ShowSidebar = showSideBar });
		}
	}
}
