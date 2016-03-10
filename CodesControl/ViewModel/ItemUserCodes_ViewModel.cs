using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.ViewModel
{
    public class ItemUserCodes_ViewModel : ViewModelBase
    {
        Model.ItemUserCodes_Model ItemModel;

        // Коструктор
        public ItemUserCodes_ViewModel(Model.ItemUserCodes_Model model)
        {
            this.ItemModel = model;
        }



        //Поля для чтения класса пользователя
        public Int32 UserId { get { return ItemModel.User.ID; } }
        public string UserName { get { return ItemModel.User.Name; } }
        public string UserLastName { get { return ItemModel.User.LastName; } }
        public string UserParentName { get { return ItemModel.User.ParentName; } }
        public string UserEmail { get { return ItemModel.User.Email; } }
        public string UserLogin { get { return ItemModel.User.Login; } }
        public string UserPhone { get { return ItemModel.User.Phone; } }
        public string UserSkype { get { return ItemModel.User.Skype; } }
        // Поля для изменения
        public string EducationType
        {
            get
            {
                string type = "Не определён";
                if (ItemModel.User.EducationType == "S") { type = "Студент"; }
                if (ItemModel.User.EducationType == "Z") { type = "Заочник"; }
                if (ItemModel.User.EducationType == "V") { type = "Выпускник"; }
                return type;
            }
            set
            {
                if (value != ItemModel.User.EducationType)
                {
                    buckupItem();
                    ItemModel.User.EducationType = value; ItemModel.Code.EducationType = value;
                    OnPropertyChanged("EducationType");
                }
            }
        }

        public string Code
        {
            get
            {
                return ItemModel.User.Code;
            }
            set
            {
                if (value != ItemModel.User.Code)
                {
                    buckupItem();
                    ItemModel.User.Code = value; ItemModel.Code.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        //Поля для чтения класса кодов
        public Int32 CodeId { get { return ItemModel.Code.Id; } }
        public bool CodeActive { get { return ItemModel.Code.Active; } }

        public DateTime CodeExpirationDate
        {
            get
            {
                return ItemModel.Code.ExpirationDate;
            }
            set
            {
                if (value != ItemModel.Code.ExpirationDate)
                {
                    buckupItem();
                    ItemModel.Code.ExpirationDate = value;
                    OnPropertyChanged("CodeExpirationDate");
                }
            }
        }

        public bool BuckUpAviable { get { return ItemModel.buckupAviable; } }

        private void buckupItem()
        {
            if ( !ItemModel.buckupAviable )
            {
                ItemModel.selfBuckup();
            }
        }


    }
}