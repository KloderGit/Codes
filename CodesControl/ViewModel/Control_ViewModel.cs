using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.ComponentModel;

namespace CodesControl.ViewModel
{
    public class Control_ViewModel : ViewModelBase
    {

        private Clsses.Collection.ObserverableCollection_WithNotifyObjectChange<ViewModel.ItemUserCodes_ViewModel> itemsArray;
        private ICollectionView allItems;

        private ObservableCollection<ViewModel.ItemUserCodes_ViewModel> changedArray;
        private ListCollectionView changeItems;

        private ObservableCollection<Model.EducationType> educationTypesArray;
        private ICollectionView educationTypes;

        private ViewModel.ItemUserCodes_ViewModel currentItem;

        private string filterCollection;

        public string StringForFilterCollection {
            get { return this.filterCollection; }
            set 
            {
                this.filterCollection = value;
                OnPropertyChanged("StringForFilterCollection");
                allItems.Filter = FilterForAviableCollection;
            }
        }

        public ViewModel.ItemUserCodes_ViewModel CurrentItem
        {
            get { return this.currentItem; }
            set
            {
                this.currentItem = value;
               Console.WriteLine("Куррент - изменео");
                OnPropertyChanged("CurrentItem");
            }
        }

        public Control_ViewModel()
        {
            itemsArray = new SomeData().GetItems();

            educationTypesArray = new ObservableCollection<Model.EducationType>(CodesTypePrepare());
            educationTypes = new CollectionViewSource { Source = educationTypesArray }.View;
            educationTypes.CurrentChanged += delegate {
                this.StringForFilterCollection = null;
            };

            changedArray = new ObservableCollection<ItemUserCodes_ViewModel>();
            changeItems = new ListCollectionView(changedArray);
            changeItems.CurrentChanged += delegate { Console.WriteLine("Cvtyf"); };

            allItems = new ListCollectionView(this.itemsArray);
            allItems.Filter = FilterForAviableCollection;
            allItems.CurrentChanged += delegate {
                this.CurrentItem = allItems.CurrentItem as ViewModel.ItemUserCodes_ViewModel;
                this.DifferentCalculate();
            };

            this.CurrentItem = allItems.CurrentItem as ViewModel.ItemUserCodes_ViewModel;
        }

        public ICollectionView AviableCollection
        {
            get { return this.allItems; }
        }

        private void DifferentCalculate()
        {
            changedArray = new ObservableCollection<ItemUserCodes_ViewModel> ( (from it in itemsArray where it.BuckUpAviable select it).ToList() );
            changeItems = new ListCollectionView(changedArray);
            OnPropertyChanged("DifferentCollection");
        }

        public ListCollectionView DifferentCollection
        {
            get { return this.changeItems; }
        }

        public ICollectionView CodesType
        {
            get { return this.educationTypes; }
        }

        private bool OneFilter(object item)
        {
            ViewModel.ItemUserCodes_ViewModel i = item as ViewModel.ItemUserCodes_ViewModel;
            return i.BuckUpAviable;
        }

        private List<Model.EducationType> CodesTypePrepare()
        {
            var listTypes = new List<Model.EducationType>();
            listTypes.Add(new Model.EducationType("Все статусы", this.itemsArray.Count));

            var group = itemsArray.GroupBy(g=>g.EducationType);
            var list = from type in @group select new Model.EducationType(type.Key, type.ToList().Count);
            listTypes.AddRange(list);

            return listTypes;
        }

        private bool FilterForAviableCollection(object _item)
        {
            var item = _item as ViewModel.ItemUserCodes_ViewModel;
            var type = educationTypes.CurrentItem as Model.EducationType;

            string i1, i2;
            bool typeCorrect = true, stringCorrect = true;

            if (!String.IsNullOrEmpty(this.filterCollection))
            {
                i1 = (item.UserName + item.UserLastName + item.UserParentName + item.Code).ToUpper();
                i2 = this.filterCollection.ToUpper();

                if ( !i1.Contains(i2) ) { stringCorrect = false; }
            }

            if (type != null)
            {
                if (type.Title == "Все статусы")
                {
                    typeCorrect = true;
                }
                else
                {
                    if (!item.EducationType.Equals(type.Title)) { typeCorrect = false; }
                }                
            }

            return typeCorrect & stringCorrect;
        }

    }
}
