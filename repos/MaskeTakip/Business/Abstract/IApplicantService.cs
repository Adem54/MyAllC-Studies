using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IApplicantService
    {
        //interface içerisinde sadece method imzası barındırabilirsin
        //public verilmez çünkü default olarak publictir zaten
        //imzası demek methoduları sadece public hariç isimleri ve
        //parametrelerini yaz demektir yani süslü parantez kısımlarını çıkar demektir

        void ApplyForMask(Person person);

        //Methodun imzalarını koyuyorsun onu kullanınca zorunlu olarak implemente etmen gerekiyor yani uygulamak seviyesinde bilen birisi bunu projelerinde kullanamaz
        //Bu mantık syntax programcılığıdır ve mantık tam oturmaz neden interface kullanayım diyebilir yani sıfr imzayı kullanmak için mi bunu yaptık
        //Tabi ki hayır yazılımda bağımlılığı çözmek için biz asıl interface kullanıyoruz
        //Ben eğer burayı yapmasa idim bizden yabancı uyruklular için de maske talebi olması senaryosunda o değişikliğe karşılık veremeyecektik



        List<Person> GetList();

        void NewMethod();


        bool CheckPerson(Person person);
        bool CheckPerson();
    }
}
//INTERFACE TANIMI
// Interface ler belli metod imzalarını barındırırlar. Birbirinin alternatifi olan sistemlerin farklı
// implemansyon yapmasını sağlarlar ForeignerManager ve PersonManager alternatif olan class lar
