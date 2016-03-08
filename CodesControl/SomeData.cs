using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CodesControl
{
    public class SomeData
    {
        private List<ViewModel.ItemUserCodes_ViewModel> ItemsArray;

        public SomeData()
        {
            ItemsArray = new List<ViewModel.ItemUserCodes_ViewModel>();

            Model.Users _user = new Model.Users();
            _user.ID = 1;
            _user.Name = "Илья";
            _user.LastName = "Иджян";
            _user.ParentName = "Юрьевич";
            _user.Email = "kloder@mail.ru";
            _user.Login = "kloder";
            _user.EducationType = "S";
            _user.Phone = "8 903 145-34-12";
            _user.Code = "qwerty";
            _user.Skype = "kloder1";

            Model.Codes _code = new Model.Codes();
            _code.Id = 11;
            _code.Code = "qwerty";
            _code.Active = true;
            _code.UserId = 1;
            _code.EducationType = "S";
            _code.ExpirationDate = new System.DateTime(2016, 8, 15);

            ItemsArray.Add(new ViewModel.ItemUserCodes_ViewModel(new Model.ItemUserCodes_Model(_user, _code)));

            // -----------------------------------------
            Model.Users _user2 = new Model.Users();
            _user2.ID = 2;
            _user2.Name = "Андрей";
            _user2.LastName = "Лезин";
            _user2.ParentName = "Николаевич";
            _user2.Email = "angel@mail.ru";
            _user2.Login = "lezin";
            _user2.EducationType = "Z";
            _user2.Phone = "8 903 888-54-66";
            _user2.Code = "asdfg";
            _user2.Skype = "kloder1";

            Model.Codes _code2 = new Model.Codes();
            _code2.Id = 12;
            _code2.Code = "asdfg";
            _code2.Active = true;
            _code2.UserId = 2;
            _code2.EducationType = "Z";
            _code2.ExpirationDate = new System.DateTime(2016, 6, 10);

            ItemsArray.Add(new ViewModel.ItemUserCodes_ViewModel(new Model.ItemUserCodes_Model(_user2, _code2)));

            // -----------------------------------------
            Model.Users _user3 = new Model.Users();
            _user3.ID = 3;
            _user3.Name = "Макарова";
            _user3.LastName = "Надежда";
            _user3.ParentName = "Валерьевна";
            _user3.Email = "n.makarova@mail.ru";
            _user3.Login = "makar";
            _user3.EducationType = "V";
            _user3.Phone = "8 903 345-98-45";
            _user3.Code = "rewq";
            _user3.Skype = "kloder1";

            Model.Codes _code3 = new Model.Codes();
            _code3.Id = 13;
            _code3.Code = "rewq";
            _code3.Active = true;
            _code3.UserId = 3;
            _code3.EducationType = "V";
            _code3.ExpirationDate = new System.DateTime(2016, 11, 5);

            ItemsArray.Add(new ViewModel.ItemUserCodes_ViewModel(new Model.ItemUserCodes_Model(_user3, _code3)));


            // -----------------------------------------
            Model.Users _user4 = new Model.Users();
            _user4.ID = 4;
            _user4.Name = "Айнетдинов";
            _user4.LastName = "Ринат";
            _user4.ParentName = "Саярович";
            _user4.Email = "rinat@mail.ru";
            _user4.Login = "r.ainet";
            _user4.Phone = "8 916 555-34-00";
            // _user4.EducationType = "Z";
            _user4.Code = "fdsa";
            _user4.Skype = "kloder1";

            Model.Codes _code4 = new Model.Codes();
            _code4.Id = 14;
            _code4.Code = "fdsa";
            _code4.Active = true;
            // _code4.EducationType = "Z";
            _code4.UserId = 4;
            _code4.ExpirationDate = new System.DateTime(2016, 11, 12);

            ItemsArray.Add(new ViewModel.ItemUserCodes_ViewModel(new Model.ItemUserCodes_Model(_user4, _code4)));

            // -----------------------------------------
            Model.Users _user5 = new Model.Users();
            _user5.ID = 5;
            _user5.Name = "Корнейчук";
            _user5.LastName = "Вадим";
            _user5.ParentName = "Сергеевич";
            _user5.Email = "nat@mail.ru";
            _user5.Login = "inet";
            _user5.Phone = "8 916 333-43-54";
            _user5.EducationType = "Z";
            _user5.Code = "zxcv";
            _user5.Skype = "kloder1";

            Model.Codes _code5 = new Model.Codes();
            _code5.Id = 15;
            _code5.Code = "zxcv";
            _code5.Active = true;
            _code5.EducationType = "Z";
            _code5.UserId = 5;
            _code5.ExpirationDate = new System.DateTime(2016, 11, 12);

            ItemsArray.Add(new ViewModel.ItemUserCodes_ViewModel(new Model.ItemUserCodes_Model(_user5, _code5)));
        }

        public IEnumerable<ViewModel.ItemUserCodes_ViewModel> GetItems()
        {
            return (IEnumerable<ViewModel.ItemUserCodes_ViewModel>)ItemsArray;
        }
    }
}
