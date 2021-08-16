using Transeth.Helper;
using Transeth.Models;
using System.Collections.Generic;

namespace Transeth.ViewModels
{
    public class MainPageViewModel : BaseViewModel, IAppStateAware
    {
        private List<string> itemList;
        public List<string> ItemList { get => itemList; set { SetValue(ref itemList, value); } }

        public void OnResumeApplicationAsync()
        {
            ItemList = Datas.SharedItems;
        }
    }
}
