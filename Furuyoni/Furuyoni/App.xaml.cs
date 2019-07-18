using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Furuyoni.Model;
using Furuyoni.Views;
using Prism.Ioc;
using Prism.Unity;

namespace Furuyoni
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Instance and Singleton
            containerRegistry.RegisterSingleton<ICardList, CardList>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindowView>();
        }
    }
}
