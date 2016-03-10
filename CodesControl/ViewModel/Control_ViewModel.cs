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

        private ObservableCollection<ViewModel.ItemUserCodes_ViewModel> itemsArray;
        private ICollectionView allItems;
        private ICollectionView changeItems;

        private ObservableCollection<Model.EducationType> educationTypesArray;
        private ICollectionView educationTypes;

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

        public Control_ViewModel()
        {
            itemsArray = new ObservableCollection<ViewModel.ItemUserCodes_ViewModel>(new SomeData().GetItems());
            allItems = new CollectionViewSource { Source = itemsArray }.View;
            allItems.CurrentChanged += delegate { changeItems.Refresh(); }; 

            changeItems = new CollectionViewSource { Source = itemsArray }.View;
            changeItems.Filter = OneFilter;

            educationTypesArray = new ObservableCollection<Model.EducationType>(CodesTypePrepare());
            educationTypes = new CollectionViewSource { Source = educationTypesArray }.View;
            educationTypes.CurrentChanged += delegate {
                                                        this.StringForFilterCollection = null;
                                                        allItems.Filter = FilterForAviableCollection;
                                                      };            
        }

        public ICollectionView AviableCollection
        {
            get { return this.allItems; }
        }

        public ICollectionView DifferentCollection
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
            var type = (Model.EducationType)educationTypes.CurrentItem;

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
